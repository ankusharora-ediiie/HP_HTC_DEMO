using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    public Animator animator;
    public List<GameObject> highlightedObjects = new List<GameObject>();


    public void PlayAnimationByTrigger(string animationName)
    {
        animator.SetTrigger(animationName);
    }

    public void PlayAnimationByName(string animation)
    {
        animator.Play(animation);
    }

    public void EnableColliders()
    {
        for (int i = 0; i < highlightedObjects.Count; i++)
        {
            highlightedObjects[i].GetComponent<BoxCollider>().enabled = true;
        }
    }
}
