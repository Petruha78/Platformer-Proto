using UnityEngine;
using System.Collections.Generic;

public class KnightModel : GameElement
{

    private Vector2 walkForce;

    [SerializeField]
    private float speed = 5;

    [SerializeField]
    private float jumpForce = 300;

    [SerializeField]
    private int damage = 0;

    [SerializeField]
    private int health = 100;


    public bool onStair = false;

    public float attackRadius = 0.5f;

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

    public float JumpForce
    {
        get
        {
            return jumpForce;
        }

        set
        {
            jumpForce = value;
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

    public int Health
    {
        get
        {
            return health;
        }
        
        
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

    public  List<Sprite> Inventory = new List<Sprite>();

    void Awake()
    { 
        WalkForce = Vector2.right;
    }
}
