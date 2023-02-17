using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SilkHatController : MonoBehaviour
{
    private bool startDown = false;
    private bool getPlayer = false;
    private int count = 0;
    private int maxCount = 10; //enterキーを何回押せばいいか
    private bool one = false; //一度だけ実行

    private Vector3 startPos;
    private Rigidbody rb;

    [SerializeField] private GameObject trigger;

    MeshRenderer mr;

    GameObject player;
    PlayerController script;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;

        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerController>();

        GetComponent<MeshCollider>().enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        //床に当たるまで落ちる
        if(startDown == false) {
            transform.position -= new Vector3(0, 8.0f, 0) * Time.deltaTime;
        }

        if(startDown == true && getPlayer == false) {
            if (one == false)//床まで落ちた時は通り抜けないようにする
            {
                GetComponent<MeshCollider>().enabled = false;
                Instantiate(trigger, this.transform.position, this.transform.rotation);
                one = true;
            }
        }

        //プレイヤーにあたった時Enterキーをｎ回うったか
        if (getPlayer == true) {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                count++;
                if(maxCount == count) {
                    script.upStart = true;
                } 
            }
        }

        //上に飛ぶ
        if(getPlayer == true && script.upStart == true) {
            rb.AddForce(new Vector3(0, 10, 0));
            if(startPos.y <= transform.position.y) {
                script.upStart = false;
                Destroyer();
            }
        }
        
    }

    private void Destroyer()
    {
        Destroy(gameObject);
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            startDown = true;

        }
        if (other.gameObject.tag == "Player")
        {
            getPlayer = true;

        }
    }


}
