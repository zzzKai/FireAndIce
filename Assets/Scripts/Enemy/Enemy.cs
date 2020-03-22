using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    /// <summary>
    /// Enemy的目标
    /// </summary>
    public GameObject target;
    /// <summary>
    /// Enemy的速度
    /// </summary>
    public float speed=1;
    /// <summary>
    /// Enemy的血量
    /// </summary>
    public int enemyHP ;

    private NavMeshAgent agent;

    void EnemyInit()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.speed = speed;
        target = GameObject.FindGameObjectWithTag("EnemyTarget");
        enemyHP = 1;
    }


    private void Awake()
    {
        EnemyInit();
    }

    /// <summary>
    /// 敌人的行动协程
    /// </summary>
    /// <returns></returns>
    IEnumerator EnemyFunction()
    {
      //  GameAudioManager.Instance.PlayAudio("");
        //等待1秒钟
        yield return new WaitForSeconds(1);
        while(GameMain.Instance._gameState==GameState.Start)
        {
            if (enemyHP <= 0)
            {
                //播放死亡特效,播放死亡音效
              
                Destroy(this.gameObject);
                yield break;
            }
            //朝向目标移动         
            if (agent != null)
            {
                agent.SetDestination(target.transform.position);//寻路算法  
            }
            yield return new WaitForFixedUpdate();
        }
        Destroy(this.gameObject);
        yield break;
    }

    public void EnemyGetHurt(int damage)
    {
        enemyHP -= damage;       
    }   

    // Use this for initialization
    void Start () {
        StartCoroutine(EnemyFunction());
	}

    private void OnDisable()
    {
        GameEffectsManager.Instance.PlayEffect("explosion02", this.gameObject);
        GameAudioManager.Instance.PlayAudio("（小）被击倒", this.gameObject);
    }

}
       
