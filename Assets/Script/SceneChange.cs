using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public string sceneName = null;
    [SerializeField, Header("リスタートボタンでこのスクリプトを使うときtrueにする")]
    public bool getSceneName = false;
    public AudioClip sound;
    AudioSource audioSource;
    public delegate void functionType();

    public void toSceneChange()
    {
        if (getSceneName)
        {
            sceneName = GameDirector.sceneName;
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound);

        StartCoroutine(Checking(() =>
        {
            SceneManager.LoadScene(sceneName);
        }));

    }

    private IEnumerator Checking(functionType callback)
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            if (!audioSource.isPlaying)
            {
                callback();
                break;
            }
        }
    }

}
