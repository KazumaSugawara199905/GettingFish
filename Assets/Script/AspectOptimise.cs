using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectOptimise : MonoBehaviour
{
    public float defaultWidth;
    public float defaultHeight;

    void Start()
    {
        Camera mainCamera = Camera.main;

        float defaultAspect = defaultWidth / defaultHeight;
        float actualAspect  = (float)Screen.width / (float)Screen.height;
        float ratio         = actualAspect / defaultAspect;

        mainCamera.orthographicSize /= ratio;
    }
}
