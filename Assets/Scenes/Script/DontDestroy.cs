using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        //DontDestroyOnLoad(���󫬺A)����������ɡA���n�R��������
        //gameObject �N���ƪ��󨭦ۤv�A�Ҧp�}����BGM�A��gameObject = BGM
        //GameObject �ܼƫ��A
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
