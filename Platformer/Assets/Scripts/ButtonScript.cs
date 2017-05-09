using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	private bool isPressed = false;

    private GameObject[] buttons;

    public bool IsPressed
    {
        get
        {
            return isPressed;
        }

        set
        {
            isPressed = value;
        }
    }

    public void ButtonIsPressed()
    {
        isPressed = true;
        buttons = Camera1.buttons;

        for (int i = 0; i < buttons.Length; i++)
        {
            if (!Equals(buttons[i], this.gameObject))
            {
                
                buttons[i].GetComponent<ButtonScript>().IsPressed = false;

            }


        }
        

    }

    
}
