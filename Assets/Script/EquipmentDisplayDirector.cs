using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentDisplayDirector : MonoBehaviour
{
    public GameObject clImage;
    public GameObject clFishMax;
    public GameObject clSpeed;
    public GameObject clPenetration;
    GameObject        nlImage;
    GameObject        nlFishMax;
    GameObject        nlSpeed;
    GameObject        nlPenetration;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetText(LanceStatusData data)
    {
        GameObject _pData    = GameObject.Find("PlayerData");
        PlayerData _pdScript = _pData.GetComponent<PlayerData>();
        LanceStatusData _ld  = _pdScript.GetLance();

        clImage.GetComponent<Image>().sprite    = _ld.GetLanceImage();
        clFishMax.GetComponent<Text>().text     = _ld.GetFishMax().ToString();
        clSpeed.GetComponent<Text>().text       = _ld.GetMoveSpeed().ToString();
        clPenetration.GetComponent<Text>().text = _ld.GetPenetration().ToString();

        nlImage.GetComponent<Image>().sprite    = data.GetLanceImage();
        nlFishMax.GetComponent<Text>().text     = data.GetFishMax().ToString();
        nlSpeed.GetComponent<Text>().text       = data.GetMoveSpeed().ToString();
        nlPenetration.GetComponent<Text>().text = data.GetPenetration().ToString();

        gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

}
