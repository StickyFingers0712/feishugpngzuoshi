using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Animator animator;
    private float attackcoldtime = 0;
    private bool iscolding = false;
    private float speed;
    void Update()
    {

        if (speed >= 2)
        {
            speed = 2;
        }
        if (Input.GetKey(KeyCode.W))
        {
            speed += Time.deltaTime;
            this.transform.Translate(Vector3.forward * speed * 0.02f, Space.Self);

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            speed = 0;
        }
        if (Input.GetKey(KeyCode.S))
        {
            speed += Time.deltaTime;
            this.transform.Translate(Vector3.back * speed * 0.02f, Space.Self);

        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            speed = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(Vector3.up, -25 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {

            this.transform.Rotate(Vector3.up, 25 * Time.deltaTime);
        }

        if (iscolding)
        {
            attackcoldtime += Time.deltaTime;
            if (attackcoldtime >= 1f)
            {
                iscolding = false;
                attackcoldtime = 0;
            }
        }
        animator = GetComponent<Animator>();
        if (Input.GetKeyDown(KeyCode.J) && iscolding == false)
        {
            iscolding = true;
            animator.SetTrigger("attack1");
            GameObject.Find("root").GetComponent<seekenermy>().attack = true;
        }
        if (Input.GetKeyDown(KeyCode.K) && iscolding == false)
        {
            iscolding = true;
            animator.SetTrigger("attack2");
            GameObject.Find("root").GetComponent<seekenermy>().attack = true;
        }
        animator.SetFloat("speed", speed);
    }
    public void gethit()
    {
        animator.SetTrigger("gethit");
    }
}
