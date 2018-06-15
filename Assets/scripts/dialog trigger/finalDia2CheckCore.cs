using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class finalDia2CheckCore : MonoBehaviour {

    public GameCon gameCon;
    public Camera MainCamera;
    public cameraFollowing cameraFollow;
    public shakecamera shake;

    public GameObject emptyButton;

    public level1 level1;

    public dialog haveCoreDialog1;
    public dialog haveCoreDialog2;
    public dialog noCoreDialog1;
    public dialog noCoreDialog2;
    public dialog noCoreDialog3;
    public dialog finalDialog;

    public GameObject player;
    public GameObject machElf;
    public GameObject moveWayPoint;//T移动时的移动到的位置
    public GameObject bill;//剧情用账单

    public GameObject waypoint2;//T带着账本飞到的位置
    public GameObject waypointG1;//G在楼上的位置
    public GameObject waypointG2;//G在楼下的位置
    public GameObject waypointDozen;//Dozen背刺G的位置

    public GameObject QTE;//QTE的按钮
    public GameObject G;//G

    bool hcd1 = false;
    bool hcd2 = false;
    bool finishHCD = false;

    bool jobsFinish = false;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (!jobsFinish)
        {
            if (!finishHCD)//如果对话没结束
            {
                if (hcd1 && !hcd2)
                {
                    if (haveCoreDialog1.finishDialog)
                    {
                        coreAnim();
                    }
                }
                else if (hcd2)
                {
                    if (haveCoreDialog2.finishDialog)
                    {
                        startMove();

                    }
                }
            }
            else
            {
                if (!finalDialog.finishDialog)
                {
                    startQTE();
                }
                else
                {
                    this.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if (finalDialog.finishDialog)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (level1.Item2)//如果拿到了核心
            {
                haveCore();
            }
            else
            {
                haveCore();//暂时不考虑没拿到的情况，不存在这种情况
            }
        }
    }

    void haveCore()
    {
        haveCoreDialog1.startDialog();
        hcd1 = true;
        cameraFollow.enabled = false;
    }

    void noCore()
    {

    }

    /// <summary>
    /// 拿账本勾引G的动画
    /// </summary>
    void coreAnim()
    {
        gameCon.isDOZEN = false;//镜头不再锁定在主角身上        
        MainCamera.transform.position = Vector3.MoveTowards(MainCamera.transform.position, new Vector3(318, 53, -200), 50 * Time.deltaTime);
        machElf.GetComponent<NavMeshAgent>().destination = moveWayPoint.transform.position;
        //如果到了地方
        if (Mathf.Abs(machElf.transform.position.x - moveWayPoint.transform.position.x) < 0.1 && Mathf.Abs(machElf.transform.position.y - moveWayPoint.transform.position.y) < 0.1)
        {
            bill.SetActive(true);
            hcd2 = true;
            haveCoreDialog2.startDialog();
        }
    }

    void startMove()
    {
        
            bill.SetActive(false);
            machElf.GetComponent<NavMeshAgent>().destination = waypoint2.transform.position;
            if (Mathf.Abs(machElf.transform.position.x - waypoint2.transform.position.x) < 0.1 && Mathf.Abs(machElf.transform.position.y - waypoint2.transform.position.y) < 0.1)
            {
                G.GetComponent<Animator>().Play("GMove");
                G.transform.position = Vector3.MoveTowards(G.transform.position, waypointG1.transform.position, 10 * Time.deltaTime);
                if (Mathf.Abs(G.transform.position.x - waypointG1.transform.position.x) < 0.1 && Mathf.Abs(G.transform.position.y - waypointG1.transform.position.y) < 0.1)
                {
                    G.transform.position = waypointG2.transform.position;
                    G.GetComponent<SpriteRenderer>().flipX = true;
                    G.GetComponent<Animator>().Play("GIdle");
                    player.GetComponent<NavMeshAgent>().destination = waypointDozen.transform.position;
                finishHCD = true;
            }

            }


        
    }
    void startQTE()
    {
        emptyButton.SetActive(true);
        
        QTE.SetActive(true);
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            player.GetComponent<turnFaces>().pause = true;//角色动画的改变      
            player.GetComponent<turnFaces>().playAttackAnim();
            shake.shake(2, 0.2f, 45);
            StartCoroutine(finish());
        }
    }

    IEnumerator finish()
    {
        jobsFinish = true;
        yield return new WaitForSeconds(1f);
        emptyButton.SetActive(false);
        QTE.SetActive(false);
        gameCon.isDOZEN = true;
        cameraFollow.enabled = true;
        player.GetComponent<turnFaces>().pause = false;//角色动画的改变 
        G.GetComponent<SpriteRenderer>().flipX = false;
        finalDialog.startDialog();
    }
}
