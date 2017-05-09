using UnityEngine;
using System.Collections;

public class Stair : MonoBehaviour {

	// Use this for initialization
	
	void OnTriggerEnter2D (Collider2D collider)
    {
        Knight knight = collider.gameObject.GetComponent<Knight>();
        if(knight != null)
        {
            knight.App.knightModel.onStair = true;

        }
	
	}

    void OnTriggerExit2D(Collider2D collider)
    {
        Knight knight = collider.gameObject.GetComponent<Knight>();
        if (knight != null)
        {
            knight.App.knightModel.onStair = false;
        }

    }
}
