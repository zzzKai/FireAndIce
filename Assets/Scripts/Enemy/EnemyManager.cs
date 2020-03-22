using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Range(2, 10)]
    public int waitTimes = 4;

    public List<Transform> _enemyStartPosition = new List<Transform>();
    public List<GameObject> _enemysList = new List<GameObject>();
    // public List<Material> _enemyMaterials = new List<Material>();

    IEnumerator EnemysLogic()
    {
        Transform temptransform;
        GameObject tempObject;
        while (GameMain.Instance._gameState != GameState.End)
        {
            if (GameMain.Instance._gameState == GameState.Start)
            {
                temptransform = _enemyStartPosition[Random.Range(0, _enemyStartPosition.Count)];
                temptransform.gameObject.SetActive(true);
                tempObject = Instantiate(_enemysList[Random.Range(0, _enemysList.Count)]);
                tempObject.transform.position = temptransform.transform.position;
                yield return new WaitForSeconds(waitTimes);
                temptransform.gameObject.SetActive(false);
            }
            yield return new WaitForFixedUpdate();

        }

        yield break;


    }
    // Use this for initialization
    void Start()
    {
        StartCoroutine(EnemysLogic());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
