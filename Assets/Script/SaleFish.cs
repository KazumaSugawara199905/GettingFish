using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaleFish : MonoBehaviour
{
    public GameObject _fishImage;
    public GameObject _sellAmount;
    public GameObject _fishPrice;
    public GameObject _sellMoney;
    public FishStatusData fishData;

    Image fishImage;
    GameObject playerData;
    PlayerData playerDataScript;

    int sellAmount;      //売却個数
    int fishAmount;      //現在の魚の数

    void Start()
    {
        playerData       = GameObject.Find("PlayerData");
        playerDataScript = playerData.GetComponent<PlayerData>();
        sellAmount       = 0;
        fishAmount       = playerDataScript.GetFishAmount(fishData.GetFishName(), HaveFishType.TYPE_KILLED);
        fishImage        = _fishImage.GetComponent<Image>();
        fishImage.sprite = fishData.GetFishImage();

        _fishPrice.GetComponent<Text>().text = fishData.GetFishPrice().ToString() + "円";
    }

    void Update()
    {
        _sellAmount.GetComponent<Text>().text = sellAmount.ToString() + "匹 / " + fishAmount.ToString() + "匹";
        _sellMoney.GetComponent<Text>().text  = (sellAmount * fishData.GetFishPrice()).ToString() + "円";
    }

    public void IncreaseSellAmount()
    {
        if (sellAmount < fishAmount)
            sellAmount++;
    }

    public void DecreaseSellAmount()
    {
        if (sellAmount > 0)
            sellAmount--;
    }

    public void Sell()
    {
        fishAmount -= sellAmount;
        playerDataScript.SetFishAmount(fishData.GetFishName(), HaveFishType.TYPE_KILLED, fishAmount);
        int money = sellAmount * fishData.GetFishPrice();
        playerDataScript.IncreaseMoney(money);
        playerDataScript.SavePlayerData();
        sellAmount = 0;
    }

    public void SelectAll()
    {
        sellAmount = fishAmount;
    }

    public int GetSellMoney()
    {
        return sellAmount * fishData.GetFishPrice();
    }
}
