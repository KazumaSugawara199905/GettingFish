using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayerData : MonoBehaviour
{
    public GameObject lanceImage;
    public GameObject moneyText;

    GameObject playerData;
    PlayerData playerDataScript;

    private void Start()
    {
        playerData = GameObject.Find("PlayerData");
        playerDataScript = playerData.GetComponent<PlayerData>();

        lanceImage.GetComponent<Image>().sprite = playerDataScript.GetLance().GetLanceImage();
        moneyText.GetComponent<Text>().text     = "所持金 = " + playerDataScript.GetMoney().ToString();
    }
}
