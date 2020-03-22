using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    void OnCollisionEnter(Collision collision)
    {
         Destroy(gameObject);
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.J))
        {
            AudioSource shootsound = GameObject.Find("Sphere").GetComponent<AudioSource>();
            shootsound.Play();
        }


    }
}
