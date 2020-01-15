using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSizeOptimise : MonoBehaviour
{
    public Sprite fishSprite;

    private void Awake()
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = fishSprite.bounds.size;
    }
}
