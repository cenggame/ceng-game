using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraCont : MonoBehaviour
{
    public Transform Target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = Target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        
    }
}
