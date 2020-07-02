using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startAnimation : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator.Play("Entry");
    }

}
