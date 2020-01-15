using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPrefs : MonoBehaviour
{

    public void DeleteAllPrefs()
    {
        PlayerDataInstance _pIt = PlayerDataInstance.Instance;
        _pIt.Delete();
        PlayerPrefs.DeleteAll();
    }
}
