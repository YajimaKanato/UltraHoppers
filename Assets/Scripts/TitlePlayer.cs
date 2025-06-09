using System.Collections;
using UnityEngine;

public class TitlePlayer : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void GameStart()
    {
        animator.SetBool("Boost", true);
    }
}
