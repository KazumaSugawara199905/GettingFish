using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptableObject/CreateLanceData")]
public class LanceStatusData : ScriptableObject
{
    public new string name;
    public Sprite     lanceImage;
    public int        equipmentPrice;
    public float      moveSpeed;
    public int        fishMax;

    [Header("TYPE_LANCE:敵を突く。魚の生け捕り不可")]
    [Header("TYPE_HAND:敵をつかむ。魚の生け捕り可")]
    [Header("TYPE_LANCE:敵を捕まえる。魚の生け捕り可")]
    public LanceType lanceType;
    public int       penetration;

    private bool isBought;
    public bool IsBought
    {
        get { return isBought; }
        set { isBought = value; }
    }

    private void Awake()
    {
        if (PlayerPrefs.HasKey("isBought" + name))
            isBought = System.Convert.ToBoolean(PlayerPrefs.GetString("isBought" + name));
        else
            isBought = false;
    }

    public void SaveLance()
    {
        PlayerPrefs.SetString("isBought" + name, isBought.ToString());
        PlayerPrefs.Save();
    }


    public string GetEquipmentName()
    {
        return name;
    }

    public Sprite GetLanceImage()
    {
        return lanceImage;
    }

    public int GetEquipmentPrice()
    {
        return equipmentPrice;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public int GetFishMax()
    {
        return fishMax;
    }

    public LanceType GetLanceType()
    {
        return lanceType;
    }

    public int GetPenetration()
    {
        return penetration;
    }
}

/// <summary>
/// 装備の種類
/// ・TYPE_LANCE:敵を突く。相手は死ぬ。
/// ・TYPE_HAND:敵をつかむ。相手は生きる。
/// ・TYPE_NET:敵を捕まえる。相手は生きる。
/// </summary>
[System.Serializable]
public enum LanceType
{
    TYPE_NULL,
    TYPE_LANCE,
    TYPE_HAND,
    TYPE_NET,
}
