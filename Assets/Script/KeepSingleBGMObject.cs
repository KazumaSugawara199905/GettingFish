using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepSingleBGMObject : MonoBehaviour
{
    static KeepSingleBGMObject _instance = null;

    static KeepSingleBGMObject Instance
    {
        get { return _instance ?? (_instance = FindObjectOfType<KeepSingleBGMObject>()); }
    }

    private void Awake()
    {
        if(this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        if (this == Instance)
            _instance = null;
    }
}
