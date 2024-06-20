using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Vector2 parallaxEffectsMultiplier;

    Transform cameraPos;
    Vector3 lastCamPos;

    private void Awake()
    {
        cameraPos = Camera.main.transform;
        lastCamPos = cameraPos.position;
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraPos.position - lastCamPos;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectsMultiplier.x, deltaMovement.y * parallaxEffectsMultiplier.y, 0);
        lastCamPos = cameraPos.position;
    }
}