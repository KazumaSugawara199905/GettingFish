using UnityEngine;
using UnityEngine.UI;

public class DisplayDirector : MonoBehaviour
{
    LanceStatusData lanceData;
    GameObject      playerData;
    PlayerData      playerDataScript;

    public GameObject moneyObj;
    public GameObject lanceImage;
    public GameObject lanceName;
    public GameObject lanceData1;
    public GameObject lanceData2;
    public GameObject lanceData3;
    int money;

    void Start()
    {
        playerData       = GameObject.Find("PlayerData");
        playerDataScript = playerData.GetComponent<PlayerData>();
        lanceData        = playerDataScript.GetLance();
        Debug.Log(lanceData);

        moneyObj.GetComponent<Text>().text      = "所持金：" + playerDataScript.GetMoney().ToString() + "円";
        lanceImage.GetComponent<Image>().sprite = lanceData.GetLanceImage();
        lanceName.GetComponent<Text>().text     = lanceData.GetEquipmentName();
        lanceData1.GetComponent<Text>().text    = "はやさ:" + lanceData.GetMoveSpeed().ToString();
        lanceData2.GetComponent<Text>().text    = "一度に取れる魚の数:" + lanceData.GetFishMax().ToString();
        lanceData3.GetComponent<Text>().text    = "貫通力：" + lanceData.GetPenetration().ToString(); 
    }
}
