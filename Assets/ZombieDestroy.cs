using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDestroy : MonoBehaviour
{
    public GameObject tx1;
    public GameObject tx2;
    public Transform BPoint;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /* void OnCollisionEnter(Collision collision)
     {
         string name = collision.gameObject.name;
         Debug.Log(name);
         Destroy(gameObject);
     }*/
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        GameObject TX2;
        TX2 = GameObject.Find("tx2");
        GameObject prefabInstance = Instantiate(tx2, BPoint.position, BPoint.rotation);
        prefabInstance.transform.parent = TX2.transform;
    }
}