using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetImage : MonoBehaviour
{
    public FishType type;
    FishStatusData  fishData;
    Image           fishImage;

    void Start()
    {
        fishData         = GameDirector.GetFishData().Find(f => f.GetFishType() == type);
        fishImage        = gameObject.GetComponent<Image>();
        fishImage.sprite = fishData.GetFishImage();
    }
}
