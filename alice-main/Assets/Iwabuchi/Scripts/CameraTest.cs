using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour
{

    GameObject Player;
    PlayerController AreaC;

    // 1フレーム前の位置
    //private Vector3 _prevPosition;
    private float rot;
    private bool inArea = false;

    private void Start()
    {
        Player = GameObject.Find("Player");
        AreaC = Player.GetComponent<PlayerController>();
    }


    private void Update()
    {
        //rot = transform.localEulerAngles.x;
        Transform myTransform = this.transform;
        bool inArea = AreaC.inArea;


        if(inArea == true)
        {//エリアに入ったらカメラの角度を変更する
            
            if (transform.localEulerAngles.x <= 30.0f)
            {
                transform.Rotate(new Vector3(30, 0, 0) * Time.deltaTime);
            }
        }
        else
        {//エリア外ならカメラの角度を戻す
            
            if (transform.localEulerAngles.x >= 18.0f)
            {
                transform.Rotate(new Vector3(-30, 0, 0) * Time.deltaTime);
            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Area"))
        {
            Debug.Log("エリア内");
            inArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Area"))
        {
            Debug.Log("エリア外");
            inArea = false;
        }
    }



}
