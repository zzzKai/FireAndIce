using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour {

    public Text _gameTitel, _gameDescription;
    public GameObject StartUI;

    void Init()
    {
        //游戏的名称
        _gameTitel.text = "Fire and Ice";
        //游戏的介绍和玩法
        _gameDescription.text = "Use your powers to defend yourself!";
    }
	// Use this for initialization
	void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {

        switch (GameMain.Instance._gameState)
        {
            case GameState.Init:
                StartUI.SetActive(true);
                break;
            case GameState.Start:
                StartUI.SetActive(false);
                break;
            case GameState.End:
                break;
            default:
                break;  
        }
    }
}
