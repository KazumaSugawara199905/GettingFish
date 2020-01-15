using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "MyScriptableObject/CreateStageData")]
[System.Serializable]
public class StageData : ScriptableObject
{
    //--------------------------------
    // variables
    //--------------------------------

    public List<FishStatusData> fishDatas;
    public float maxTime;
    public float finishWaitTime;
    public float spawnSpan;
    public float spawnCoefficient;
    public float randomMax;
    public float redSpan;

    //--------------------------------
    // utilities
    //--------------------------------

    public List<FishStatusData> GetFishList()
    {
        return fishDatas;
    }

    public FishStatusData GetFishData(string name)
    {
        return fishDatas.Find(f => f.GetFishName() == name);
    }

    public float GetMaxTime()
    {
        return maxTime;
    }

    public float GetFinishWaitTime()
    {
        return finishWaitTime;
    }

    public float GetSpawnSpan()
    {
        return spawnSpan;
    }

    public float GetSpawnCoefficient()
    {
        return spawnCoefficient;
    }

    public float GetRandomMax()
    {
        return randomMax;
    }

    public float GetRedSpan()
    {
        return redSpan;
    }
}
