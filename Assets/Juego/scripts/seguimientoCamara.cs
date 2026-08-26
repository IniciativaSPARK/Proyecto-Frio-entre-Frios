using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class seguimientoCamara : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 4f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        
    }

    void Update()
    {
        if (target != null) {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
