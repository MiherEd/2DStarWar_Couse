using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBullet : MonoBehaviour
{
    [Header("設定固定每多少秒呼叫一次function")]
    public float Timer;
    [Header("要生成的子彈物件")]
    public GameObject Bullet;
    [Header("子彈生成的位置")]
    public GameObject BulletPos_L;
    public GameObject BulletPos_R;
    // Start is called before the first frame update
    void Start()
    {
        //持續呼叫function - InvokeRepeating("function名稱",遊戲開始後要多久進行第一次呼叫function, 第二次以後每次Delay多少時間呼叫function)
        //以秒為單位
        InvokeRepeating("ProduceBullet", Timer, Timer);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void ProduceBullet()
    {   //動態生成子彈在空物件的位置
        Instantiate(Bullet, BulletPos_L.transform.position, BulletPos_L.transform.rotation); 
        Instantiate(Bullet, BulletPos_R.transform.position, BulletPos_R.transform.rotation); 
    }
}
