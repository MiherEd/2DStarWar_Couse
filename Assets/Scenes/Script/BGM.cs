using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�ޥ�Unity UI�{���w
using UnityEngine.UI;

public class BGM : MonoBehaviour
{
    [Header("����q")]
    public Slider AudioSilder;
    //public AudioSource BGM_Audio;
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.pause = false;
        Static.SaveAudiovolueme = 0.6f;
        //���X�ڭ��x�s���ƭȨ�AudioSlider
        //���X�� AudioSlider = �����ܼưѼ�
        AudioSilder.value = Static.SaveAudiovolueme;
    }
    
    // Update is called once per frame
    void Update()
    {
           //AudioListener.volume ���q�ƭȬɩ�0f-1f
           //Slider���ƭ�=0f-1f
           //�����n�����q=Slider�վ㪺�ƭ�
        AudioListener.volume = AudioSilder.value;
        //���X�� AudioSlider = �����ܼưѼ�
        Static.SaveAudiovolueme = AudioSilder.value;
    }
    public void ControlBGM(bool Control)
    {
        if (Control)
            //BGM_Audio.Play();
            AudioListener.pause = false;
        else
            AudioListener.pause = true;
            //BGM_Audio.Stop();
    }
}