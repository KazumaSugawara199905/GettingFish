using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuySelect : MonoBehaviour
{
    BuyController buyControllerScript;

    public GameObject _equipmentImage;
    public GameObject price;
    public GameObject buyButton;
    public GameObject panel;

    public LanceStatusData lanceStatusData;

    Image equipmentImage;

    void Start()
    {
    //    panel = GameObject.Find("EquipmentBuyPanel");
        buyControllerScript = panel.GetComponent<BuyController>();

        equipmentImage = _equipmentImage.GetComponent<Image>();
        equipmentImage.sprite = lanceStatusData.GetLanceImage();

        price.GetComponent<Text>().text = lanceStatusData.GetEquipmentPrice().ToString() + "円";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplayBuyPanel()
    {
        buyControllerScript.SetLanceData(lanceStatusData);
        panel.SetActive(true);
    }
}