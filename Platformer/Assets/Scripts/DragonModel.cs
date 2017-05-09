using UnityEngine;
using System.Collections;

public class DragonModel : MonoBehaviour {

   
   private Vector2 walkForce;
   [SerializeField]
   private float speed = 5;

   [SerializeField]
   private int health = 100;

    [SerializeField]
    private int damage = 0;

   void Awake()
    {
        
        WalkForce = Vector2.right;
    }

    public Vector2 WalkForce
    {
        get
        {
            return walkForce;
        }

        set
        {
            walkForce = value;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    public int Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }

}
