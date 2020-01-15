using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepSinglePlayerObject : MonoBehaviour
{
    static KeepSinglePlayerObject _instance = null;

    static KeepSinglePlayerObject Instance
    {
        get { return _instance ?? (_instance = FindObjectOfType<KeepSinglePlayerObject>()); }
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
