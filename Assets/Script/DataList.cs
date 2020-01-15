using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataList : MonoBehaviour
{
    //public LanceStatusData[] lanceDatas;
    //public FishStatusData[] fishDatas;

    public List<LanceStatusData> lanceList;
    public List<FishStatusData> fishList;

    private void Update()
    {

    }

    public LanceStatusData GetLance(string name)
    {
        return lanceList.Find(l => l.GetEquipmentName() == name);
    }

    public FishStatusData GetFish(string name)
    {
        FishStatusData _data = fishList.Find(f => f.GetFishName() == name);
        return _data;
    }
}
