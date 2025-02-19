using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    public Transform target; 
    public float smoothSpeed = 5f; 
    public Vector3 offset; 
    void Update()
    {
        if (target != null)
        {
         
            Vector3 desiredPosition = target.position + offset;

           
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            transform.position = smoothedPosition;

           
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
    }
}
