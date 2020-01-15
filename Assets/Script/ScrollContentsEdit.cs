using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollContentsEdit : MonoBehaviour
{
    public GameObject    panelPrefabs;
    GameObject           playerData;
    PlayerData           playerDataScript;
    DataList             dataListScript;
    List<FishStatusData> fishDatas;



    void Start()
    {
        playerData       = GameObject.Find("PlayerData");
        playerDataScript = playerData.GetComponent<PlayerData>();
        dataListScript   = playerData.GetComponent<DataList>();
        fishDatas        = new List<FishStatusData>();

        //持っている魚のみ取得
        for(int i = 0; i < dataListScript.fishList.Count; i++)
        {
            if (playerDataScript.HaveFish(dataListScript.fishList[i].name))
            {
                fishDatas.Add(dataListScript.GetFish(dataListScript.fishList[i].name));
            }
        }

        Debug.Log(fishDatas.Count);


        //売却用のパネルを生成
        if (fishDatas.Count != 0) {
            for (int i = 0; i <fishDatas.Count;i++)
            {
                GameObject obj = Instantiate(panelPrefabs, Vector3.zero, Quaternion.identity);
                //魚のデータをパネルに渡す
                obj.GetComponent<SaleFish>().fishData = fishDatas[i];
                //Contentの子オブジェクトにする
                obj.GetComponent<RectTransform>().SetParent(transform);
                //大きさを1に
                obj.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            }
        }
        
    }

    void Update()
    {
        
    }
}
