using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LiteralCancer : MonoBehaviour {
    public int curLevel = 1;
    public string[] sceneList = new string[10];

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
        sceneList[0] = "Level0";
        sceneList[1] = "Level1";
        sceneList[2] = "Level2";
        sceneList[3] = "Level3";
        sceneList[4] = "Level4";
        sceneList[5] = "Level5";
        sceneList[6] = "Level6";
    }
}
