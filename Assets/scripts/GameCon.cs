using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//这个是用来记全局变量和公共事件的，默认挂在Main Camera上
public class GameCon : MonoBehaviour {

    public bool isDOZEN = true;//现在是否控制的是主角，是的时候控制主角，否的时候是小精灵
    public bool isHidden = false;//主角是否进行了藏匿，默认是没有
    public AudioSource hideAudio;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DozenHide()
    {
        hideAudio.Play();
        isHidden = true;
    }
    public void DozenLeaveHidden()
    {
        hideAudio.Play();
        isHidden = false;
        
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        string restartScene= SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(restartScene, LoadSceneMode.Single);
    }
}
