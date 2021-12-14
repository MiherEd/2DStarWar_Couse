using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    //Player.Unity內建儲存資料方式，可以儲存文字、整數、小數
    //Player.SetInt("儲存資料欄為名稱",儲存的整數值);
    //Player.SetFloat("儲存資料欄為名稱",儲存的浮點數);
    //Player.SetString("儲存資料欄為名稱",儲存的文字);
    //Player.GetInt("取出資料欄為名稱")
    //Player.GetFloat("取出資料欄為名稱")
    //Player.GetString("取出資料欄為名稱")
    //儲存每一個關卡遊戲目標分數 - 欄位名稱
    string DataName = "AimSocre";
    [Header("每一個關卡的目標分數")]
    public int[] TotalLevelAimScore;
    [Header("每一個關卡的按鈕")]
    public Button[] LevelButtons;
    void Start()
    {
        for (int id = 0; id < Static.NowLevelID; id++)
            if(id<9)
                LevelButtons[id].interactable = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //設定每一個關卡欄位的目標分數

    //案下第一關的按鈕跳至Movie 場景
    public void NextSceneToLevel1(int LevelID)
    {        
        PlayerPrefs.SetInt(DataName, TotalLevelAimScore[LevelID]);
        //目前正在進行的遊戲關卡id
        Static.NowLevelID = LevelID;
        Application.LoadLevel("Movie");
    }
    //點其他跳至遊戲關卡
    public void NextSceneToOtherLevel(int LevelID)
    {
        PlayerPrefs.SetInt(DataName, TotalLevelAimScore[LevelID]);
        //目前正在進行的遊戲關卡id
        Static.NowLevelID = LevelID;
        Application.LoadLevel("Game");
    }
    //返回首頁
    public void NextSceneToMenu()
    {
        Application.LoadLevel("Menu");
    }
}
