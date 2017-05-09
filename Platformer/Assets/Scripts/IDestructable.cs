using UnityEngine;
using System.Collections;

public interface IDestructable
{

    void Hit(GameObject obj);
    void Die(GameObject obj);
}
