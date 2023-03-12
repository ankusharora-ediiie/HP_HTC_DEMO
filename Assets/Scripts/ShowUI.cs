using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public List<GameObject> list = new List<GameObject>();
    public int count = 0;

    public void ShowUIAfterAnimationComplete()
    {
        foreach (GameObject go in list)
        {
            go.SetActive(false);
        }

        list[count].SetActive(true);
        count++;    
    }

    public void DisablePreviousUI()
    {
        foreach (GameObject go in list)
        {
            go.SetActive(false);
        }
    }
}
