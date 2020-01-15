using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;

[Serializable]
public class PlayerData : MonoBehaviour
{
    //================================================
    //PlayerDataVariable
    //================================================

    public LanceStatusData   lance;
    [SerializeField]
    int                      money;
    Dictionary<string, Fish> fishes;
    DataList                 dataList;

    //================================================
    //PlayerDataUtility
    //================================================

    private void Start()
    {
        //保存しておいたデータを取得する
        PlayerDataInstance _pInstance = PlayerDataInstance.Instance;
        dataList                      = gameObject.GetComponent<DataList>();

        string lanceName = _pInstance.GetLanceName();

        //初期状態だとlanceNameが""なので、初期装備を設定
        //lanceNameが存在するなら該当する装備を取得
        if (lanceName == "")
        {
            lance          = dataList.GetLance("ボロのモリ");
            lance.IsBought = true;
        }
        else
        {
            lance = dataList.GetLance(lanceName);
        }
        money  = _pInstance.GetMoney();
        fishes = _pInstance.GetFish();
    }



    ///<summary>
    ///取得した魚のデータを保存。
    ///すでにList上に存在する場合は保存せず返す。
    ///</summary>
    public void SetFish(FishStatusData fishData)
    {
        //魚のデータがすでに存在するか検索
        //無ければ追加、有ればそのまま返す。
        if (fishes.ContainsKey(fishData.GetFishName()))
        {
            return;
        }
        else
        {
            Fish fish             = new Fish();
            fish.HaveKilledAmount = 0;
            fish.HavePickedAmount = 0;
            fishes.Add(fishData.GetFishName(), fish);
        }
    }


    /// <summary>
    /// 所持金を増やす。
    /// </summary>
    /// <param name="value"></param>
    public void IncreaseMoney(int value)
    {
        money += value;
    }

    /// <summary>
    /// 所持金を減らす。
    /// </summary>
    /// <param name="value"></param>
    public void DecreaseMoney(int value)
    {
        money -= value;
    }

    /// <summary>
    /// 所持金を設定する。
    /// </summary>
    /// <param name="value"></param>
    public void Setmoney(int value)
    {
        money = value;
    }

    /// <summary>
    /// 所持金を取得する。
    /// </summary>
    /// <returns></returns>
    public int GetMoney()
    {
        return money;
    }

    /// <summary>
    /// 装備品を設定する。
    /// </summary>
    /// <param name="lanceData"></param>
    public void SetLance(LanceStatusData lanceData)
    {
        lance = lanceData;
    }

    /// <summary>
    /// 装備品を取得する。
    /// </summary>
    /// <returns></returns>
    public LanceStatusData GetLance()
    {
        return lance;
    }


    /// <summary>
    /// 名前がnameの魚がいるか
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public bool HaveFish(string name)
    {
        return fishes.ContainsKey(name);
    }

    /// <summary>
    /// 売却用、水槽用の魚の数を取得する。
    /// </summary>
    /// <param name="name"></param>
    /// <param name="typeValue"></param>
    /// <returns></returns>
    public int GetFishAmount(string name, HaveFishType typeValue)
    {
        int amount;
        switch (typeValue)
        {
            case HaveFishType.TYPE_KILLED:
                amount = fishes[name].HaveKilledAmount;
                break;
            case HaveFishType.TYPE_PICKED:
                amount = fishes[name].HavePickedAmount;
                break;
            default:
                amount = -1;
                Debug.Log("There is no fishData");
                break;
        }
        return amount;
    }

    /// <summary>
    /// 売却用、水槽用を分けて魚の所持数を設定する。
    /// </summary>
    /// <param name="name"></param>
    /// <param name="typeValue"></param>
    /// <param name="value"></param>
    public void SetFishAmount(string name, HaveFishType typeValue, int value)
    {
        switch (typeValue)
        {
            case HaveFishType.TYPE_KILLED:
                fishes[name].HaveKilledAmount = value;
                break;
            case HaveFishType.TYPE_PICKED:
                fishes[name].HavePickedAmount = value;
                break;
            default:
                Debug.Log("There is no fishData");
                break;
        }
    }

    public Dictionary<string,Fish> GetFish()
    {
        return fishes;
    }


    public void SavePlayerData()
    {
        PlayerDataInstance.Instance.SetPlayerData(this);
        PlayerDataInstance.Instance.Save();
    }
}

[Serializable]
public class Fish
{
    private int   _haveKilledAmount;
    private int   _havePickedAmount;

    public int HaveKilledAmount
    {
        get
        {
            return _haveKilledAmount;
        }
        set
        {
            _haveKilledAmount = value;
        }
    }

    public int HavePickedAmount
    {
        get
        {
            return _havePickedAmount;
        }
        set
        {
            _havePickedAmount = value;
        }
    }
}
