using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMove : MonoBehaviour {

    public GameCon GameContent;
    GameObject houseTag;//这个是敌人检测到的自己所在的地块

    public AudioSource audios;

    public GameObject enemyAnima;
    public GameObject gameplayer;

    Vector3 place1;//巡逻的初始点
    public GameObject place2;//巡逻的终点，请拖一个Object
    //Vector3 enemyPlace;

    public float between = 0.1f;


    bool chasingVoice = false;//追声音
    public bool chasingPlayer = false;//追主角
    public bool isChasing = false;//正在追……用于chasingPlayer内部的判断
    public bool isAttracted = false;//追小精灵
    


    private NavMeshAgent agent;//寻路用的

    Vector3 voicePlace;
    Vector3 playerPlace;
    public Vector3 attractedPlace;//追逐小精灵时候的定位点

    bool setVoicePlace = false;//追声音的时候，用于判定是否定位，如果已经做了定位，打开它，当走到声源位置或者中间就撞到了主角，关闭它
   public  bool attractedSet = false;//用于小精灵吸引内部的判断

    // Use this for initialization
    void Start () {
        place1 = this.GetComponent<Transform>().position;//敌人巡逻的起始点
        agent = GetComponent<NavMeshAgent>();//寻路的设置
        agent.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        //enemyPlace = this.GetComponent<Transform>().position;
        //if (!chasingPlayer && !chasingVoice)
        //StartCoroutine(patrol());
        //enemyAnima.GetComponent<houseController>().hearPlayer
        if (enemyAnima != null)
        {
            houseTag = enemyAnima.GetComponent<getHouseTag>().houseBetween;
        }
        //Debug.Log(houseTag);

        //优先进行判断，追主角优先度>小精灵声音>追主角声音>巡逻，当没有追玩家也没有追声音的时候，进行检测【同时由playmaker进行巡逻】
        if (chasingPlayer)
        {
            audios.Play();
            ChasingPlayer();
        }
        else if (isAttracted)//小精灵的声音优先级大于主角的声音
        {
            StartCoroutine(attractedByMachelf());
        }
        else if(chasingVoice){
            StartCoroutine(ChasingVoice());
            //ChasingVoice();
        }
        else if (houseTag!=null && houseTag.GetComponent<houseController>().hearPlayer)
        {
            Debug.Log("chaseVoice=true");
            chasingVoice = true;//当地块上可以听到player的时候，开启追逐声源效果
            //houseTag.GetComponent<houseController>().hearPlayer = false;
        }
        
	}

    //获取当前的地块--这里应该是获取下面挂载的动画小朋友的碰撞

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "houseTag")
    //    {
    //        houseTag = collision.GetComponent<GameObject>();
    //        Debug.Log("setHouseTag");
    //    }
    //}


    //这两个是playmaker用的移动
    public void patrol2place2()
    {
        agent.destination = place2.transform.position;
    }

    public void patrol2place1()
    {
        agent.destination = place1;
    }
    
    //追逐玩家
    void ChasingPlayer()
    {
        float oldSpeed = agent.speed;
        float newSpeed = oldSpeed * 1.2f;//敌人追击速度的调整

        if (!GameContent.isHidden)//在主角没有藏起来的状态下
        {
            
            //停止追声音的行为
            chasingVoice = false;
            setVoicePlace = false;

            playerPlace = gameplayer.GetComponent<Transform>().position;
            //检测主角的位置
            if (!isChasing)//主角已经不在视野范围内了
            {
                string enemyHouseName = houseTag.name;
                string playerHouseName = gameplayer.GetComponentInChildren<playerHouseTag>().playerHouseName;
                //Debug.Log("enemyHouseName " + enemyHouseName + " playerHouseName " + playerHouseName);
                if (enemyHouseName != playerHouseName)//敌人和主角不在同一房间
                {
                    audios.Stop();
                    chasingPlayer = false;
                    agent.speed = oldSpeed;
                    agent.destination = place1;//返回初始地点
                }
            }
            else
            {
                agent.speed = newSpeed;
                agent.destination = playerPlace;
            }
        }
        else
        {
            audios.Stop();
            chasingPlayer = false;
            chasingVoice = false;
            setVoicePlace = false;
            agent.speed = oldSpeed;
            agent.destination = place1;
        }

    }

    //前往声源
    IEnumerator ChasingVoice()
    {
        
        if (!setVoicePlace)
        {
            //如果还没有设置声源点，那么设置为当前主角的位置
            voicePlace=gameplayer.GetComponent<Transform>().position;
            agent.destination = voicePlace;
            setVoicePlace = true;
            Debug.Log("chasing voice start");
        }
        else //如果已经设置了声源点的情况
        {
            //判断是否已经到达【只判断平面上的情况
            if (voicePlace.x - this.GetComponent<Transform>().position.x <= between &&voicePlace.y-this.GetComponent<Transform>().position.y<=between)
            {
                Debug.Log(houseTag);
                setVoicePlace = false;
                chasingVoice = false;
                yield return new WaitForSeconds(5);
                agent.destination = place1;
                Debug.Log("chasing finished.");
            }
        }
    }

    //被小精灵吸引
    public IEnumerator attractedByMachelf()
    {
        agent.destination = attractedPlace;
        yield return new WaitForSeconds(1);
        if(Mathf.Abs(agent.remainingDistance) < between)
        {
            yield return new WaitForSeconds(4);
            //Debug.Log(this.GetComponent<Transform>().position);
            isAttracted = false;
            agent.destination = place1;
        }
        /*
        if (!attractedSet)
        {
            //如果还没有设置小精灵的位置
            attractedPlace = GameObject.Find("MachElfT-10").GetComponent<Transform>().position;
            agent.destination = attractedPlace;
            attractedSet = true;
            Debug.Log("attracted Place: " + attractedPlace+this.name);
        }
        else//如果已经设置了声源点
        {
            //截取一段时间内的敌人的位置
            Vector3 enemPlace = this.GetComponent<Transform>().position;
            yield return new WaitForSeconds(2);
            Vector3 enemplace2 = this.GetComponent<Transform>().position;

            //如果已经到了声源点
            if (enemPlace.x-enemplace2.x<=between&&enemPlace.y-enemplace2.y<=between)
                /*aattractedPlace.x - this.GetComponent<Transform>().position.x <= 5 && attractedPlace.y - this.GetComponent<Transform>().position.y <= 5
            {
                
                Debug.Log("this.place " + this.GetComponent<Transform>().position);
                attractedSet = false;
                isAttracted = false;
                yield return new WaitForSeconds(1);
                agent.destination = place1;                
                Debug.Log("finish being attracted");
                //停顿1s后，结束吸引状态，返回原处
            }
        } */
    }

    //IEnumerator patrol() {       
    //    if (isPlace1)
    //        agent.destination = place2.transform.position;
    //    else
    //        agent.destination = place1;
    //    if(agent.remainingDistance <= agent.stoppingDistance + between)
    //    {
    //      yield return new WaitForSeconds(5);
    //        if (isPlace1)
    //        {
    //            isPlace1 = false;
    //            Debug.Log("is Place1 false.");
    //        }
    //        else
    //        {
    //            isPlace1 = true;
    //            Debug.Log("is Place1 true.");
    //        }
    //    }

    //}

   public void stopMove()
    {
        agent.speed=0;
    }







}
