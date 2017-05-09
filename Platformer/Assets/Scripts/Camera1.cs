using UnityEngine;
using System.Collections;


public class Camera1 : MonoBehaviour {
    
    public static GameObject[] buttons;
    Vector3 pos;
    
    void Start ()
    {
        buttons = GameObject.FindGameObjectsWithTag("Button");
        pos = transform.position;
    }
	
	

	void LateUpdate ()
    {
        moveTo();
	
	}

    public void moveTo()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
           
            
            if (buttons[i].GetComponent<ButtonScript>().IsPressed == true)
            {
                
                
                if ((transform.position.y - buttons[i].transform.position.y) > 1 || (transform.position.y - buttons[i].transform.position.y) < -1)
                {
                    transform.position = Vector2.Lerp(transform.position, buttons[i].transform.position, Time.deltaTime*3);
                    Vector3 pos1 = new Vector3(transform.position.x, transform.position.y, pos.z);
                    transform.position = pos1;

                }
                else
                {
                    buttons[i].GetComponent<ButtonScript>().IsPressed = false;
                    
                }
               
            }

           

        }
    }

   
}
