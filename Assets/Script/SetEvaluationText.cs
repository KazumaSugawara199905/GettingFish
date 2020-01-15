using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetEvaluationText : MonoBehaviour
{
    public GameObject evaluationText;
    public float      displayTime;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetActiveAndObject(string text)
    {
        evaluationText.GetComponent<Text>().text = text;
        gameObject.SetActive(true);
        StartCoroutine(SetActiveCoroutine());
    }

    IEnumerator SetActiveCoroutine()
    {
        yield return new WaitForSeconds(displayTime);
        gameObject.SetActive(false);
    }
}
