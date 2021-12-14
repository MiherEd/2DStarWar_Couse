using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    #region �]������
    [Header("X��ɳ̤p��")]
    public float Xmin;
    [Header("X��ɳ̤j��")]
    public float Xmax;
    [Header("�h�֮ɶ����ͤ@�Ӽľ�")]
    public float Timer;
    [Header("�ľ�")]
    public GameObject[] Enemys;
    [Header("�ľ����ͦ�m")]
    public Transform EnemyPos;
    #endregion 

    #region ���a��q/���
    [Header("�]�w���a����l��q")]
    public float TotalPlayerHP;
    //�{�����p�⪱�a����q
    float PlayerScriptHP;
    [Header("�ˮ`���a����q")]
    public float HurtPlayerHP;
    [Header("���a�����")]
    public Image PlayerHPBar;
    #endregion

    #region �o����
    [Header("�`����")]
    public int TotalScore;
    [Header("�����ľ��[�X��")]
    public int AddScore;
    [Header("��O���a�o����")]
    public Text ScoreText;
    #endregion
    [Header("�C���Ȱ��e��")]
    public GameObject GamePauseUI;
    string ScoreDataName = "Score";
    void Start()
    {

        InvokeRepeating("ProduceEnemy", Timer, Timer);
        //�{�������a����q=�ݩʭ��O����q
        PlayerScriptHP = TotalPlayerHP;
    }
    void ProduceEnemy()
    {
        //�@�x�ľ�
        //Instantiate(Enemys,new Vector3(Random.Range(Xmin, Xmax), EnemyPos.position.y, EnemyPos.position.z),EnemyPos.rotation);
        //��ӰѼƽd���H��Random.Range(�̤p��,�̤j��)
        //�ʺA�ͦ�Instantiate(���ͪ�����,���ͪ���m,���ͥH�᪺����)
        Instantiate(Enemys[Random.Range(0, Enemys.Length)],
            new Vector3(Random.Range(Xmin,Xmax),EnemyPos.position.y,EnemyPos.position.z),
            EnemyPos.rotation);
    }
    public void HurtPlayer()
    {
        //�ثe���a�{��������q = ���a�{��������q-�ˮ`;
        PlayerScriptHP -= HurtPlayerHP;
        //UI Image .fillAmount �^�Ǭ��p�ƭȡA�ҥH�����N���a��q������>���a�{��������q/�ݩʭ��O������q
        PlayerHPBar.fillAmount = PlayerScriptHP / TotalPlayerHP;
        //�p�G���a��q��0
        if (PlayerScriptHP <= 0)
        {
            //�x�s����
            PlayerPrefs.SetInt(ScoreDataName, TotalScore);
            //������GameOver����
            Application.LoadLevel("GameOver");
        }
        
    }
    public void Total_Score()
    {
        //�ثe�`�� = �`��+�[��;
        //TotalScore = TotalScore+AddScore;
        TotalScore += AddScore;
        //�N������ܦb��r�W
        ScoreText.text = "Score:" + TotalScore;
    }

    //����C���ɶ��Ȱ��A��Update function ����٬O���@���b����
    public void Stop()
    {
        GamePauseUI.SetActive(true);
        //Time.timeScale =0; ����C���ɶ��Ȱ��A�p�G�S���b�C���@�}�l�_��A�����C���b���}�]�O�e�{�Ȱ����A
        Time.timeScale =0;
    }
    //��_�C��
    public void Continue()
    {
        GamePauseUI.SetActive(false);
        //Time.timeScale = 0; ��_�B��
        Time.timeScale = 1;
    }
    //�^����
    public void ToMenu()
    {
        //Time.timeScale =1; ��_����B��
        Time.timeScale = 1;
        Application.LoadLevel("Menu");
    }
}
