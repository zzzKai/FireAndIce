using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {
    int Speed = 20;
    public Rigidbody Bullet;
    public Transform Fpoint;


    public float fireTime=0.5f;  //开火时间
    public float coolTime=0.5f;  //冷却时间

    // Use this for initialization
    void Start()
    {
        
    }

    bool canshoot()
    {
        if (fireTime <= coolTime)
        {
            fireTime += Time.deltaTime;
        }
        if (fireTime > coolTime&& Input.GetKey(KeyCode.J))
        {
            fireTime = 0;
            return true;
        }

        return false;
       
    }

	// Update is called once per frame
	void Update () {
        if (canshoot())
        {
            Rigidbody clone;
            GetComponent<triggerProjectile>().shoot();
            clone = (Rigidbody)Instantiate(Bullet, Fpoint .position, Fpoint .rotation);
            clone.velocity = transform.TransformDirection(Vector3.forward * 50);
        }
    }
}
