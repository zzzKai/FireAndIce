using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum GameState
{
    Init,
    Start,
    End
}

public class GameMain : MonoSingleton<GameMain> {

   
    public GameState _gameState { get; private set; }

    private void Awake()
    {
        _gameState = GameState.Init;
    }

    IEnumerator  GameStartInit()
    {
       
        yield return new WaitForSeconds(1);        
        _gameState = GameState.Start;
        Debug.Log("Start");
        yield break;
    }
    /// <summary>
    /// 游戏失败
    /// </summary>
    public void GameFail()
    {
        _gameState = GameState.End;
    }
    /// <summary>
    /// 游戏胜利
    /// </summary>
    public void GameWin()
    {
        _gameState = GameState.End;
    }

    private void Start()
    {
        StartCoroutine(GameStartInit());
    }
    #region 之前的代码
    ////各种常量----------------------------------------------------------
    ////屏幕位置常量，即生成猪的初始位置常量
    //public Vector3 Screen0Posit = new Vector3 ((float)-7.03,(float)3.92,(float)-4.47);
    //public Vector3 Screen1Posit = new Vector3 ((float)-7.03,(float)3.92,(float)-1.09);
    //public Vector3 Screen2Posit = new Vector3 ((float)-7.03,(float)3.92,(float)4.19);
    //public Vector3 Screen3Posit = new Vector3 ((float)5.12,(float)3.64,(float)7.132);
    //public Vector3 Screen4Posit = new Vector3 ((float)7.01,(float)3.81,(float)-1.32);
    //public Vector3 Screen5Posit = new Vector3 ((float)7.01,(float)3.81,(float)-5.58);

    ////生成在各屏幕位置的猪向着中心的选转常量
    //public Quaternion Screen0Rotat = Quaternion.Euler (0,(float)-32.9,0);
    //public Quaternion Screen1Rotat = Quaternion.Euler (0,(float)-7.1,0);
    //public Quaternion Screen2Rotat = Quaternion.Euler (0,(float)38.066,0);
    //public Quaternion Screen3Rotat = Quaternion.Euler (0,(float)20.57,0);
    //public Quaternion Screen4Rotat = Quaternion.Euler (0,(float)29.079,0);
    //public Quaternion Screen5Rotat = Quaternion.Euler (0,(float)38.205,0);

    ////各种变量----------------------------------------------------------
    ////时间---------------------
    //   //时间：60-0
    //public int TotalTime;

    ////时间的显示
    //public Text TimeText;

    ////时间：0-60
    //private int timeNow;

    ////上一帧的时刻
    //private int timeLast;

    ////随机数-------------------
    //private int RandPosit;//0~5
    //private int RandKind;//0/1

    ////猪的初始位置（在6个屏幕中随机一个）
    //private Vector3 PositInitPig;

    ////猪的初始旋转角度，实际上保持不变
    //private Quaternion RotatInitPig;

    ////user位置和rotation
    //public GameObject user;

    ////prefab---------------------------------------------
    ////3D的猪
    //public GameObject NewPigNormal;
    //public GameObject NewPigHard;
    ////3D的鸟
    //public GameObject NewBirdRed;

    ////图片显示--------------------------------------------
    //public GameObject PicBirdRed0;
    //public GameObject PicBirdRed1;
    //public GameObject PicBirdRed2;
    //public GameObject PicBirdRed3;
    //public GameObject PicBirdRed4;
    //public GameObject PicBirdRed5;

    //public GameObject PicPigNormal0;
    //public GameObject PicPigNormal1;
    //public GameObject PicPigNormal2;
    //public GameObject PicPigNormal3;
    //public GameObject PicPigNormal4;
    //public GameObject PicPigNormal5;

    //public GameObject PicPigHard0;
    //public GameObject PicPigHard1;
    //public GameObject PicPigHard2;
    //public GameObject PicPigHard3;
    //public GameObject PicPigHard4;
    //public GameObject PicPigHard5;


    ////各种函数-----------------------------------------------------------
    ////使图片隐藏
    //public void HidePic(GameObject Pic)
    //{
    //	Pic.transform.position = new Vector3 (50, 50, 50);
    //}

    ////计时及显示
    //public IEnumerator startTime()
    //{
    //	while (_gameState==GameState.Start) {
    //		yield return new WaitForSeconds (1);//等1秒
    //		TotalTime--;//倒数计时

    //		TimeText.text = "Time: " + TotalTime;//显示更新

    //		timeNow = 60 - TotalTime;//现在的时间，正数计时

    //		//倒计时到0时，结束游戏，胜利
    //		if (TotalTime == 0) {
    //			//结束
    //			_gameState = GameState.End;

    //			//胜利 
    //			Winn();
    //		}
    //	}
    //}

    //猪的生成
    //public void PigGen()
    //{
    //	//生成前的准备---------------------------------------------------------------
    //	//产生0~5的随机数RandPosit（猪的初始位置）
    //	RandPosit = Random.Range(0,6);

    //	//产生0/1的随机数RandKind（猪的种类）0/1-普通猪，2-头盔猪
    //	RandKind = Random.Range(0,3);

    //	//switch-case选择猪的生成位置和旋转角度（根据随机数的值）
    //	switch (RandPosit) {
    //	case 0:
    //		PositInitPig = Screen0Posit;
    //		RotatInitPig = Screen0Rotat;
    //		break;
    //	case 1:
    //		PositInitPig = Screen1Posit;
    //		RotatInitPig = Screen1Rotat;
    //		break;
    //	case 2:
    //		PositInitPig = Screen2Posit;
    //		RotatInitPig = Screen2Rotat;
    //		break;
    //	case 3:
    //		PositInitPig = Screen3Posit;
    //		RotatInitPig = Screen3Rotat;
    //		break;
    //	case 4:
    //		PositInitPig = Screen4Posit;
    //		RotatInitPig = Screen4Rotat;
    //		break;
    //	case 5:
    //		PositInitPig = Screen5Posit;
    //		RotatInitPig = Screen5Rotat;
    //		break;
    //	default:
    //		break;
    //	}

    //	//开始生成 PS:先不管时间-------------------------------------------------------------------
    //	//00 屏幕亮起音效
    //	GameAudioManager.Instance.PlayAudio ("笑声2");

    //	//05 屏幕出现猪头标志
    //	if (RandKind == 2) 
    //	{
    //		switch (RandPosit) 
    //		{
    //		case 0:
    //			PicPigHard0.transform.position = Screen0Posit;
    //			break;
    //		case 1:
    //			PicPigHard1.transform.position = Screen1Posit;
    //			break;
    //		case 2:
    //			PicPigHard2.transform.position = Screen2Posit;
    //			break;
    //		case 3:
    //			PicPigHard3.transform.position = Screen3Posit;
    //			break;
    //		case 4:
    //			PicPigHard4.transform.position = Screen4Posit;
    //			break;
    //		case 5:
    //			PicPigHard5.transform.position = Screen5Posit;
    //			break;
    //		default:
    //			break;
    //		}
    //	}
    //	else 
    //	{
    //		switch (RandPosit) 
    //		{
    //		case 0:
    //			PicPigNormal0.transform.position = Screen0Posit;
    //			break;
    //		case 1:
    //			PicPigNormal1.transform.position = Screen1Posit;
    //			break;
    //		case 2:
    //			PicPigNormal2.transform.position = Screen2Posit;
    //			break;
    //		case 3:
    //			PicPigNormal3.transform.position = Screen3Posit;
    //			break;
    //		case 4:
    //			PicPigNormal4.transform.position = Screen4Posit;
    //			break;
    //		case 5:
    //			PicPigNormal5.transform.position = Screen5Posit;
    //			break;
    //		default:
    //			break;
    //		}
    //	}


    //	//猪笑的音效
    //	//GameAudioManager.Instance.PlayAudio ("笑声2");

    //	//生成猪（猪开始运动-这个由绑在猪对象上的脚本来实现)
    //	if(RandKind == 2) Instantiate(NewPigHard,PositInitPig,RotatInitPig);
    //	else Instantiate(NewPigNormal,PositInitPig,RotatInitPig);
    //}

    ////胜利后的显示
    //void Winn()
    //{
    //	//实验室六个屏幕上显示小鸟图像
    //	PicBirdRed0.transform.position = Screen0Posit;
    //	PicBirdRed1.transform.position = Screen1Posit;
    //	PicBirdRed2.transform.position = Screen2Posit;
    //	PicBirdRed3.transform.position = Screen3Posit;
    //	PicBirdRed4.transform.position = Screen4Posit;
    //	PicBirdRed5.transform.position = Screen5Posit;

    //	//播放胜利的音乐@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


    //	//启动胜利特效@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    //}

    //// Use this for initialization---------------------------------------
    //void Start () {
    //	//时间初始都设为不可能值，等待开始键被按下后正式开始才有效
    //	TotalTime = -1;
    //	timeNow = -1;
    //	timeLast = -1;

    //	//初始状态下，各个屏幕都不显示
    //	HidePic(PicBirdRed0);
    //	HidePic(PicBirdRed1);
    //	HidePic(PicBirdRed2);
    //	HidePic(PicBirdRed3);
    //	HidePic(PicBirdRed4);
    //	HidePic(PicBirdRed5);

    //	HidePic(PicPigNormal0);
    //	HidePic(PicPigNormal1);
    //	HidePic(PicPigNormal2);
    //	HidePic(PicPigNormal3);
    //	HidePic(PicPigNormal4);
    //	HidePic(PicPigNormal5);

    //	HidePic(PicPigHard0);
    //	HidePic(PicPigHard1);
    //	HidePic(PicPigHard2);
    //	HidePic(PicPigHard3);
    //	HidePic(PicPigHard4);
    //	HidePic(PicPigHard5);
    //}



    // Update is called once per frame------------------------------------
    //void Update () {
    //	//游戏正式开始
    //	if ((_gameState != GameState.Start)&&(Input.GetKeyDown (KeyCode.Space))) {
    //		//等3秒
    //		//yield return WaitForSeconds (3);

    //		//状态设为开始
    //		_gameState = GameState.Start;

    //		//播放背景音乐
    //		GameAudioManager.Instance.PlayAudio ("Ed loonboon");

    //		//开始计时
    //		TotalTime = 60;
    //		StartCoroutine (startTime ());

    //		timeNow = 60 - TotalTime;

    //           //开始时，所有图片不显示
    //           HidePic(PicBirdRed0);
    //           HidePic(PicBirdRed1);
    //           HidePic(PicBirdRed2);
    //           HidePic(PicBirdRed3);
    //           HidePic(PicBirdRed4);
    //           HidePic(PicBirdRed5);

    //           HidePic(PicPigNormal0);
    //           HidePic(PicPigNormal1);
    //           HidePic(PicPigNormal2);
    //           HidePic(PicPigNormal3);
    //           HidePic(PicPigNormal4);
    //           HidePic(PicPigNormal5);

    //           HidePic(PicPigHard0);
    //           HidePic(PicPigHard1);
    //           HidePic(PicPigHard2);
    //           HidePic(PicPigHard3);
    //           HidePic(PicPigHard4);
    //           HidePic(PicPigHard5);
    //       }

    //   //按时间控制进程
    //	//每4秒生成一只猪
    //	if ((timeLast != timeNow) && (timeNow % 4 == 0) && (timeNow != 60)) {
    //		PigGen ();
    //	} 
    //	else if (timeLast != timeNow) {
    //		//1s后//使之前出现的图片隐藏

    //		HidePic(PicPigNormal0);
    //		HidePic(PicPigNormal1);
    //		HidePic(PicPigNormal2);
    //		HidePic(PicPigNormal3);
    //		HidePic(PicPigNormal4);
    //		HidePic(PicPigNormal5);

    //		HidePic(PicPigHard0);
    //		HidePic(PicPigHard1);
    //		HidePic(PicPigHard2);
    //		HidePic(PicPigHard3);
    //		HidePic(PicPigHard4);
    //		HidePic(PicPigHard5);

    //	}

    //	timeLast = timeNow;

    //       //远程攻击
    //       //暂定为按下A键生成一只鸟
    //       //if (Input.GetKeyDown (KeyCode.A)) {
    //       //Instantiate (NewBirdRed, user.transform.position, user.transform.rotation);
    //       //	GameAudioManager.Instance.PlayAudio ("发射5");
    //       //}

    //       //fail
    //       if ((_gameState == GameState.End) && (TotalTime != 0))
    //       {
    //           PicPigNormal0.transform.position = Screen0Posit;
    //           PicPigNormal1.transform.position = Screen1Posit;
    //           PicPigNormal2.transform.position = Screen2Posit;
    //           PicPigNormal3.transform.position = Screen3Posit;
    //           PicPigNormal4.transform.position = Screen4Posit;
    //           PicPigNormal5.transform.position = Screen5Posit;
    //       }

    //}
    #endregion


}
