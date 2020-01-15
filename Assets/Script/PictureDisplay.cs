using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PictureDisplay : MonoBehaviour
{
    public GameObject infoPanel;
    public FishStatusData fishData;
    public Sprite fishUnknown;
    public GameObject imageObj;
    public Text fishNameText;
    public GameObject textUnknown;
    Image fishImage;

    private void Start()
    {
        fishImage = imageObj.GetComponent<Image>();

        if (fishData.GetHaveFishFlag())
        {
            fishImage.sprite = fishData.GetFishImage();
            fishNameText.GetComponent<Text>().text = fishData.GetFishName();
        }
        else
        {
            fishImage.sprite = fishUnknown;
            fishNameText.GetComponent<Text>().text = " ? ? ? ";
        }
    }

    public void DisplayInfo()
    {
        if (fishData.GetHaveFishFlag())
        {
            infoPanel.GetComponent<DisplayFishInfo>().SetFishData(fishData);
            infoPanel.SetActive(true);
        }
        else
        {
            StartCoroutine(DisplayCoroutine());
        }
    }

    IEnumerator DisplayCoroutine()
    {
        textUnknown.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        textUnknown.SetActive(false);
    }
}
