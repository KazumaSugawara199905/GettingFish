using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSetUpView : MonoBehaviour
{
    public GameObject     panelPrefabs;
    public GameObject     equipmentSetPanel;
    public GameObject     noChangeText;

    GameObject            playerData;
    PlayerData            playerDataScript;
    DataList              dataListScript;
    List<LanceStatusData> lanceDatas;



    void Start()
    {
        playerData       = GameObject.Find("PlayerData");
        playerDataScript = playerData.GetComponent<PlayerData>();
        dataListScript   = playerData.GetComponent<DataList>();
        lanceDatas       = new List<LanceStatusData>();

        //買った銛のみ取得
        for (int i = 0; i < dataListScript.lanceList.Count; i++)
        {
            if (dataListScript.lanceList[i].IsBought)
            {
                lanceDatas.Add(dataListScript.GetLance(dataListScript.lanceList[i].name));
            }
        }
        //売却用のパネルを生成
        if (lanceDatas.Count != 0)
        {
            for (int i = 0; i < lanceDatas.Count; i++)
            {
                GameObject obj = Instantiate(panelPrefabs, Vector3.zero, Quaternion.identity);
                //銛のデータをパネルに渡す
                obj.GetComponent<SetEquipment>().LanceData = lanceDatas[i];
                //装備変更用のポップアップパネルを渡す
                obj.GetComponent<SetEquipment>().SetPanel(equipmentSetPanel, noChangeText);
                //Contentの子オブジェクトにする
                obj.GetComponent<RectTransform>().SetParent(transform);
                //大きさを1に
                obj.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            }
        }

    }
}
