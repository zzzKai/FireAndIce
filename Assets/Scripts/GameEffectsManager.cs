using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEffectsManager : MonoSingleton<GameEffectsManager> {

    string audiosPath = "Effects/";

    void Init()
    {

    }

    public GameObject PlayEffect(string effectsName,GameObject target)
    {
        //Debug.Log(audiosPath + effectsName);
        GameObject effects = Instantiate( Resources.Load<GameObject>(audiosPath + effectsName));
        effects.transform.position = target.transform.position;
        return effects;
    }

}
