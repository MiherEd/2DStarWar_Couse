using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("�h�[�ɶ���N�ľ��R��")]
    public float DeleteTime;
    [Header("���ʳt��")]
    public float Speed;

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
        //�ľ��첾
        transform.Translate(Vector3.down * Speed);
    }
}
