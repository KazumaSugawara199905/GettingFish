using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{
    public void GameEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
        UnityEngine.Application.Quit();
#elif UNITY_ANDROID
        UnityEngine.Application.Quit();
#endif
    }
}
