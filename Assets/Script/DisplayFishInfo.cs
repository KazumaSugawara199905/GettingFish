using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayFishInfo : MonoBehaviour
{
    FishStatusData    fishData;
    public GameObject fishImage;
    public GameObject fishName;

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    public void SetFishData(FishStatusData fishData)
    {
        this.fishData = fishData;
        fishImage.GetComponent<Image>().sprite = fishData.GetFishImage();
        fishName.GetComponent<Text>().text     = fishData.GetFishName();
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
