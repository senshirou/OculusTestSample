using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class VRAkkadai : MonoBehaviour
{
    Rigidbody rb; //Rigidbodyを宣言
    Speed cube;   //スクリプト名Speedを使う宣言
    // Start is called before the first frame update
    void Start()
    {
        //宣言したものをコンポーネントする
        rb = GetComponent<Rigidbody>();
        cube = GetComponent<Speed>();
    }

    // Update is called once per frame
    void Update()
    {
        //Aボタンでシーンをロード。
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            SceneManager.LoadScene("OculusQuestTest");
        }

        

    }



    private void OnTriggerStay(Collider other)
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))　//左トリガーを押す。
        {
            transform.parent = GameObject.Find("LeftControllerAnchor").transform; //LeftControllerAnchorの子オブジェクトに指定。
            //useGravityのチェックを外す、isKinematicをチェック。
            rb.useGravity = false;
            rb.isKinematic = true;
        }

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))　//右トリガーを押す
        {
            transform.parent = GameObject.Find("RightControllerAnchor").transform; //LeftControllerAnchorの子オブジェクトに指定。
            //useGravityのチェックを外す、isKinematicをチェック。
            rb.useGravity = false;
            rb.isKinematic = true;
        }

        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))　//左トリガーを離す
        {
            //useGravityのチェック、isKinematicのチェックを外す。
            transform.parent = null;
            rb.isKinematic = false;
            rb.useGravity = true;
            
            //Cubeに力を加える。手の振る速さによってCubeのスピードが変わる。
            rb.AddForce(transform.forward * cube.speed, ForceMode.Impulse);
            
            

        }

        if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))  //右トリガーを離す
        {
            //useGravityのチェック、isKinematicのチェックを外す。
            transform.parent = null;
            rb.isKinematic = false;
            rb.useGravity = true;

            //Cubeに力を加える。手の振る速さによってCubeのスピードが変わる。
            rb.AddForce(transform.forward * cube.speed, ForceMode.Impulse);
            

            
        }


    }
    
}
