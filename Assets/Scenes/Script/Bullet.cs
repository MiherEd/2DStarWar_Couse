using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("�h�[�ɶ���N�l�u�R��")]
    public float DeleteTime;
    [Header("���ʳt��")]
    public float Speed;

    [Header("���a�z�����S��")]
    public GameObject PlayerVFX;
    [Header("�ľ��z�����S��")]
    public GameObject EnemyVFX;
    // Start is called before the first frame update
    void Start()
    {
        //�S���������ľ������p�U�A�L�@�}�l��ۤv�R��
        //����R��Destroy(�n�R��������)
        Destroy(gameObject, DeleteTime);       
    }

    // Update is called once per frame
    void Update()
    {
        //�l�u�첾
        transform.Translate(Vector3.up * Speed);
    }
    //3D�I������-��z��I���A�۱aCollider�ܼơA����ݭn�[�WCollider�MRigibody
    //OnTriggerEnter: ���Ӫ���@�I���A�p�G�⪫��S�������A��function�����{���u�|����@��
    //OnTriggerStay: ���Ӫ���I���A�p�G�⪫��S�������A��function�����{���|�������
    //OnTriggerExit: ���Ӫ���@�I���A�p�G�⪫������A��function�����{���u�|�|����@��
    //2D�I������-��z���I���A�۱aCollider2D�ܼơA����ݭn�[�W2D Collider�M2D Rigibody
    //OnTriggerEnter2D: ���Ӫ���@�I���A�p�G�⪫��S�������A��function�����{���u�|����@��
    //OnTriggerStay2D: ���Ӫ���I���A�p�G�⪫��S�������A��function�����{���|�������
    //OnTriggerExit2D: ���Ӫ���@�I���A�p�G�⪫������A��function�����{���u�|�|����@��
    void OnTriggerEnter2D(Collider2D hit)
    {
        //�p�G�O���a���l�u�A�åB�I������H�O�ľ�
        if(gameObject.tag == "PlayerBullet" && hit.GetComponent<Collider2D>().tag == "Enemy")
        {
            //Debug.Log("������ľ�");
            //�ʺA�ͦ�-�ľ��z���S��
            Instantiate(EnemyVFX, hit.transform.position, transform.rotation);

            //�l�u����ľ��H��A�������W�R�W��GM������éI�sTotal_Score();
            GameObject.Find("GM").GetComponent<GM>().Total_Score();
            //���a���l�u�n����
            Destroy(gameObject);
            //�ľ��]�n����
            Destroy(hit.gameObject);
        }
        //�p�G�O�Ǫ����l�u�A�åB�I������H�O���a
        if (gameObject.tag == "EnemyBullet" && hit.GetComponent<Collider2D>().tag == "Player")
        {
            //�ʺA�ͦ�-���a�z���S��
            Instantiate(PlayerVFX, hit.transform.position, transform.rotation);
            //Debug.Log("�����쪱�a");
            //�ľ��l�u���쪱�a�H��A�������W�R�W��GM������éI�sHurtPlayer function
            GameObject.Find("GM").GetComponent<GM>().HurtPlayer();
            //�ľ����l�u�n����
            Destroy(gameObject);
        }
    }
}

