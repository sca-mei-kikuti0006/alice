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
            scale.x = 0.25f;
            scale.y = 0.5f;
            scale.z = 0.25f;
            gameObject.transform.localScale = scale;
            aliceBig = false;
            Debug.Log("è¨Ç≥Ç≠Ç»Ç¡ÇΩ");

        }
        if (collision.gameObject.CompareTag("BigBerry") && aliceBig == false)
        {
            Vector3 pos = myTransform.position;
            pos.y += 1f;
            //Vector3 scale = new Vector3(1, 1, 1);
            scale.x = 0.75f;
            scale.y = 2f;
            scale.z = 0.75f;
            gameObject.transform.localScale = scale;
            aliceBig = true;
            Debug.Log("Ç≈Ç©Ç≠Ç»Ç¡ÇΩ");
        }
    }
}
/**
 ÉAÉäÉXÇÃëÂÇ´Ç≥
ëÂÅ@x 0.75, y 2, z 0.75
è¨  z 0.25, y 0.5, z 0.25
 **/