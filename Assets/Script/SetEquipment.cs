using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetEquipment : MonoBehaviour
{
    private LanceStatusData _ld;

    public LanceStatusData LanceData
    {
        get
        {
            return _ld;
        }
        set
        {
            _ld = value;
        }
    }

    public GameObject image;
    public GameObject nameText;
    public GameObject data1Text;
    public GameObject data2Text;
    public GameObject data3Text;

    [Header("装備中の銛を選択したときのテキストの表示時間")]
    public float      activeTime;

    GameObject        playerData;
    PlayerData        playerDataSctipt;
    GameObject        equipmentSetPanel;
    GameObject        isSameText;

    // Start is called before the first frame update
    void Start()
    {
        playerData                          = GameObject.Find("PlayerData");
        playerDataSctipt                    = playerData.GetComponent<PlayerData>();

        image.GetComponent<Image>().sprite  = LanceData.GetLanceImage();
        nameText.GetComponent<Text>().text  = "名前：" +  _ld.GetEquipmentName();
        data1Text.GetComponent<Text>().text = "速さ：" + _ld.GetMoveSpeed().ToString();
        data2Text.GetComponent<Text>().text = "最大取得数：" + _ld.GetFishMax().ToString();
        data3Text.GetComponent<Text>().text = "貫通力：" + _ld.GetPenetration().ToString();
    }

    public void SetLance()
    {
        playerDataSctipt.SetLance(LanceData);
    }

    public void SetPanelActive()
    {
        GameObject _pData    = GameObject.Find("PlayerData");
        PlayerData _pdScript = _pData.GetComponent<PlayerData>();
        LanceStatusData _ld  = _pdScript.GetLance();

        if (LanceData == _ld)
        {
            StartCoroutine(SetActiveCoroutine(isSameText));
            return;
        }

        EquipmentDisplayDirector eddScript = equipmentSetPanel.GetComponent<EquipmentDisplayDirector>();
        eddScript.SetText(LanceData);
    }

    public void SetPanel(GameObject panel, GameObject isSame)
    {
        equipmentSetPanel = panel;
        isSameText        = isSame;
    }

    IEnumerator SetActiveCoroutine(GameObject obj)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(activeTime);
        obj.SetActive(false);
    }
}
