using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//まノUnity UI祘Α畐
using UnityEngine.UI;

public class BGM : MonoBehaviour
{
    [Header("北秖")]
    public Slider AudioSilder;
    //public AudioSource BGM_Audio;
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.pause = false;
        Static.SaveAudiovolueme = 0.6f;
        //и纗计AudioSlider
        // AudioSlider = 办跑计把计
        AudioSilder.value = Static.SaveAudiovolueme;
    }
    
    // Update is called once per frame
    void Update()
    {
           //AudioListener.volume 秖计0f-1f
           //Slider计=0f-1f
           //俱砰羘秖=Slider秸俱计
        AudioListener.volume = AudioSilder.value;
        // AudioSlider = 办跑计把计
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