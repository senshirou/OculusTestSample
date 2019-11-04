using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speed : MonoBehaviour
{
    Vector3 latestPos; //Vector3型を定義
    public float speed;　//スピードの定義
    [SerializeField] TextMesh RightSpeed;　//テキストメッシュをシリアライズ化

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //距離/フレームからベクトル距離を求める。
        speed = ((transform.position - latestPos) / Time.deltaTime).magnitude;
        latestPos = transform.position;
        
        RightSpeed.text = speed.ToString("F2");
        
    }
}
