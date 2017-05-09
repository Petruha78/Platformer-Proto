using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour
{

    float cameraYpos;
    float cameraZpos;
    [SerializeField]
    Transform _transform;

    [SerializeField]
    Transform cameraPoint;

    bool IsCameraReturned;

    void Start()
    {
        //_transform = GetComponent<Transform>();
        cameraYpos = _transform.position.y + 3.1f ;
        cameraZpos = _transform.position.z;
    }

    void LateUpdate ()
    {
       


        if (Application.isPaused == true)
        {
            transform.position = Vector3.Lerp(transform.position, cameraPoint.position, Time.deltaTime * 4);
            IsCameraReturned = true;
        }
            
        else
        {
            if (Vector2.Distance(transform.position, new Vector3(_transform.position.x, cameraYpos, _transform.position.z - 10)) > 0.05 && IsCameraReturned == true)

                transform.position = Vector3.Lerp(transform.position, new Vector3(_transform.position.x, cameraYpos, _transform.position.z - 10), Time.deltaTime * 4);
            else
            {
                IsCameraReturned = false;
                transform.position = new Vector3(_transform.position.x, cameraYpos, _transform.position.z - 10);
            }
                
        }
        
    }
}
