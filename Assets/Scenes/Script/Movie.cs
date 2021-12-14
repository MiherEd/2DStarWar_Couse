using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
//引用Unity Video 程式庫
using UnityEngine.Video;
//新版本跳場景寫法，須先引用SceneManager程式庫
using UnityEngine.SceneManagement;

public class Movie : MonoBehaviour
{
    [Header("影片VideoPlayer物建")]
    public VideoPlayer MovieObject;
    // 偵測是否可以開始偵測影片播放完畢
    bool Run;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        //影片的音量  = Slider暫存的音量
        MovieObject.SetDirectAudioVolume(0,Static.SaveAudiovolueme);
        //找尋場景中的BGM物建 讓AudioSource元件先進行關閉
        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("MovieObject.frame: " + MovieObject.frame);
        //Debug.Log("MovieObject.frame: " + Convert.ToInt64(MovieObject.frameCount));
        //如果影片目前播放進度 = 影片frame 總長度 代表影片播放完畢
        /*if(MovieObject.frame >= Convert.ToInt64(MovieObject.frameCount)-2)
         {
             //將BGM的AudioSource元建開啟
             GameObject.FindWithTag("BGM").GetComponent<AudioSource>().enabled = true;
             //跳到下一個場景
             SceneManager.LoadScene("Game");
         }*/
        // 遊戲開始後，開始計時
        timer += Time.deltaTime;
        // 超過3秒後開始偵測
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
