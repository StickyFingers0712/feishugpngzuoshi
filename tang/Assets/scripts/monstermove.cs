using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monstermove : MonoBehaviour
{
    private Animator animator;
    private float speed=0;
    private bool active=false;
    public GameObject player;
    private float juli;
    private bool iscolding=false;
    private float coldingtime;
    private float misstime=0;
    private bool ismissing=false;
    void Update()
    {

        animator = GetComponent<Animator>();
        animator.SetFloat("speed", speed);
        if(active)
        {
            juli = (transform.position - player.transform.position).magnitude;
            transform.LookAt(player.transform.position);
            speed += Time.deltaTime;
            if(juli<=1.6f && iscolding==false)
            {
                animator.SetTrigger("attack");
                ismissing = true;
                iscolding = true;
            }
            if(ismissing)
            {
                misstime += Time.deltaTime;
                if(juli<2  && misstime>0.5f)
                {
                    GameObject.Find("player").GetComponent<move>().gethit();
                    misstime = 0;
                    ismissing = false;
                }
            }
            if(iscolding)
            {
                coldingtime += Time.deltaTime;
                if(coldingtime>=4f)
                {
                    iscolding = false;
                    coldingtime = 0;
                }
            }
          if(speed>1.2f)
            {
                speed = 1.2f;
            }
          if(juli>1.6f)
            {
                transform.Translate(Vector3.forward * speed * 0.02f, Space.Self);
            }
           
        }
    }
    public void gethit()
    {
        animator.SetTrigger("gethit");
    }
    private void OnTriggerStay(Collider other)
    {
    
        if(other.tag=="player")
        {
            active = true;
          
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "player")
        {
            active = false;
            speed = 0;
        }
    }
}
