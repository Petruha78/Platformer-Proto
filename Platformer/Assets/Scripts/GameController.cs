using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    private static GameController _instance;

    public static GameController Instance
    {
        get
        {
            return _instance;
        }

        
    }

    void Awake()
    {
        _instance = this;
    }
}
