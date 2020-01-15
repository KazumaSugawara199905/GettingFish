using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public FishType type;
    FishStatusData fishData;
    int            fishAmount;

    void Start()
    {
        fishData = GameDirector.GetFishData().Find(f => f.GetFishType() == type);

        fishAmount = CalcPoint.GetCaughtFish(fishData.GetFishName());

        SetText(this.gameObject, fishAmount);
    }

    void SetText(GameObject gameObject, int amount)
    {
        gameObject.GetComponent<Text>().text = "× " + amount;
    }
}
