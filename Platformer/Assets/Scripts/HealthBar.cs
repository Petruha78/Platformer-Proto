using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : GameElement {

    Slider slider;

    [SerializeField]
    Image health;

    Color primaryColor;

    void Awake()
    {
        slider = GetComponent<Slider>();
        primaryColor = health.color;
    }
        
	void Start ()
    {
        
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        slider.value = App.knight.CurrentHealth/100f;

        health.color = HitPointColor.SetGradient( primaryColor, Color.cyan, slider.value);
        
    }
}
