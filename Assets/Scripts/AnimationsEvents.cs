using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsEvents : MonoBehaviour
{
    Animator animator;
    public GameObject Aruba_Server;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void EnableGameObject()
    {
        Aruba_Server.SetActive(true);
    }

    void ShowText(int id)
    {
        UIPanel.instance.ShowText(id);
    }
}