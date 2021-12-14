using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("多久時間後將敵機刪除")]
    public float DeleteTime;
    [Header("移動速度")]
    public float Speed;

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
        //敵機位移
        transform.Translate(Vector3.down * Speed);
    }
}
