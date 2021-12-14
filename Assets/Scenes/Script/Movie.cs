using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
//�ޥ�Unity Video �{���w
using UnityEngine.Video;
//�s�����������g�k�A�����ޥ�SceneManager�{���w
using UnityEngine.SceneManagement;

public class Movie : MonoBehaviour
{
    [Header("�v��VideoPlayer����")]
    public VideoPlayer MovieObject;
    // �����O�_�i�H�}�l�����v�����񧹲�
    bool Run;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        //�v�������q  = Slider�Ȧs�����q
        MovieObject.SetDirectAudioVolume(0,Static.SaveAudiovolueme);
        //��M��������BGM���� ��AudioSource������i������
        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("MovieObject.frame: " + MovieObject.frame);
        //Debug.Log("MovieObject.frame: " + Convert.ToInt64(MovieObject.frameCount));
        //�p�G�v���ثe����i�� = �v��frame �`���� �N��v�����񧹲�
        /*if(MovieObject.frame >= Convert.ToInt64(MovieObject.frameCount)-2)
         {
             //�NBGM��AudioSource���ض}��
             GameObject.FindWithTag("BGM").GetComponent<AudioSource>().enabled = true;
             //����U�@�ӳ���
             SceneManager.LoadScene("Game");
         }*/
        // �C���}�l��A�}�l�p��
        timer += Time.deltaTime;
        // �W�L3���}�l����
        if (timer > 3f)        
            Run = true;
        if (MovieObject.isPlaying && Run)
        {
            SceneManager.LoadScene("Game");
            GameObject.FindWithTag("BGM").GetComponent<AudioSource>().enabled = true;
        }
    }

    public void SkipButton()
    {
        SceneManager.LoadScene("Game");
        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().enabled = true;
    }
}
