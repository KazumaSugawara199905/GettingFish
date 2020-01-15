using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellFishAll : MonoBehaviour
{
    public GameObject allMoneyText;

    GameObject[]      panelObjects;


    void Start()
    {
        panelObjects = GameObject.FindGameObjectsWithTag("SellPanel");
    }

    // Update is called once per frame
    void Update()
    {
        int moneyAll = 0;
        for (int i = 0; i < panelObjects.Length; i++)
        {
            moneyAll += panelObjects[i].GetComponent<SaleFish>().GetSellMoney();
        }
        allMoneyText.GetComponent<Text>().text = moneyAll.ToString() + "円";
    }

    public void SellAll()
    {
        for(int i = 0; i < panelObjects.Length; i++)
        {
            panelObjects[i].GetComponent<SaleFish>().Sell();
        }
    }
}
