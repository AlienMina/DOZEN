using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEaccounts : MonoBehaviour {
    /// <summary>
    /// QTE的结算效果存放处
    /// </summary>
    public enemyStatus enemysta;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    /// <summary>
    /// 立刻死亡
    /// </summary>
    public void enemyDiedImmediately()
    {
        StartCoroutine(enemysta.diedImmediately());
        
    }

    /// <summary>
    /// 晕眩
    /// </summary>
    public void enemyDizzy()
    {
        StartCoroutine(enemysta.dizzy());
    }

    /// <summary>
    /// 温顺
    /// </summary>
    public void enemyFriendly()
    {
        StartCoroutine(enemysta.friendly());
    }

    /// <summary>
    /// 发疯
    /// </summary>
    public void enemyCrazy()
    {
        StartCoroutine(enemysta.crazy());
    }

    /// <summary>
    /// 暴走
    /// </summary>
    public void enemyAngry()
    {
        Debug.Log("此处应有暴走");
    }
}
