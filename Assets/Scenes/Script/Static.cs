using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Static : MonoBehaviour
{


    //暫存聲音音量數直
    static public float SaveAudiovolueme;
    //判斷是否第一次進入首頁
    static public bool isFirst = true;
    //目前正在進行遊戲的關卡
    static public int NowLevelID;
    //可以開啟的遊戲關卡ID
    static public int NextLevelID;

}
