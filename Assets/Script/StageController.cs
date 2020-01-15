using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    public GameObject Panel;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Panel.SetActive(true);
            //Debug.Log("OnTrigger");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Panel.SetActive(false);
        }
    }
}
