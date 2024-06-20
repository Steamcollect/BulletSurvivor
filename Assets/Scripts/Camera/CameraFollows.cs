using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollows : MonoBehaviour
{
    public float timeOffset;
    public Vector3 posOffset;
    Vector3 velocity = Vector3.zero;
    public Transform target;

    void Update()
    {
        Follow();
    }

    private void OnValidate()
    {
        transform.position = target.position + posOffset;
    }

    void Follow()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + posOffset, ref velocity, timeOffset);
    }
}
