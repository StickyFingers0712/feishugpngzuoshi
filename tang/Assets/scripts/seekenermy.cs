using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seekenermy : MonoBehaviour
{
    public  List<GameObject> list = new List<GameObject>();
    public bool attack = false;
    void Update()
    {
        if(attack)
        {
            for(int i=0;i<list.Count;i++)
            {
                gethit gethit = list[i].GetComponent<gethit>();
                gethit.behit();
            }
            attack = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "monster")
        {
            list.Add(other.gameObject);
            Debug.Log("777");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="monster")
        {
            list.Remove(other.gameObject);
        }
      
    }
}
