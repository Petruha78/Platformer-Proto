using UnityEngine;
using System.Collections;

public class GameElement : MonoBehaviour {

    

    public Application App
    {
        get
        {
            return GameObject.FindObjectOfType<Application>();
        }
    }
}
