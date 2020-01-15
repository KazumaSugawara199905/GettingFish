using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGroundMusic : MonoBehaviour
{
    //public AudioClip[] audioClips;
    public List<AudioClip> audioClips;
    Dictionary<string, AudioClip> audioClipDict = new Dictionary<string, AudioClip>();
    private AudioSource audioSource;
    public List<string> sceneNames;
   // public List<string> notChangeSN;

    void Start()
    {
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
        audioSource = gameObject.GetComponent<AudioSource>();

        for (int i = 0; i < audioClips.Count; i++)
        {
            audioClipDict.Add(sceneNames[i], audioClips.Find(a => a.name == sceneNames[i]));
        }
        
    }

    void OnActiveSceneChanged(Scene prevSceneName,Scene nextScene)
    {
        if (!sceneNames.Contains(nextScene.name))
        {
            return;
        }

        if(audioSource.clip == audioClipDict[nextScene.name])
        {
            return;
        }
        audioSource.clip = audioClipDict[nextScene.name];
        audioSource.Play();
        audioSource.loop = true;
    }

   public void OnPointerDown()
    {
        audioSource.Pause();
       
    }

    public void OnPointerUp()
    {
        audioSource.UnPause();

    }

}
