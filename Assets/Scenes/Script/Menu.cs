using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    [Header("��J�M�פ���BGM����")]
    public GameObject BGM;
    void Awake()
    {
        //��M����-�W�rGameObject.Find("����W��");
        //��M����-����
        //���GameObject.FindWithTag("���ҦW��")
        //���GameObject.FindGameObjectsWithTag("���ҦW��")
        //�p�G�����W�S���b��BGM����
        if (GameObject.FindGameObjectsWithTag("BGM").Length < 1)
        {
            //�ʺA�ͦ�Instantiate(�n�ͦ�������,�ͦ���m,�ͦ��������)
            // Instantiate(BGM); �q�{��m
            //�ʺA�ͦ�BGM
            //�ͦ�����m�p�G�n�q�{�A�g�k��transform.postion
            //�p�G��m�n�]�w�Y�@�Ӧ�m�I�A�g�k��new Vector3(�a�J3����m)
            //�ͦ������׭Ȧp�G�n�q�{�A�g�k��transform.rotation
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

    //public���}: �i�H����L����ε{���X�i��I�s
    //private�p��:�L�k����L����ε{���X�I�s
    public void LoadScene()
    {
        //��������:
        //Application.LoadLevel("�����W��"); ��J�����W��
        //Application.LoadLevel(0); ��J�����̭���ID
        //Application.loadedLevel; Ū����e�����W��
        //Application.LoadLevel(Application.loadedLevel); ���sŪ����e����
        Application.LoadLevel("Level");
    }
    public void QuitGame()
    {
        //Application.Quit(); �����C�������ɮ�
        Application.Quit();
    }

}
