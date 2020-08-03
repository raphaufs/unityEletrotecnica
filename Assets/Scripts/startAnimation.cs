using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startAnimation : MonoBehaviour
{
    public Animator animator;
    public string state;
    void Start()
    {
        //this.animator = GetComponent<Animator>();
        animator.Play(state, 0);
    }

}
