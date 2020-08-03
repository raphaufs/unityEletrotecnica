using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startAnimation : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        this.animator = this.GetComponent<Animator>();
        this.animator.Play("cutscene_Stage1c", 0);
    }

}
