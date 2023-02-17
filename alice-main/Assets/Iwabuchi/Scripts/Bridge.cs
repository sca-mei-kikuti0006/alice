using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    GameObject Player;
    AliceSize SizeScript;

    private Rigidbody rb;
    private BoxCollider bc;

    private Vector3 initialPos;//初期位置
    [SerializeField] float gravityPower;//重力

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
        if (collision.gameObject.CompareTag("Player") && Big== true)//アリスが小さいなら足場は動かない
        {//足場の色を変えてFallを呼び出す
            hitplayer = true;
            Invoke("Fall", 2f);

        }
    }

    private void Fall()//足場を落としてResetを呼び出す
    {
        hitplayer = false;
        bc.enabled = false;
        rb.isKinematic = false;
        rb.AddForce(new Vector3(0, gravityPower, 0));
        Invoke("Reset", 2f);
    }

    private void Reset()//足場を元の位置に戻す
    {
        bc.enabled = true;
        rb.isKinematic = true;
        transform.position = initialPos;
    }

}
