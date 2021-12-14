using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    [Header("放入專案中的BGM物件")]
    public GameObject BGM;
    void Awake()
    {
        //找尋物件-名字GameObject.Find("物件名稱");
        //找尋物件-標籤
        //單數GameObject.FindWithTag("標籤名稱")
        //單數GameObject.FindGameObjectsWithTag("標籤名稱")
        //如果場景上沒有半個BGM物件
        if (GameObject.FindGameObjectsWithTag("BGM").Length < 1)
        {
            //動態生成Instantiate(要生成的物件,生成位置,生成的旋轉值)
            // Instantiate(BGM); 默認位置
            //動態生成BGM
            //生成的位置如果要默認，寫法為transform.postion
            //如果位置要設定某一個位置點，寫法為new Vector3(帶入3維位置)
            //生成的角度值如果要默認，寫法為transform.rotation
            Instantiate(BGM, new Vector3(0f, 0f, 0f), transform.rotation);
        }
    }
    void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {        
    }

    //public公開: 可以讓其他物件或程式碼進行呼叫
    //private私有:無法讓其他物件或程式碼呼叫
    public void LoadScene()
    {
        //切換場景:
        //Application.LoadLevel("場景名稱"); 輸入場景名稱
        //Application.LoadLevel(0); 輸入場景裡面的ID
        //Application.loadedLevel; 讀取當前場景名稱
        //Application.LoadLevel(Application.loadedLevel); 重新讀取當前場景
        Application.LoadLevel("Level");
    }
    public void QuitGame()
    {
        //Application.Quit(); 關閉遊戲執行檔案
        Application.Quit();
    }

}
