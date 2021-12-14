using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBullet : MonoBehaviour
{
    [Header("�]�w�T�w�C�h�֬�I�s�@��function")]
    public float Timer;
    [Header("�n�ͦ����l�u����")]
    public GameObject Bullet;
    [Header("�l�u�ͦ�����m")]
    public GameObject BulletPos_L;
    public GameObject BulletPos_R;
    // Start is called before the first frame update
    void Start()
    {
        //����I�sfunction - InvokeRepeating("function�W��",�C���}�l��n�h�[�i��Ĥ@���I�sfunction, �ĤG���H��C��Delay�h�֮ɶ��I�sfunction)
        //�H�����
        InvokeRepeating("ProduceBullet", Timer, Timer);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void ProduceBullet()
    {   //�ʺA�ͦ��l�u�b�Ū��󪺦�m
        Instantiate(Bullet, BulletPos_L.transform.position, BulletPos_L.transform.rotation); 
        Instantiate(Bullet, BulletPos_R.transform.position, BulletPos_R.transform.rotation); 
    }
}
