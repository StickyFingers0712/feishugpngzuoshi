using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gethit : MonoBehaviour
{
    private Animator animator;
    void Update()
    {
        animator = GetComponent<Animator>();
    }
    public void behit()
    {
        animator.SetTrigger("gethit");
    }
}
