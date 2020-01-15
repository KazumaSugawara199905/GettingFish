using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{
    public AudioClip sound;
    AudioSource audioSource;

    public GameObject panel;
    public delegate void functionType();

    public void ClosePanel()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound);

        StartCoroutine(Chacking(() =>
        {
            panel.SetActive(false);
        }));
    }

    private IEnumerator Chacking(functionType callback)
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