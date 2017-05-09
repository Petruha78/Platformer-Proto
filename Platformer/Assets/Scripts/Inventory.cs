using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public delegate void ButtonDelegate(InventoryButton item);

public class Inventory : GameElement {

    InventoryButton[] allItems;

    GameObject newItem;   

    [SerializeField]
    CanvasGroup inventoryWindow;

    
    
    private static bool isInventoryOpen;
    public static bool IsInventoryOpen
    {
        get
        {
            return isInventoryOpen;
        }

        
    }

    [SerializeField]
    private Transform itemPrefab;
    [SerializeField]
    private Transform InventoryContainer;

    [SerializeField]
    private Text healthText;

    [SerializeField]
    private Text speedText;

    [SerializeField]
    private Text damageText;

    string damage;
    string speed;
    string health;
    

    private static Inventory instance;

    [SerializeField]
    private List<GameObject> gems;

    public static Inventory GetInstance()
    {
        return instance;
    }
    void Awake()
    {
        instance = this;
        
        
        
    }

    void Start()
    {

        inventoryWindow.alpha = 0.0f;
        inventoryWindow.interactable = false;
        inventoryWindow.blocksRaycasts = false;

        gems = new List<GameObject>();
        gems.Add(Instantiate(App.BlueGem));
        gems.Add(Instantiate(App.RedGem));
        gems.Add(Instantiate(App.GreenGem));

        Vector3 v = new Vector3(0, 1, 0);
        Vector3 v1 = Vector3.Normalize(new Vector3(1, 1, 0));

        float v2  = v.magnitude * v1.magnitude * Mathf.Sin(90/57.3f);

        health = healthText.text;
        speed = speedText.text;
        damage = damageText.text;

        healthText.text = string.Concat(health, App.knightModel.Health);
        damageText.text = string.Concat(damage, App.knightModel.Damage);
        speedText.text = string.Concat(speed, App.knightModel.Speed);
    }

	void Update ()
    {
	   if(Input.GetKeyDown(KeyCode.Escape))
        {
            Invoke("CloseInventory", Time.deltaTime);
        }
       
        ChangeScale();

        if(App.knight.isHit == true || GetHealthBonus.isGet == true)
        {
            healthText.text = string.Concat(health, App.knight.CurrentHealth);
            App.knight.isHit = false;
            GetHealthBonus.isGet = false;
        }
        if(GetDamageBonus.isGet == true)
        {
            damageText.text = string.Concat(damage, App.knightModel.Damage);
            GetDamageBonus.isGet = false;
        }

        if(GetSpeedBonus.isGet == true)
        {
            speedText.text = string.Concat(speed, App.knightModel.Speed);
            GetSpeedBonus.isGet = false;
        }
        
        

    }

    public void OpenInventory()
    {
        inventoryWindow.alpha = 1.0f;
        inventoryWindow.interactable = true;
        inventoryWindow.blocksRaycasts = true;
        isInventoryOpen = true;

    }

   public void CloseInventory()
    {
        
        isInventoryOpen = false;
    }

   public void AddItemToInventory()
    {
        newItem = gems[UnityEngine.Random.Range(0, gems.Count)];

        CalculateItems(newItem);
        //newItem.GetComponent<Button>().onClick.AddListener(InventoryButtonPressed);
        newItem.gameObject.GetComponent<InventoryButton>().Callback = InventoryButtonPressed;

        
     }

    void CalculateItems(GameObject inventoryItem)
    {
        
        if (inventoryItem.gameObject.GetComponent<InventoryButton>() != null)
        {
            allItems = InventoryContainer.GetComponentsInChildren<InventoryButton>();

            bool isExist = false;

            for (int i = 0; i < allItems.Length; i++)
            {

                if (allItems[i].gameObject.name.Contains(inventoryItem.gameObject.name) == false)

                    continue;

                else
                {
                    inventoryItem.GetComponent<InventoryButton>().count += 1;
                    int number = inventoryItem.GetComponent<InventoryButton>().count;
                    allItems[i].GetComponent<InventoryButton>().Text.text = number.ToString(); ;

                    isExist = true;
                    break;
                }
            }

            if (isExist == false)
            {
                
                inventoryItem.transform.SetParent(InventoryContainer);
                inventoryItem.transform.localScale = inventoryItem.GetComponent<InventoryButton>().size;
            }
        }
    }

    public void InventoryButtonPressed(InventoryButton item)
    {

        item.count -= 1;

        if (item.count < 1)
        {
            item.count = 1;
            item.transform.SetParent(null);
        }
        item.Text.text = item.count.ToString();

        GetBonus(item);

    }

    private void GetBonus(InventoryButton item)
    {
        item.GetComponent<IGetBonus>().GetBonus();
    }

    void ChangeScale()
    {
        
        if(transform.localScale.x < 1 && isInventoryOpen == true)
            transform.localScale += new Vector3(Time.deltaTime * 4,Time.deltaTime * 4, 0);

        else if(transform.localScale.x > 0  && isInventoryOpen == false)
        {
            transform.localScale -= new Vector3(Time.deltaTime * 4, Time.deltaTime * 4, 0);

            if(transform.localScale.x < 0.1)

                inventoryWindow.alpha = 0.0f;
        }
            
    }

   

}
