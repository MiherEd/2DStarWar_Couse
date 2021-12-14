using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("多久時間後將子彈刪除")]
    public float DeleteTime;
    [Header("移動速度")]
    public float Speed;

    [Header("玩家爆炸的特效")]
    public GameObject PlayerVFX;
    [Header("敵機爆炸的特效")]
    public GameObject EnemyVFX;
    // Start is called before the first frame update
    void Start()
    {
        //沒有打到任何敵機的情況下，過一陣子把自己刪除
        //物件刪除Destroy(要刪除的物件)
        Destroy(gameObject, DeleteTime);       
    }

    // Update is called once per frame
    void Update()
    {
        //子彈位移
        transform.Translate(Vector3.up * Speed);
    }
    //3D碰撞偵測-穿透行碰撞，自帶Collider變數，物件需要加上Collider和Rigibody
    //OnTriggerEnter: 當兩個物件一碰撞，如果兩物件沒有分離，此function內的程式只會執行一次
    //OnTriggerStay: 當兩個物件碰撞，如果兩物件沒有分離，此function內的程式會持續執行
    //OnTriggerExit: 當兩個物件一碰撞，如果兩物件分離，此function內的程式只會會執行一次
    //2D碰撞偵測-穿透型碰撞，自帶Collider2D變數，物件需要加上2D Collider和2D Rigibody
    //OnTriggerEnter2D: 當兩個物件一碰撞，如果兩物件沒有分離，此function內的程式只會執行一次
    //OnTriggerStay2D: 當兩個物件碰撞，如果兩物件沒有分離，此function內的程式會持續執行
    //OnTriggerExit2D: 當兩個物件一碰撞，如果兩物件分離，此function內的程式只會會執行一次
    void OnTriggerEnter2D(Collider2D hit)
    {
        //如果是玩家的子彈，並且碰撞的對象是敵機
        if(gameObject.tag == "PlayerBullet" && hit.GetComponent<Collider2D>().tag == "Enemy")
        {
            //Debug.Log("攻擊到敵機");
            //動態生成-敵機爆炸特效
            Instantiate(EnemyVFX, hit.transform.position, transform.rotation);

            //子彈打到敵機以後，找到場景上命名為GM的物件並呼叫Total_Score();
            GameObject.Find("GM").GetComponent<GM>().Total_Score();
            //玩家的子彈要消失
            Destroy(gameObject);
            //敵機也要消失
            Destroy(hit.gameObject);
        }
        //如果是怪物的子彈，並且碰撞的對象是玩家
        if (gameObject.tag == "EnemyBullet" && hit.GetComponent<Collider2D>().tag == "Player")
        {
            //動態生成-玩家爆炸特效
            Instantiate(PlayerVFX, hit.transform.position, transform.rotation);
            //Debug.Log("攻擊到玩家");
            //敵機子彈打到玩家以後，找到場景上命名為GM的物件並呼叫HurtPlayer function
            GameObject.Find("GM").GetComponent<GM>().HurtPlayer();
            //敵機的子彈要消失
            Destroy(gameObject);
        }
    }
}

