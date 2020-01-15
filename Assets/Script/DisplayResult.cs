using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayResult : MonoBehaviour
{
    bool              isDisplayed;
    public float      delay;

    public GameObject fishS;
    public GameObject fishM;
    public GameObject fishL;
    public GameObject fishR;
    public GameObject getFishSAmount;
    public GameObject getFishMAmount;
    public GameObject getFishLAmount;
    public GameObject getFishRAmount;
    public GameObject restart;
    public GameObject stageSelect;

    List<FishStatusData> fishDatas;

    void Start()
    {
        LoadGameObject();
        SetActiveFalse();

        isDisplayed   = false;
    }

    private void Update()
    {
        if (!isDisplayed)
        {
            //1回だけ呼ぶ　タイミングずらして表示
            isDisplayed = true;
            StartCoroutine(DisplayCoroutine(fishS, 0f));
            StartCoroutine(DisplayCoroutine(fishM, 0f));
            StartCoroutine(DisplayCoroutine(fishL, 0f));
            StartCoroutine(DisplayCoroutine(fishR, 0f));
            StartCoroutine(DisplayCoroutine(getFishSAmount, 1f));
            StartCoroutine(DisplayCoroutine(getFishMAmount, 2f));
            StartCoroutine(DisplayCoroutine(getFishLAmount, 3f));
            StartCoroutine(DisplayCoroutine(getFishRAmount, 4.5f));
            StartCoroutine(DisplayCoroutine(restart, 5.5f));
            StartCoroutine(DisplayCoroutine(stageSelect, 5.5f));
        }
    }

    void LoadGameObject()
    {
        if (getFishSAmount == null)
        {
            getFishSAmount = GameObject.Find("GetFishSAmount");
        }
        if (getFishMAmount == null)
        {
            getFishMAmount = GameObject.Find("GetFishMAmount");            
        }
        if (getFishLAmount == null)
        {
            getFishLAmount = GameObject.Find("GetFishLAmount");
        }
        if (restart == null)
        {
            restart = GameObject.Find("Restart");
        }
        if (stageSelect == null)
        {
            stageSelect = GameObject.Find("StageSelect");
        }
        if (fishS == null)
        {
            fishS = GameObject.Find("FishS");
        }
        if (fishM == null)
        {
            fishM = GameObject.Find("FishM");
        }
        if (fishL == null)
        {
            fishL = GameObject.Find("FishL");
        }
    }

    void SetActiveFalse()
    {
        getFishSAmount.SetActive(false);
        getFishMAmount.SetActive(false);
        getFishLAmount.SetActive(false);
        getFishRAmount.SetActive(false);
        restart.SetActive(false);
        stageSelect.SetActive(false);
        fishS.SetActive(false);
        fishM.SetActive(false);
        fishL.SetActive(false);
        fishR.SetActive(false);
    }

    IEnumerator DisplayCoroutine(GameObject gameObject, float seconds)
    {
        yield return new WaitForSeconds(delay + seconds);
        gameObject.SetActive(true);
    }
}
