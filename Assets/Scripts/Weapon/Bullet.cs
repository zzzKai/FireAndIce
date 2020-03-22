using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Vector3 force;
    public GameObject DeadEffect;

    public int damage=1;

    private void Awake()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            //子弹撞击到敌人后的效果
            //GameAudioManager.Instance.PlayAudio();
            //GameEffectsManager.Instance.PlayEffect();

            collision.gameObject.GetComponent<Enemy>().EnemyGetHurt(damage);
        }
    }

    void BulletFunction()
    {
        GetComponent<Rigidbody>().AddForce(force);
        Destroy(gameObject, 1.5f);
    }

    // Use this for initialization
    void Start () {
        BulletFunction();
    }

    private void OnDisable()
    {
        GameObject game= Instantiate(DeadEffect);
        game.transform.position = gameObject.transform.position;
    }
}
