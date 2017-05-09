using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryButton : MonoBehaviour
{
    public string gemImageName; 

    [SerializeField]
    private Text text;

    public Text Text
    {
        get
        {
            return text;
        }

        set
        {
            text = value;
        }
    }

    public int count;

    private ButtonDelegate callback;

    public ButtonDelegate Callback
    {
        get
        {
            return callback;
        }

        set
        {
            callback = value;
        }
    }

    public Vector3 size;

   

    void Start()
    {
        count = 1;
        text.text = count.ToString();
        gemImageName = transform.GetChild(0).gameObject.name;
        size = new Vector3(0.95f,0.95f,0);
    } 

    

    

    public void Click()
    {
        if(callback != null)
        {
            callback(this);
        }
        
    }

    
}
