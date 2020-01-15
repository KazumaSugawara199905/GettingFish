using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="MyScriptableObject/CreateFishData")]
[System.Serializable]
public class FishStatusData : ScriptableObject
{
    public new string name;
    public Sprite     fishImage;
    public FishType   fishType;
    public int        fishPrice;
    public GameObject fishPrefab;
    public int        defPower;

    bool              haveFish;
    int               totalFishAmount;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("total" + name + "Amount"))
            totalFishAmount = PlayerPrefs.GetInt("total" + name + "Amount");
        else
            totalFishAmount = 0;
    }

    public bool GetHaveFishFlag()
    {
        if (totalFishAmount > 0)
        {
            haveFish = true;
        }
        else
        {
            haveFish = false;
        }
        return haveFish;
    }

    public string GetFishName()
    {
        return name;
    }

    public FishType GetFishType()
    {
        return fishType;
    }

    public GameObject GetFishPrefabs()
    {
        return fishPrefab;
    }

    public Sprite GetFishImage()
    {
        return fishImage;
    }

    public int GetFishPrice()
    {
        return fishPrice;
    }

    public int GetDefPower()
    {
        return defPower;
    }

    public void IncreaseTotalAmount(int value)
    {
        totalFishAmount += value;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("total" + name + "Amount", totalFishAmount);
        PlayerPrefs.Save();
    }
}

[System.Serializable]
public enum FishType
{
    FISH_NULL,
    FISH_S,
    FISH_M,
    FISH_L,
    FISH_R,
}

[System.Serializable]
public enum HaveFishType
{
    TYPE_NULL,
    TYPE_KILLED,
    TYPE_PICKED,
}