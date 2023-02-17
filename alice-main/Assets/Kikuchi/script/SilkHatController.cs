using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SilkHatController : MonoBehaviour
{
    private bool startDown = false;
    private bool getPlayer = false;
    private int count = 0;
    private int maxCount = 10; //enter�L�[�����񉟂��΂�����
    private bool one = false; //��x�������s

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
        //���ɓ�����܂ŗ�����
        if(startDown == false) {
            transform.position -= new Vector3(0, 8.0f, 0) * Time.deltaTime;
        }

        if(startDown == true && getPlayer == false) {
            if (one == false)//���܂ŗ��������͒ʂ蔲���Ȃ��悤�ɂ���
            {
                GetComponent<MeshCollider>().enabled = false;
                Instantiate(trigger, this.transform.position, this.transform.rotation);
                one = true;
            }
        }

        //�v���C���[�ɂ���������Enter�L�[�����񂤂�����
        if (getPlayer == true) {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                count++;
                if(maxCount == count) {
                    script.upStart = true;
                } 
            }
        }

        //��ɔ��
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
