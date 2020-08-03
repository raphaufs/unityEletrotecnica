using UnityEngine;
using UnityEngine.SceneManagement;
public class startAnimation : MonoBehaviour
{
    public Animator animator;
    public string state;
    void Start()
    {
        animator.Play(state, 0);

    }
}
