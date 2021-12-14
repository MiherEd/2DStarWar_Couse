using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("���a���ʳt��")]
    public float Speed;
    [Header("���a������mX�̤j��")]
    public float Xmax;
    [Header("���a������mX�̤p��")]
    public float Xmin;
    [Header("���a������mY�̤j��")]
    public float Ymax;
    [Header("���a������mY�̤p��")]
    public float Ymin;

    [Header("�����ƹ�/����O�_���I���쭸��")]
    public bool FingerState;

    [Header("�P�_�O�_�w�g�}�l�ޱ��n��")]
    public bool JoystickState;
    [Header("�P�_�ޱ��覡�O�_���n��")]
    public bool IsJoystick;

    //�C�|android���a�C�����A
    public enum PlayerStatus
    {
        Acceleration, //����n��
        Finger, //������ۭ���
        Joystick //����n��
    }

    //�ŧi�C�|���
    [Header("�C�|Android���a�C�����A")]
    public PlayerStatus playerStatus;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        #region ��L�ƹ����O����
        /*PC
         * �ƹ����O
         * Input.GetMouseButtonDown: ����U�ƹ�����A����̭����{���u�|����@��
         * 0 = �ƹ����� 1 = �ƹ��k�� 2 = �ƹ��u��
         * Input.GetMouseButtonUp: ����U�ƹ���B��}�A����̭����{���u�|����@��
         * Input.GetMouseButtonUp: �������۷ƹ���A����̭����{���|�������         
        if (Input.GetMouseButtonDown(0))
            Debug.Log("GetMouseButtonDown - �ƹ�����");
        if (Input.GetMouseButtonUp(0))
            Debug.Log("GetMouseButtonDown - �ƹ�����");
        if (Input.GetMouseButton(0))
            Debug.Log("GetMouseButtonDown - �ƹ�����");
        */

        /*
        * ��L���O
        *
        *
        * Input.GetKeyDown(): ����U��L��A����̭����{���u�|����@��
        * Input.GetKeyUp(): ����U��L��B��}�A����̭����{���u�|����@��
        * Input.GetKey(): ����L�������ۡA����̭����{���|�������        
        if (Input.GetKeyDown(KeyCode.Space))
            Debug.Log("GetKeyDown - �ť���");
        if (Input.GetKeyUp(KeyCode.Space))
            Debug.Log("GetKeyUp - �ť���");
        if (Input.GetKey(KeyCode.Space))
            Debug.Log("GetKey - �ť���");
        */
        #endregion

        #region �@�몱�a�첾�g�k

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

        #region �@�뭭��a��m�g�k

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
                //���O�ϥ�Joystick
                IsJoystick = false;
                break;
            case PlayerStatus.Finger:
                #region 3D�g�u�g�k
                /*
                //3D Raycast �g�u�g�k�A�u��Φb3D��Collider�W
                //�q�ƹ��I�����a��A�ഫ��Unity 3�������y�Ц�m�A�D��v���¦��y�Ц�m��V�o�X�@��g�u
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //�P�_�g�u�O�_�����쪫��
                RaycastHit hit;
                //�p�G���U�ƹ�����
                if(Input.GetMouseButton(0)){
                   //�o�g�g�u
                   if (Physics.Raycast(ray, out hit, 10000f))
                   {
                       //�q�D��v������m���_�I�A�g�u���쪫�󪺦�m���ͤ@���u�A���u�u�bUnity�s��������ਣ
                       Debug.DrawLine(ray.origin, hit.point);
                       //�p�G�g�u���쪫��W�٬����a
                       if (hit.collider.name == "black")
                           FingerState = true;
                       else
                           FingerState = false;
                }
                */
                #endregion
                #region 2D�g�u�g�k
                //2D Raycast�g�k�A�u��Φb2D��Collider�W
                //�p�G���U�ƹ�����
                if (Input.GetMouseButton(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    //����v���o�X�@��2���g�u
                    RaycastHit2D hit2D = Physics2D.Raycast(ray.origin, ray.direction, 10000f);
                    //�P�_�g�u�O�_���쪱�a
                    if (hit2D.collider.name == "black")
                        FingerState = true;
                    else
                        FingerState = false;
                }
                if (Input.GetMouseButtonUp(0))                 
                    FingerState = false;
                #endregion

                //�����ƹ���m Input.mousePosition
                //�ù����y�Ц�m�ഫ��Unity��3���y�Ъ��覡 Camera.main.ScreenToWorldPoint(�ƹ��y��)
                //Unity��3���y���ഫ���ù����y�Ц�m Camera.main.WorldToScreenPoint(Unity������y��)
                //�p�G���/�ƹ��I�F����
                if (FingerState)
                {
                    //�N�ƹ��I�����a���ഫ��Unity�����T���y��
                    Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    //�������y�Ц�mŪ����ƹ�/����I���ഫ�᪺�y�Э�
                    transform.position = new Vector3(pos.x, pos.y, 0f);
                }
                //���O�ϥ�Joystick
                IsJoystick = false;
                break;
            case PlayerStatus.Joystick:
                //�O�ϥ�Joystick
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

        //���a���y�Ц�m = �T��();
        //Mathf�ƾ�.Clamp����(�n����Ѽ�,�̤p��,�̤j��)�A���O�̤p�̤j�Ȧ�m�����A��
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, Xmin, Xmax), 
            Mathf.Clamp(transform.position.y, Ymin, Ymax), 
            transform.position.z);      
    }
    /*
    //�ƹ�/����I���쭸��(���a)
    void OnMouseDown()
    {        
        FingerState = true;
    }
    //�ƹ�/������}����(���a)
    void OnMouseUp()
    {
        FingerState = false;
    }
    */
    //�}�l�ޱ� Joystick
    public void isUsingJoystick()
    {
        JoystickState = true;
    }
    //�����ޱ� Joystick
    public void IsntUsingJoystick()
    {
        JoystickState = false;
    }
    //���b�ޱ� Joystick
    public void UsingJoystick(Vector3 pos) 
    {
        if (JoystickState && IsJoystick)
            transform.Translate(pos.x * Speed, pos.y * Speed, 0);    
    }
}
