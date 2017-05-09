using UnityEngine;
using System.Collections;
using System;

public class DragonController : GameElement
{
    [SerializeField]
    private Transform dragon;
    
    void Awake ()
    {
        
    }
	
	void Start()
    {
        
        
    }
	public void Move(Animator animator, Rigidbody2D _rigidbody, Vector2 walkForce)
    {
        Vector2 velocity = _rigidbody.velocity;
        velocity.x = walkForce.x * App.dragonModel.Speed;
        _rigidbody.velocity = velocity;

        
    }

    public void Attack(GameObject obj, CircleCollider2D hitCollider)
    {
        
        obj.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

       

            
            Vector3 hitPosition = obj.GetComponent<Transform>().TransformPoint(hitCollider.offset);

            Collider2D[] hits = Physics2D.OverlapCircleAll(hitPosition, hitCollider.radius);

            for (int i = 0; i < hits.Length; i++)
            {
                if (!Equals(hits[i].gameObject, obj))

                {
                    IDestructable destructable = hits[i].gameObject.GetComponent<IDestructable>();

                    if (destructable != null)
                    {
                        destructable.Hit(hits[i].gameObject);
                        break;
                    }
                }
            }
     }
    
}
