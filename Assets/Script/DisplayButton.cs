using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayButton : MonoBehaviour
{
    public GameObject SelectPanel;

    public void OnClick()
    {
        SelectPanel.SetActive(true);
    }
}
