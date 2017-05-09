using UnityEngine;
using System.Collections;
using System;
public class Dragon : GameElement, IDestructable
{

    private Rigidbody2D _rigidbody;

    [SerializeField]
    private GameObject level;

    [SerializeField]
    Animator animator;

    [SerializeField]
    private int currentHealth;

    [SerializeField]
    private CircleCollider2D hitCollider;

    private bool isAttack;

    Vector2 walkForce;

    public CircleCollider2D HitCollider
    {
        get
        {
            return hitCollider;
        }

        set
        {
            hitCollider = value;
        }
    }

    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        currentHealth = App.dragonModel.Health;
        walkForce = App.dragonModel.WalkForce;
    }
	
	void Update ()
    {
        
        if(isAttack == false)
        App.dragonController.Move(animator, _rigidbody, walkForce);
        else
        {
            
            
            animator.SetTrigger("Attack");
            

        }

        animator.SetBool("isAttack", isAttack);
    }

    void OnTriggerEnter2D (Collider2D collider)
    {

        if (collider.gameObject.tag == "InvisibleWall")
        {
            walkForce = -(walkForce);
            TurnAround();
        }
        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.tag == "Knight" )
        {

           if(transform.rotation != App.knight.transform.rotation)
            {
                walkForce = -(walkForce);
                TurnAround();
                
            }
            
            
        }
    }


    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject == App.knight.gameObject && currentHealth > 0)
        {
            isAttack = true;
            
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject == App.knight.gameObject)
        {
            isAttack = false;
            
        }
    }

    void TurnAround()
    {



        if (walkForce == Vector2.left)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else if (walkForce == Vector2.right)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);

        }
    }
    public void Hit(GameObject obj)
    {
        currentHealth -= App.knightModel.Damage;
        if (currentHealth <= 0)
        {
            Die(obj);
        }
    }

    public void Die(GameObject obj)
    {
        
        obj.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300.0f);
        obj.GetComponent<Collider2D>().enabled = false;
        obj.GetComponent<Transform>().localScale = new Vector2(1, -1);
        Destroy(obj, 3);
    }

    public void Attack()
    {
        App.dragonController.Attack(gameObject, hitCollider);
    }
}
