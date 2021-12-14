using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    #region 魔物產生
    [Header("X邊界最小值")]
    public float Xmin;
    [Header("X邊界最大值")]
    public float Xmax;
    [Header("多少時間產生一個敵機")]
    public float Timer;
    [Header("敵機")]
    public GameObject[] Enemys;
    [Header("敵機產生位置")]
    public Transform EnemyPos;
    #endregion 

    #region 玩家血量/血條
    [Header("設定玩家的初始血量")]
    public float TotalPlayerHP;
    //程式中計算玩家的血量
    float PlayerScriptHP;
    [Header("傷害玩家的血量")]
    public float HurtPlayerHP;
    [Header("玩家的血條")]
    public Image PlayerHPBar;
    #endregion

    #region 得分數
    [Header("總分數")]
    public int TotalScore;
    [Header("打死敵機加幾分")]
    public int AddScore;
    [Header("顯是玩家得分數")]
    public Text ScoreText;
    #endregion
    [Header("遊戲暫停畫面")]
    public GameObject GamePauseUI;
    string ScoreDataName = "Score";
    void Start()
    {

        InvokeRepeating("ProduceEnemy", Timer, Timer);
        //程式中玩家的血量=屬性面板的血量
        PlayerScriptHP = TotalPlayerHP;
    }
    void ProduceEnemy()
    {
        //一台敵機
        //Instantiate(Enemys,new Vector3(Random.Range(Xmin, Xmax), EnemyPos.position.y, EnemyPos.position.z),EnemyPos.rotation);
        //兩個參數範圍內隨機Random.Range(最小值,最大值)
        //動態生成Instantiate(產生的物件,產生的位置,產生以後的角度)
        Instantiate(Enemys[Random.Range(0, Enemys.Length)],
            new Vector3(Random.Range(Xmin,Xmax),EnemyPos.position.y,EnemyPos.position.z),
            EnemyPos.rotation);
    }
    public void HurtPlayer()
    {
        //目前玩家程式中的血量 = 玩家程式中的血量-傷害;
        PlayerScriptHP -= HurtPlayerHP;
        //UI Image .fillAmount 回傳為小數值，所以必須將玩家血量做換算>玩家程式中的血量/屬性面板中的血量
        PlayerHPBar.fillAmount = PlayerScriptHP / TotalPlayerHP;
        //如果玩家血量為0
        if (PlayerScriptHP <= 0)
        {
            //儲存分數
            PlayerPrefs.SetInt(ScoreDataName, TotalScore);
            //跳換至GameOver場景
            Application.LoadLevel("GameOver");
        }
        
    }
    public void Total_Score()
    {
        //目前總分 = 總分+加分;
        //TotalScore = TotalScore+AddScore;
        TotalScore += AddScore;
        //將分數顯示在文字上
        ScoreText.text = "Score:" + TotalScore;
    }

    //整體遊戲時間暫停，但Update function 其實還是有一直在執行
    public void Stop()
    {
        GamePauseUI.SetActive(true);
        //Time.timeScale =0; 整體遊戲時間暫停，如果沒有在遊戲一開始復原，關掉遊戲在重開也是呈現暫停狀態
        Time.timeScale =0;
    }
    //恢復遊戲
    public void Continue()
    {
        GamePauseUI.SetActive(false);
        //Time.timeScale = 0; 恢復運行
        Time.timeScale = 1;
    }
    //回首頁
    public void ToMenu()
    {
        //Time.timeScale =1; 恢復整體運型
        Time.timeScale = 1;
        Application.LoadLevel("Menu");
    }
}
