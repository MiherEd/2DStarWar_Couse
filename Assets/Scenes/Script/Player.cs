using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("玩家移動速度")]
    public float Speed;
    [Header("玩家飛機位置X最大值")]
    public float Xmax;
    [Header("玩家飛機位置X最小值")]
    public float Xmin;
    [Header("玩家飛機位置Y最大值")]
    public float Ymax;
    [Header("玩家飛機位置Y最小值")]
    public float Ymin;

    [Header("偵測滑鼠/手指是否有點擊到飛機")]
    public bool FingerState;

    [Header("判斷是否已經開始操控搖桿")]
    public bool JoystickState;
    [Header("判斷操控方式是否為搖桿")]
    public bool IsJoystick;

    //列舉android玩家遊戲狀態
    public enum PlayerStatus
    {
        Acceleration, //手機搖桿
        Finger, //手指壓著飛機
        Joystick //手機搖桿
    }

    //宣告列舉辨數
    [Header("列舉Android玩家遊戲狀態")]
    public PlayerStatus playerStatus;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        #region 鍵盤滑鼠指令介紹
        /*PC
         * 滑鼠指令
         * Input.GetMouseButtonDown: 當按下滑鼠按鍵，條件裡面的程式只會執行一次
         * 0 = 滑鼠左鍵 1 = 滑鼠右鍵 2 = 滑鼠滾輪
         * Input.GetMouseButtonUp: 當按下滑鼠鍵且放開，條件裡面的程式只會執行一次
         * Input.GetMouseButtonUp: 當持續按著滑鼠鍵，條件裡面的程式會持續執行         
        if (Input.GetMouseButtonDown(0))
            Debug.Log("GetMouseButtonDown - 滑鼠左鍵");
        if (Input.GetMouseButtonUp(0))
            Debug.Log("GetMouseButtonDown - 滑鼠左鍵");
        if (Input.GetMouseButton(0))
            Debug.Log("GetMouseButtonDown - 滑鼠左鍵");
        */

        /*
        * 鍵盤指令
        *
        *
        * Input.GetKeyDown(): 當按下鍵盤鍵，條件裡面的程式只會執行一次
        * Input.GetKeyUp(): 當按下鍵盤鍵且放開，條件裡面的程式只會執行一次
        * Input.GetKey(): 當鍵盤鍵持續按著，條件裡面的程式會持續執行        
        if (Input.GetKeyDown(KeyCode.Space))
            Debug.Log("GetKeyDown - 空白鍵");
        if (Input.GetKeyUp(KeyCode.Space))
            Debug.Log("GetKeyUp - 空白鍵");
        if (Input.GetKey(KeyCode.Space))
            Debug.Log("GetKey - 空白鍵");
        */
        #endregion

        #region 一般玩家位移寫法

        /*
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            //transform.Translate(0, 0.1f, 0);
            transform.Translate(Vector3.up* Speed);
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            //transform.Translate(0, -0.1f, 0);
            transform.Translate(Vector3.down* Speed);
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            //transform.Translate(-0.1f, 0, 0);
            transform.Translate(Vector3.left* Speed);
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            //transform.Translate(0.1f, 0, 0);
            transform.Translate(Vector3.right* Speed);
        */
        #endregion

        #region 一般限制玩家位置寫法

        //PC
#if UNITY_STANDALONE_WIN
        transform.Translate(Input.GetAxis("Horizontal") * Speed, Input.GetAxis("Vertical")*Speed,0);
#endif
        //Mobile
#if UNITY_ANDROID
        switch (playerStatus)
        {
            case PlayerStatus.Acceleration:
                transform.Translate(Input.acceleration.x * Speed, Input.acceleration.y * Speed, 0);
                //不是使用Joystick
                IsJoystick = false;
                break;
            case PlayerStatus.Finger:
                #region 3D射線寫法
                /*
                //3D Raycast 射線寫法，只能用在3D的Collider上
                //從滑鼠點擊的地方，轉換成Unity 3維忠的座標位置，主攝影機朝此座標位置方向發出一到射線
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //判斷射線是否有打到物體
                RaycastHit hit;
                //如果按下滑鼠左鍵
                if(Input.GetMouseButton(0)){
                   //發射射線
                   if (Physics.Raycast(ray, out hit, 10000f))
                   {
                       //從主攝影機的位置維起點，射線打到物件的位置產生一條線，此線只在Unity編輯視窗中能見
                       Debug.DrawLine(ray.origin, hit.point);
                       //如果射線打到物件名稱為玩家
                       if (hit.collider.name == "black")
                           FingerState = true;
                       else
                           FingerState = false;
                }
                */
                #endregion
                #region 2D射線寫法
                //2D Raycast寫法，只能用在2D的Collider上
                //如果按下滑鼠左鍵
                if (Input.GetMouseButton(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    //朝攝影機發出一條2維射線
                    RaycastHit2D hit2D = Physics2D.Raycast(ray.origin, ray.direction, 10000f);
                    //判斷射線是否打到玩家
                    if (hit2D.collider.name == "black")
                        FingerState = true;
                    else
                        FingerState = false;
                }
                if (Input.GetMouseButtonUp(0))                 
                    FingerState = false;
                #endregion

                //偵測滑鼠位置 Input.mousePosition
                //螢幕的座標位置轉換成Unity內3維座標的方式 Camera.main.ScreenToWorldPoint(滑鼠座標)
                //Unity內3維座標轉換成螢幕的座標位置 Camera.main.WorldToScreenPoint(Unity內物件座標)
                //如果手指/滑鼠點了飛機
                if (FingerState)
                {
                    //將滑鼠點擊的地方轉換成Unity內的三維座標
                    Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    //飛機的座標位置讀取到滑鼠/手指點擊轉換後的座標值
                    transform.position = new Vector3(pos.x, pos.y, 0f);
                }
                //不是使用Joystick
                IsJoystick = false;
                break;
            case PlayerStatus.Joystick:
                //是使用Joystick
                IsJoystick = true;
                break;
        }
        
        #endif
        /*
        if (transform.position.x < Xmin)
            transform.position = new Vector3(Xmin, transform.position.y, transform.position.z);
        if (transform.position.x > Xmax)
            transform.position = new Vector3(Xmax, transform.position.y, transform.position.z);
        if (transform.position.y < Ymin)
            transform.position = new Vector3(transform.position.x,Ymin,transform.position.z);
        if (transform.position.y > Ymax)
            transform.position = new Vector3(transform.position.x,Ymax,transform.position.z);
        */
        #endregion

        //玩家的座標位置 = 三維();
        //Mathf數學.Clamp限制(要限制的參數,最小值,最大值)，切記最小最大值位置不能顛倒
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, Xmin, Xmax), 
            Mathf.Clamp(transform.position.y, Ymin, Ymax), 
            transform.position.z);      
    }
    /*
    //滑鼠/手指點擊到飛機(玩家)
    void OnMouseDown()
    {        
        FingerState = true;
    }
    //滑鼠/手指離開飛機(玩家)
    void OnMouseUp()
    {
        FingerState = false;
    }
    */
    //開始操控 Joystick
    public void isUsingJoystick()
    {
        JoystickState = true;
    }
    //結束操控 Joystick
    public void IsntUsingJoystick()
    {
        JoystickState = false;
    }
    //正在操控 Joystick
    public void UsingJoystick(Vector3 pos) 
    {
        if (JoystickState && IsJoystick)
            transform.Translate(pos.x * Speed, pos.y * Speed, 0);    
    }
}
