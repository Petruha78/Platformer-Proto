using UnityEngine;
using System.Collections;

public class Chest : GameElement
{
    [SerializeField]
    private GameObject gem;

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject == App.knight.gameObject)
        {
            App.knightModel.Inventory.Add(gem.GetComponent<SpriteRenderer>().sprite);
            Destroy(gameObject);
            Inventory.GetInstance().AddItemToInventory();
        }

    }
}
