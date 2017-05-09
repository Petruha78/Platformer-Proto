using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Application : MonoBehaviour
{

    public KnightModel knightModel;
    public Knight knight;
    public KnightController knightController;

    public DragonModel dragonModel;
    public DragonController dragonController;
    public Dragon dragon;

    public GameObject BlueGem;
    public GameObject RedGem;
    public GameObject GreenGem;

    public MainMenu mainMenu;


    [SerializeField]
    Canvas pauseMenu;

    public static bool isPaused;



    void Start()
    {
        
        pauseMenu.gameObject.SetActive(false);
    }

    void Update()
    {
        Pause();
        
    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Inventory.IsInventoryOpen == false)
        {
            
            isPaused = true;
            pauseMenu.gameObject.SetActive(true);
            gameObject.SetActive(false);
            
            //pauseMenu.gameObject.GetComponentInChildren<Animation>().Play();
        }
        
    }

    public void Resume()
    {
        
        pauseMenu.gameObject.SetActive(false);
        gameObject.SetActive(true);
        isPaused = false;
    }


    public void Exit()
    {
        UnityEngine.Application.Quit();
        
    }
}
