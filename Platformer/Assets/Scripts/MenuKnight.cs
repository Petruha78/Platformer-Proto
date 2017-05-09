using UnityEngine;

using System.Collections;
using System;

public class MenuKnight : MonoBehaviour {
    [SerializeField]
    private Transform canvasKnightTransform;

    [SerializeField]
    Animator animator;

    [SerializeField]
    Camera camera;

    Transform idleTransform;

    bool isAttack;
    Ray ray;
    void Start ()
    {
        idleTransform = transform;
	}
	
	
	void Update ()
    {
	   if(Vector3.Distance(Input.mousePosition, canvasKnightTransform.position) < 100 && isAttack == false)
        {
            animator.SetTrigger("Attack");
            isAttack = true;
        }

        else if (Vector3.Distance(Input.mousePosition, canvasKnightTransform.position) >=100)
        {
            isAttack = false;
        }
       
            
    }

    void OnMouseDrag()
    {


        transform.position = UnityEngine.Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,-(UnityEngine.Camera.main.transform.position.z)));

        
    }

    
}
