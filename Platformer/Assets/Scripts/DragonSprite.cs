using UnityEngine;
using System.Collections;

public class DragonSprite : GameElement
{
    [SerializeField]
    private Dragon dragon;

    void Attack()
    {
        dragon.Attack();
    }
}
