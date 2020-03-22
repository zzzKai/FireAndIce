using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolTime : MonoBehaviour {
    public float fireTime;  //开火时间
    public float coolTime;  //冷却时间
    
        // Use this for initialization
        void Start () {
        coolTime = 0.5f;
    }
	
	// Update is called once per frame
	void Update () {
        if (fireTime < coolTime)
        {
            fireTime += Time.deltaTime;
        }

        if (fireTime > coolTime)
        {
            fireTime = coolTime;
        }
        // 当按下J键 && fireTime == coolTime 才可以触发开火  
        if (Input.GetKey(KeyCode.J) && fireTime == coolTime)
        {
            fireTime = 0;
        }

    }
}

