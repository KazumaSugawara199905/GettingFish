using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyController : MonoBehaviour
{
    LanceStatusData lanceStatusData;
    GameObject playerData;
    PlayerData playerDataScript;

    public GameObject lanceImage;
    public GameObject nameText;
    public GameObject speedText;
    public GameObject getNumberText;
    public GameObject penetrationText;
    public GameObject buyButton;
    public GameObject equipmentSelectPanel;
    public GameObject notDisplayPanel;
    public GameObject confirmationPanel;

    public Transform purchasedImage;

    Image displayImage;

    // Start is called before the first frame update
    void Start()
    {
        playerData = GameObject.Find("PlayerData");
        playerDataScript = playerData.GetComponent<PlayerData>();
        //lanceStatusData = playerDataScript.GetLance();
        //Debug.Log(lance);
    }

    // Update is called once per frame
    void Update()
    {
        displayImage = lanceImage.GetComponent<Image>();
        displayImage.sprite = lanceStatusData.GetLanceImage();

        nameText.GetComponent<Text>().text        = lanceStatusData.GetEquipmentName().ToString();
        speedText.GetComponent<Text>().text       = "速さ：" + lanceStatusData.GetMoveSpeed().ToString();
        getNumberText.GetComponent<Text>().text   = "とれる数：" + lanceStatusData.GetFishMax().ToString();
        penetrationText.GetComponent<Text>().text = "貫通力：" + lanceStatusData.GetPenetration().ToString();
     //   if (playerDataScript.GetMoney() < lanceStatusData.GetEquipmentPrice())
       // {
         //   buyButton.SetActive(false);
        //}
    }

    public void SetLanceData(LanceStatusData lance)
    {
        lanceStatusData = lance;
    }

    public void Buy()
    {
        if (lanceStatusData.GetEquipmentPrice() <= playerDataScript.GetMoney())
        {
            lanceStatusData.IsBought = true;
            playerDataScript.SetLance(lanceStatusData);
            playerDataScript.DecreaseMoney(lanceStatusData.GetEquipmentPrice());
            playerDataScript.SavePlayerData();
            confirmationPanel.SetActive(true);
        }
        
        notDisplayPanel.SetActive(false);
    }

    public void OnClick()
    {
        notDisplayPanel.SetActive(false);
    }

    public void Purchased()
    {
     //   purchasedImage.GetChild(3).gameObject.SetActive(true);
      //  purchasedImage.GetChild(2).gameObject.SetActive(false);
        confirmationPanel.SetActive(false);
    }
}