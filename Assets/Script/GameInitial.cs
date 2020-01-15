using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameInitial
{
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
#if UNITY_STANDARONE
        Screen.SetResolution(270, 960, false, 60);
#endif
    }
}
