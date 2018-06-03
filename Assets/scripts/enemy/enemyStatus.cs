using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 * 这里是重写的敌人，敌人的所有状态都放在这里，包括QTE后的状态和平常的状态
 * 然后大概会在这里整理一下所有的状态，以免写成上一次那种原地爆炸的效果
 * QTE状态结算优先于巡逻时的状态
 * QTE开启时，暂停敌人的行动，存储当前的状态，然后在QTE结束后结算QTE状态并执行
 * 执行结束后再读取之前的状态继续
 * ——现在暂时想偷个懒：在结算QTE状态的时候停掉enemyMove，然后结算完了再打开……
 * 敌人血量写在这里了！
 */
public class enemyStatus : MonoBehaviour {

    public int enemyBlood = 10;//敌人的血量写在这里
    public enemyMove enemymov;
    public enemyView enemyview;
    public GameCon gameCon;
    public GameObject enemyState;//这是敌人头顶显示状态的按钮……使用的时候记得把ganecon.showkillbutton打开……
    public GameObject blood;
    Animator anim;
    bool Crazy = false;
    bool angry = false;
    float oldSpeed;
    float speedBeforeStop;

    [SerializeField] float crazyTime = 3f;
    [SerializeField] float angrySpeed = 16;

    public enemyState enemystate;//头顶状态相关
    
	// Use this for initialization
	void Start () {
        anim = enemymov.gameObject.GetComponentInChildren<turnFaceEnemy>().gameObject.GetComponent<Animator>();
        speedBeforeStop = enemymov.gameObject.GetComponent<NavMeshAgent>().speed;
    }

    // Update is called once per frame
    void Update() {
        if (Crazy)
        {



            enemymov.audios.gameObject.SetActive(false);
            enemymov.alert.SetActive(false);
            Random.InitState((int)Time.time);
            if (Random.value > 0.5)
            {
                enemymov.gameObject.GetComponent<NavMeshAgent>().destination = new Vector3(enemymov.gameObject.transform.position.x + Random.value, enemymov.gameObject.transform.position.y, enemymov.gameObject.transform.position.z);
            }
            else
            {
                enemymov.gameObject.GetComponent<NavMeshAgent>().destination = new Vector3(enemymov.gameObject.transform.position.x - Random.value, enemymov.gameObject.transform.position.y, enemymov.gameObject.transform.position.z);
            }
        }
        if (angry)
        {


            enemymov.audios.gameObject.SetActive(false);
            enemymov.alert.SetActive(false);
            if (!gameCon.isHidden)
            {
                enemymov.gameObject.GetComponent<NavMeshAgent>().destination = GameObject.FindWithTag("Player").transform.position;
            }
            else
            {
                angry = false;
                enemymov.gameObject.GetComponent<NavMeshAgent>().speed = oldSpeed;
                enemymov.gameObject.GetComponent<NavMeshAgent>().destination = enemymov.place1;
                enemymov.Patrol();

            }
        }
        if (!gameCon.enemyStop)
        {


            enemymov.audios.gameObject.SetActive(false);
            enemymov.alert.SetActive(false);
            enemymov.gameObject.GetComponent<NavMeshAgent>().speed = speedBeforeStop;
            speedBeforeStop = enemymov.gameObject.GetComponent<NavMeshAgent>().speed;
        }
        else
        {
            enemymov.gameObject.GetComponent<NavMeshAgent>().speed = 0;
        }

        if (enemyBlood == 0)
        {

            

            enemymov.audios.gameObject.SetActive(false);
            enemymov.alert.SetActive(false);
            StartCoroutine(diedImmediately());
        }
	}

    public IEnumerator diedImmediately()
    {
        //头顶动画相关
        enemystate.clearState();

        enemymov.enabled = false;
        enemyview.gameObject.SetActive(false);
        gameCon.Gold += 100;
        blood.SetActive(true);
        enemyBlood = 0;
        enemymov.gameObject.GetComponentInChildren<turnFaceEnemy>().setdead();
        anim.Play("enemySimpleDied");
        yield return new WaitForSeconds(1f);
        Destroy(enemymov.gameObject);
    }

    public IEnumerator dizzy()
    {
        //头顶动画相关
        enemystate.clearState();

        enemymov.gameObject.GetComponentInChildren<turnFaceEnemy>().pause = true;
        enemymov.enabled = false;
        enemyview.gameObject.SetActive(false);
        blood.SetActive(true);
        enemyBlood -= 1;      
        //anim.Play("enemySimpleDied");//此处动画应该替换，还应该有一个头顶动画的出现
        
        yield return new WaitForSeconds(2f);
        enemymov.enabled = true;
        enemymov.gameObject.GetComponentInChildren<turnFaceEnemy>().pause=false;
        enemyview.gameObject.SetActive(true);
        blood.SetActive(false);
    }

    public IEnumerator friendly()
    {
        //头顶动画相关
        enemystate.clearState();

        enemymov.gameObject.GetComponentInChildren<turnFaceEnemy>().pause = true;
        enemymov.enabled = false;
        enemyview.gameObject.SetActive(false);
        anim.Play("enemySimpleFriendly");//此处动画应该替换，还应该有一个头顶动画的出现
        yield return new WaitForSeconds(3f);
        enemymov.enabled = true;
        enemymov.gameObject.GetComponentInChildren<turnFaceEnemy>().pause = false;
        enemyview.gameObject.SetActive(true);
    }

    public IEnumerator crazy()
    {
        //头顶动画相关
        enemystate.clearState();

        enemymov.gameObject.GetComponentInChildren<turnFaceEnemy>().pause = true;
        enemymov.enabled = false;        
        anim.Play("enemySimpleCrazy");//此处动画应该替换，还应该有一个头顶动画的出现
        yield return new WaitForSeconds(1f);
        Crazy = true;
        enemymov.enabled = true;
        enemymov.gameObject.GetComponentInChildren<turnFaceEnemy>().pause = false;
        enemymov.enabled = false;
        yield return new WaitForSeconds(crazyTime);
        Crazy = false;
        enemymov.enabled = true;

    }

    public IEnumerator Angry()
    {
        //头顶动画相关
        enemystate.clearState();

        gameCon.playerHealth -= 2;
        enemymov.gameObject.GetComponentInChildren<turnFaceEnemy>().pause = true;
        enemymov.enabled = false;
        anim.Play("enemySimpleAngry");//此处动画应该替换，还应该有一个头顶动画的出现
        yield return new WaitForSeconds(1f);
        angry = true;
        enemymov.gameObject.GetComponentInChildren<turnFaceEnemy>().pause = false;
        oldSpeed = enemymov.gameObject.GetComponent<NavMeshAgent>().speed;
        enemymov.gameObject.GetComponent<NavMeshAgent>().speed = angrySpeed;

    }
}
