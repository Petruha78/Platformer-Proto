using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;
[ExecuteInEditMode]
public class Knight : GameElement, IDestructable {

    [SerializeField]
    Animator animator;

    [SerializeField]
    KnightController controller;

    [SerializeField]
    private Vector3 pos;

    public Vector3 Pos
    {
        get
        {
            return pos;
        }

        set
        {
            pos = value;
        }
    }

    bool IsDied;

    public bool isHit;

    

    [SerializeField]
    private int currentHealth;

    
    public int CurrentHealth
    {
        get
        {
            return currentHealth;
        }

        set
        {
            currentHealth = value;
        }
    }

   

    void Start ()
    {
        CurrentHealth = App.knightModel.Health;
        
        pos = transform.position;
    }
    

   public void Update ()
    {
        //if(EventSystem.current.IsPointerOverGameObject())
        //{
        //    return;
        //}
        controller.PlayerMove();

        TurnAround();

        controller.PlayerJump();

        controller.IsOnStair();

        controller.Attack();

        if (App.knight.transform.localPosition.y < -9 && IsDied == false)
            Die(gameObject);
    }


    void TurnAround()
    {
        if (animator.GetFloat("Horizontal") < -0.1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);

        }
        else if (animator.GetFloat("Horizontal") > 0.1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
    }

    public void Hit(GameObject obj)
    {
        CurrentHealth -= App.dragonModel.Damage;
        isHit = true;
        if (CurrentHealth <= 0 )
        {
            Die(obj);
        }
    }

    public void Die(GameObject obj)
    {
        obj.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300.0f);
        obj.GetComponent<Collider2D>().enabled = false;
        obj.GetComponent<Transform>().localScale = new Vector2(1, -1);
        Invoke("LoadScene", 3);
        Destroy(obj,3);
        IsDied = true;
        App.knightModel.Inventory.Clear();
        
        
    }

    void LoadScene()
    {
        SceneManager.LoadScene("test", LoadSceneMode.Single);
    }




}
