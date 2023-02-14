using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    GameObject Player;
    AliceSize SizeScript;

    void Start()
    {
        Player = GameObject.Find("Player");
        SizeScript = Player.GetComponent<AliceSize>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        bool State = SizeScript.aliceBig;
        if (collision.gameObject.CompareTag("Player") && State == true)
        {
            Invoke("False", 1);
            Invoke("True", 5);
            /*
            Transform myTransform = this.transform;
            int n = 0;
            if (n <= 3)
            {
                n++;
                Vector3 pos = myTransform.position;
                pos.x += 1f;
                pos.x -= 1f;
                myTransform.position = pos;
            }
            */

        }
    }
    void False()
    {
        gameObject.SetActive(false);
    }
    void True()
    {
        gameObject.SetActive(true);
    }
}
