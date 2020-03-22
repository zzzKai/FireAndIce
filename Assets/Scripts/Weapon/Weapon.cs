using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponState
{
    melee,
    ranged
}

public class Weapon : MonoBehaviour {
    /// <summary>
    /// 武器的伤害
    /// </summary>
    public int damage = 1;
    /// <summary>
    /// 远程武器攻击间隔
    /// </summary>
    [Range(1,10)]
    public float rangedTimes=1;
    /// <summary>
    /// 远程武器子弹
    /// </summary>
    public GameObject Bullet;
    /// <summary>
    /// 远程武器的发射位置
    /// </summary>
    public Transform BulletStartPosition;

    /// <summary>
    /// 发射子弹的强度
    /// </summary>
    public int bulletForce=500;

    /// <summary>
    /// 是否点击
    /// </summary>
    public bool isClick;

    public WeaponState weaponState;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            //如果击中的是敌人发出声音
           // GameAudioManager.Instance.PlayAudio("");
            collision.gameObject.GetComponent<Enemy>().EnemyGetHurt(damage);
        }
    }

    IEnumerator WeaponFunction()
    {
        while(GameMain.Instance._gameState != GameState.End)
        {
            if (GameMain.Instance._gameState == GameState.Start)
            {
                switch (weaponState)
                {
                    case WeaponState.melee:
                        break;
                    case WeaponState.ranged:
                        while (true)
                        {
                            yield return new WaitUntil(()=>isClick==true);                          
                            Shoot();
                            isClick = false;
                            yield return new WaitForSeconds(rangedTimes);
                        }
                }
            }
            yield return new WaitForFixedUpdate();
        }
        yield break;
        
    }
    public  SteamVR_TrackedObject trackedObj;    
   

    void FixedUpdate()
    {
        var device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            isClick = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Click");
            isClick = true;
        }
    }

   


    void Shoot()
    {        //子弹发射的音效"
        GameAudioManager.Instance.PlayAudio("火球发射");
        GameObject bullet=  Instantiate(Bullet);
        bullet.transform.position = BulletStartPosition.position;
        bullet.GetComponent<Bullet>().force = BulletStartPosition.forward* bulletForce;
    }

    private void Start()
    {
       // trackdeObjec = GetComponent<SteamVR_TrackedObject>();
        StartCoroutine(WeaponFunction());
    }

}
