using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowExploreParts : MonoBehaviour
{

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ShowParts(string trigger)
    {
        animator.SetTrigger(trigger);
    }
}
