using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    GameObject Player;
    AliceSize SizeScript;

    private Rigidbody rb;
    private BoxCollider bc;

    private Vector3 initialPos;//�����ʒu
    [SerializeField] float gravityPower;//�d��

    bool hitplayer = false;

    private void Start()
    {
        Player = GameObject.Find("Player");
        SizeScript = Player.GetComponent<AliceSize>();
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        initialPos = transform.position;

    }
    private void Update()
    {
        if(hitplayer == true)
        {
            GetComponent<Renderer>().material.color = new Color32(255, 165, 0, 0);
        }
        else
        {
            GetComponent<Renderer>().material.color = new Color32(180,131,36, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        bool Big = SizeScript.aliceBig;
        if (collision.gameObject.CompareTag("Player") && Big== true)//�A���X���������Ȃ瑫��͓����Ȃ�
        {//����̐F��ς���Fall���Ăяo��
            hitplayer = true;
            Invoke("Fall", 2f);

        }
    }

    private void Fall()//����𗎂Ƃ���Reset���Ăяo��
    {
        hitplayer = false;
        bc.enabled = false;
        rb.isKinematic = false;
        rb.AddForce(new Vector3(0, gravityPower, 0));
        Invoke("Reset", 2f);
    }

    private void Reset()//��������̈ʒu�ɖ߂�
    {
        bc.enabled = true;
        rb.isKinematic = true;
        transform.position = initialPos;
    }

}
