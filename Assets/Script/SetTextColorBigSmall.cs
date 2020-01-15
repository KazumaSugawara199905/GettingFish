using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextColorBigSmall : MonoBehaviour
{
    public GameObject refText;

    void Start()
    {
        Color textColor = new Color(0, 0, 0);

        int value    = System.Convert.ToInt32(gameObject.GetComponent<Text>().text);
        int refValue = System.Convert.ToInt32(refText.GetComponent<Text>().text);

        if (value > refValue)
        {
            textColor.g = 1.0f;
        }
        else if(value < refValue)
        {
            textColor.r = 1.0f;
        }

        gameObject.GetComponent<Text>().color = textColor;
    }
}
