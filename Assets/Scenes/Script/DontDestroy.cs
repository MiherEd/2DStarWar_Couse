using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        //DontDestroyOnLoad(物件型態)當切換場景時，不要刪除此物件
        //gameObject 代表的事物件身自己，例如腳本給BGM，那gameObject = BGM
        //GameObject 變數型態
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
