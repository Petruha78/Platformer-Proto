using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : GameElement {

   


	public void AppExit()
    {
        Invoke("Exit", 2);
        
    }

    public void AppPlay()
    {
        Invoke("Play", 2); 
    }

    void Exit()
    {
        UnityEngine.Application.Quit();
       
    }

    public void Play()
    {
        SceneManager.LoadScene("Level_1",LoadSceneMode.Single);
        
    }

    


}
