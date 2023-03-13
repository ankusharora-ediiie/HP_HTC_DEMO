using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsEvents : MonoBehaviour
{
    Animator animator;
    public GameObject Aruba_Server;
    public GameObject Next_Button;
    public List<GameObject> highlightedObjects = new List<GameObject>();

    public List<GameObject> partsToDisable = new List<GameObject>();
    public GameObject exploreModeObject;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void EnableGameObject()
    {
        if (Aruba_Server != null && Next_Button != null)
        {
            Aruba_Server.SetActive(true);
            Next_Button.SetActive(true);
        }
    }

    void DisableGameObject()
    {
        if (Next_Button != null) Next_Button.SetActive(false);
    }

    void EnableHighlight()
    {
        for (int i = 0; i < highlightedObjects.Count; i++)
        {
            highlightedObjects[i].GetComponent<BoxCollider>().enabled = true;
        }
    }

    void EnableExploreModeObject()
    {
        exploreModeObject.SetActive(true);
        for (int i = 0; i < partsToDisable.Count; i++)
        {
            partsToDisable[i].SetActive(false);
        }

    }

   
}