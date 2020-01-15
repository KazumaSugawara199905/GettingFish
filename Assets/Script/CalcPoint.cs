using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcPoint : MonoBehaviour
{
    public List<FishStatusData> fishDatas;
    LanceStatusData             lanceData;
    GameObject                  playerData;
    PlayerData                  playerDataScript;
    DataList                    dataListScript;
    static CaughtFish[]         caughtFish;
    struct CaughtFish
    {
        string       name;
        FishType     fishType;
        int          amount;
        HaveFishType haveFishType;

        public void SetHaveFishType(HaveFishType typeValue)
        {
            haveFishType = typeValue;
        }

        public void IncreaseAmount(int value)
        {
            amount += value;
        }

        public void SetFishType(FishType typeValue)
        {
            fishType = typeValue;
        }

        public void SetFishName(string name)
        {
            this.name = name;
        }

        public int GetAmount()
        {
            return amount;
        }

        public HaveFishType GetHaveFishType()
        {
            return haveFishType;
        }

        public string GetFishName()
        {
            return name;
        }
    }

    void Start()
    {
        playerData       = GameObject.Find("PlayerData");
        playerDataScript = playerData.GetComponent<PlayerData>();
        dataListScript   = playerData.GetComponent<DataList>();
        lanceData        = playerDataScript.GetLance();

        caughtFish = new CaughtFish[fishDatas.Count];

        HaveFishType fishTypeValue;
        switch (lanceData.GetLanceType())
        {
            case LanceType.TYPE_LANCE:
                fishTypeValue = HaveFishType.TYPE_KILLED;
                break;
            case LanceType.TYPE_HAND:
            case LanceType.TYPE_NET:
                fishTypeValue = HaveFishType.TYPE_PICKED;
                break;
            default:
                Debug.Log("LanceType is TYPE_NULL or other error");
                fishTypeValue = HaveFishType.TYPE_NULL;
                break;
        }

        for (int i = 0; i < fishDatas.Count; i++)
        {
            caughtFish[i].SetHaveFishType(fishTypeValue);
            caughtFish[i].SetFishType(fishDatas[i].GetFishType());
            caughtFish[i].SetFishName(fishDatas[i].GetFishName());
        }

        Debug.Log(caughtFish);
    }

    public void AddPoint(GameObject gameObject)
    {
        for(int i=0; i < fishDatas.Count; i++)
        {
            if(gameObject.transform.tag == fishDatas[i].GetFishType().ToString())
            {
                caughtFish[i].IncreaseAmount(1);
                fishDatas[i].IncreaseTotalAmount(1);
            }
        }
    }

    public void SavePoint()
    {
        for(int i = 0; i < fishDatas.Count; i++)
        {
            if (caughtFish[i].GetAmount() > 0)
            {
                playerDataScript.SetFish(fishDatas[i]);
                playerDataScript.SetFishAmount(fishDatas[i].GetFishName(), caughtFish[i].GetHaveFishType(), caughtFish[i].GetAmount());
            }
            fishDatas[i].Save();
        }
    }

    public static int GetCaughtFish(string name)
    {
        int _amount = -1;
        for(int i = 0; i < caughtFish.Length;i++)
        {
            if(caughtFish[i].GetFishName() == name)
            {
                _amount = caughtFish[i].GetAmount();
            }
        }
        return _amount;
    }
}
