using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    string DataName = "AimSocre";
    [Header("�ؼФ��Ƥ�r")]
    public Text AimScoreText;

    string ScoreDataName = "Score";
    [Header("���Ƥ�r")]
    public Text ScoreText;
    [Header("NextGame���s")]
    public Button NextGameButton;
    [Header("���d��r")]
    public Text LevelText;
    // Start is called before the first frame update
    void Start()
    {
        LevelText.text = "�� " + Static.NextLevelID+1 + " ��";
        //Ū�X���d�ؼФ���
        AimScoreText.text = "Aim Score:" + PlayerPrefs.GetInt(DataName);
        //Ū�X����
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

    //��^����
    public void NextSceneToMenu()
    {
        Application.LoadLevel("Menu");
    }
}
