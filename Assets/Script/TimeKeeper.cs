using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeKeeper : MonoBehaviour
{
    public GameObject leftTimeBar;
    public GameObject countDownText;
    public GameObject player;
    public GameObject gameDirector;
    public GameObject finishText;
    public AudioClip  countdown;
    public AudioClip  start;
    public AudioClip  finish;

    GamePlayerController playerScript;
    CalcPoint            calcPointScript;
    BackGroundMusic      musicScript;
    AudioSource          audioSource;
    GameObject           BGM;
      
    public float MaxTime;
    public float finishWaitSeconds;
    float        deltaTime;
    float        elapsedTime;
    bool         coroutineFlag;
    bool         startFlag;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (leftTimeBar == null)
            this.leftTimeBar = GameObject.Find("LeftTimeBar");
        if (countDownText == null)
            this.countDownText = GameObject.Find("CountDown");
        if (player == null)
            this.player = GameObject.Find("Player");
        if (finishText == null)
            this.finishText = GameObject.Find("Finish");
        if (gameDirector == null)
            this.gameDirector = GameObject.Find("GameDirector");

        playerScript    = player.GetComponent<GamePlayerController>();
        calcPointScript = gameDirector.GetComponent<CalcPoint>();

        BGM = GameObject.Find("BGM");
        musicScript = BGM.GetComponent<BackGroundMusic>();
               
        startFlag = false;
        coroutineFlag = true;
        deltaTime     = 0;
    }

    void Update()
    {
        //最初だけカウントダウン
        while(coroutineFlag)
        {
            coroutineFlag = false;
            StartCoroutine(CountDownCoroutine());
        }
        //カウントダウン中は処理しない
        while(startFlag)
        {
            elapsedTime += Time.deltaTime;
            deltaTime   += Time.deltaTime;
            if (deltaTime >= 1.0f)//1秒ごとに処理
            {
                deltaTime = 0;
                //時間表示のバーを削る。
                this.leftTimeBar.GetComponent<Image>().fillAmount -= 1 / MaxTime;
                if (elapsedTime >= MaxTime)
                {
                    finishText.gameObject.SetActive(true);
                    SetStartFlag(false);
                    StartCoroutine(FinishCoroutine(finishWaitSeconds));
                }
            }
            break;
        }
    }

    //カウントダウンの表示処理
    IEnumerator CountDownCoroutine()
    {
        countDownText.gameObject.SetActive(true);

        musicScript.OnPointerDown();
        
        countDownText.gameObject.GetComponent<Text>().text = "3";
        audioSource.PlayOneShot(countdown);
        yield return new WaitForSeconds(1.0f);

        countDownText.gameObject.GetComponent<Text>().text = "2";
        audioSource.PlayOneShot(countdown);
        yield return new WaitForSeconds(1.0f);

        countDownText.gameObject.GetComponent<Text>().text = "1";
        audioSource.PlayOneShot(countdown);
        yield return new WaitForSeconds(1.0f);

        countDownText.gameObject.GetComponent<Text>().text = "Start!";
        audioSource.PlayOneShot(start);
        yield return new WaitForSeconds(0.5f);

        musicScript.OnPointerUp();

        countDownText.gameObject.SetActive(false);
        SetStartFlag(true);
    }

    IEnumerator FinishCoroutine(float seconds)
    {
        calcPointScript.SavePoint();

        musicScript.OnPointerDown();
        audioSource.PlayOneShot(finish);


        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("ResultScene");
    }

    void SetStartFlag(bool startFlag)
    {
        this.startFlag = startFlag;
    }

    public bool GetStartFlag()
    {
        return startFlag;
    } 
}

