using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    //Player.Unity�����x�s��Ƥ覡�A�i�H�x�s��r�B��ơB�p��
    //Player.SetInt("�x�s����欰�W��",�x�s����ƭ�);
    //Player.SetFloat("�x�s����欰�W��",�x�s���B�I��);
    //Player.SetString("�x�s����欰�W��",�x�s����r);
    //Player.GetInt("���X����欰�W��")
    //Player.GetFloat("���X����欰�W��")
    //Player.GetString("���X����欰�W��")
    //�x�s�C�@�����d�C���ؼФ��� - ���W��
    string DataName = "AimSocre";
    [Header("�C�@�����d���ؼФ���")]
    public int[] TotalLevelAimScore;
    [Header("�C�@�����d�����s")]
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
    //�]�w�C�@�����d��쪺�ؼФ���

    //�פU�Ĥ@�������s����Movie ����
    public void NextSceneToLevel1(int LevelID)
    {        
        PlayerPrefs.SetInt(DataName, TotalLevelAimScore[LevelID]);
        //�ثe���b�i�檺�C�����did
        Static.NowLevelID = LevelID;
        Application.LoadLevel("Movie");
    }
    //�I��L���ܹC�����d
    public void NextSceneToOtherLevel(int LevelID)
    {
        PlayerPrefs.SetInt(DataName, TotalLevelAimScore[LevelID]);
        //�ثe���b�i�檺�C�����did
        Static.NowLevelID = LevelID;
        Application.LoadLevel("Game");
    }
    //��^����
    public void NextSceneToMenu()
    {
        Application.LoadLevel("Menu");
    }
}
