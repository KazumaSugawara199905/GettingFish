using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour
{
    public GameObject Panel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Panel.SetActive(true);
        }
    }
}
