using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceSize : MonoBehaviour
{
    public bool aliceBig;
    void Start()
    {
        aliceBig = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 scale = new Vector3(1, 1, 1);
        Transform myTransform = this.transform;
        
        if (collision.gameObject.CompareTag("SmallBerry") && aliceBig == true)
        {
            scale.x = 30f;
            scale.y = 30f;
            scale.z = 30f;
            gameObject.transform.localScale = scale;
            aliceBig = false;
            Debug.Log("�������Ȃ���");

        }
        if (collision.gameObject.CompareTag("BigBerry") && aliceBig == false)
        {
            Vector3 pos = myTransform.position;
            pos.y += 1f;

            scale.x = 80f;
            scale.y = 80f;
            scale.z = 80f;
            gameObject.transform.localScale = scale;
            aliceBig = true;
        }
    }
}
/**
 �A���X�̑傫��
��@x 0.75, y 2, z 0.75
��  z 0.25, y 0.5, z 0.25
��80,80,80
��30,30,30
 **/