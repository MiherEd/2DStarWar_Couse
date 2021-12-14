using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    string DataName = "AimSocre";
    [Header("目標分數文字")]
    public Text AimScoreText;

    string ScoreDataName = "Score";
    [Header("分數文字")]
    public Text ScoreText;
    [Header("NextGame按鈕")]
    public Button NextGameButton;
    [Header("關卡文字")]
    public Text LevelText;
    // Start is called before the first frame update
    void Start()
    {
        LevelText.text = "第 " + Static.NextLevelID+1 + " 關";
        //讀出關卡目標分數
        AimScoreText.text = "Aim Score:" + PlayerPrefs.GetInt(DataName);
        //讀出分數
        ScoreText.text = "Score:" + PlayerPrefs.GetInt(ScoreDataName);
        if (PlayerPrefs.GetInt(ScoreDataName) > PlayerPrefs.GetInt(DataName))
            NextGameButton.interactable = true;
        else
            NextGameButton.interactable = false;
    }
    public void NextGame()
    {
        if(Static.NowLevelID == Mathf.Clamp(Static.NextLevelID, 0, 10))        
            Static.NextLevelID++;        
        Application.LoadLevel("Level");
    }
    public void Regame()
    {
        Application.LoadLevel("Game");
    }

    //返回首頁
    public void NextSceneToMenu()
    {
        Application.LoadLevel("Menu");
    }
}
