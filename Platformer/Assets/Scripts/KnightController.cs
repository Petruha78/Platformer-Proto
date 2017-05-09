using UnityEngine;
using System.Collections;


public class KnightController : GameElement
{
    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    Animator animator;

    [SerializeField]
    Rigidbody2D _rigidbody;

    [SerializeField]
    private Transform PlayerTransform;


    [SerializeField]
    private Transform attackPoint;


    Vector2 velocity;

    

    public  void PlayerMove()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        velocity = _rigidbody.velocity;
        velocity.x = Input.GetAxis("Horizontal") * App.knightModel.Speed;
        _rigidbody.velocity = velocity;
    }


    public void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && OnGround())
        {
            _rigidbody.AddForce(Vector2.up * App.knightModel.JumpForce);
        }

        
    }


    public void IsOnStair()
    {
        if (App.knightModel.onStair)
        {
            velocity.y = Input.GetAxis("Vertical") * App.knightModel.Speed * 0.7f;
            _rigidbody.velocity = velocity;
            _rigidbody.gravityScale = 0;
        }
        else
            _rigidbody.gravityScale = 1;
    }

    public bool OnGround()
    {
        RaycastHit2D[] hits = Physics2D.LinecastAll(PlayerTransform.position, groundCheck.position);
        
        for (int i = 0; i < hits.Length; i++)
        {
            if (!Equals(hits[i].collider.gameObject, PlayerTransform.gameObject))
            {
                return true;
            }
            
        }
        return false;
    }

    public void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
            Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, App.knightModel.attackRadius);

            foreach (Collider2D hit in hits)
            {
                if (!Equals(hit.gameObject, PlayerTransform.gameObject))
                {
                    IDestructable destructable = hit.gameObject.GetComponent<IDestructable>();

                    if (destructable != null)
                    {

                        destructable.Hit(hit.gameObject);
                        break;
                    }
                }
            }
        }
        
    }

    
}
