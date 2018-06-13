using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class brokenChandelier : MonoBehaviour {
    public GameObject showBrokenChandelier;//破碎的吊灯
    public GameObject hideSimpleChandelier;//完整的吊灯
    public GameObject brokenPart;//掉下去的部分
    public GameObject Player;//玩家
    public GameObject waypoint;//玩家移动到的地方
    public shakecamera shakeCamera;//镜头摇晃
    public GameObject block;//阻挡行进的部分
    public GameObject blackScreen;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startBroken()
    {
        StartCoroutine(brokenAnim());
    }

    public IEnumerator brokenAnim()
    {
        //震屏
        shakeCamera.shake(3, 0.2f, 45);
        yield return new WaitForSeconds(1f);
        //黑屏
        StartCoroutine(BlackScreen());
        yield return new WaitForSeconds(1f);
        //移动主角位置
        block.SetActive(true);
        Player.transform.position = waypoint.transform.position;
        yield return new WaitForSeconds(2f);
        //结束黑屏
        StartCoroutine(finishBlackScreen());

        //吊灯的显示
        shakeCamera.shake(3, 0.2f, 45);
        showBrokenChandelier.SetActive(true);
        hideSimpleChandelier.SetActive(false);
       
        yield return new WaitForSeconds(3f);
        brokenPart.SetActive(false);
        shakeCamera.shake(5, 0.2f, 45);
    }

    public IEnumerator BlackScreen()
    {
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        blackScreen.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.2f);
        yield return new WaitForSeconds(0.2f);
        blackScreen.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.4f);
        yield return new WaitForSeconds(0.2f);
        blackScreen.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.6f);
        yield return new WaitForSeconds(0.2f);
        blackScreen.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.8f);
        yield return new WaitForSeconds(0.2f);
        blackScreen.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
    }

    public IEnumerator finishBlackScreen()
    {
        blackScreen.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
        yield return new WaitForSeconds(0.2f);
        blackScreen.GetComponent<SpriteRenderer>().color = new Color(0, 0,0, 0.8f);
        yield return new WaitForSeconds(0.2f);
        blackScreen.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.6f);
        yield return new WaitForSeconds(0.2f);
        blackScreen.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.4f);
        yield return new WaitForSeconds(0.2f);
        blackScreen.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.2f);
        yield return new WaitForSeconds(0.2f);
        blackScreen.SetActive(false);
    }
}
