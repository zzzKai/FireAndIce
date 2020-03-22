using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : MonoSingleton<GameAudioManager> {

    string audiosPath = "Audios/";

    [SerializeField]
    AudioClip BGM;

    void Init()
    {
        this.GetComponent<AudioSource>().clip = BGM;
        this.GetComponent<AudioSource>().Play();
    }
	// Use this for initialization
	void Start () {

       
    }
	
    /// <summary>
    /// 播放Assets/Resources/Audios下名称为audioName的音频文件，如果target不为空在target位置创建音频OBJ
    /// </summary>
    /// <param name="audioName"></param>
    /// <param name="target"></param>
    /// <param name="isDestroy"></param>
    public void PlayAudio(string audioName,GameObject target=null,bool isDestroy=true)
    {
        GameObject tempAudioSource = new GameObject("audioObj");
        tempAudioSource.AddComponent<AudioSource>();
        if (target!=null)
        {
            tempAudioSource.transform.position= target.transform.position;
        }
        
        AudioClip audioClip= Resources.Load<AudioClip>(audiosPath + audioName);
        tempAudioSource.GetComponent<AudioSource>().clip = audioClip;
        tempAudioSource.GetComponent<AudioSource>().Play();
      

        float tempfloat = 0;
        if (audioClip!= null)
        {
            tempfloat = audioClip.length;
        }

        if (isDestroy)
        {
            Destroy(tempAudioSource, tempfloat);
        }
        
        
    }

	// Update is called once per frame
	void Update () {

       

    }
}
