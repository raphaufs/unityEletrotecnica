using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startAnimation : MonoBehaviour
{
    public Animator animator;
    public string state;
    void Start()
    {
        animator.Play(state, 0);
    }

}
