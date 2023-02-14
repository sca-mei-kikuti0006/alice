using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushC : MonoBehaviour
{
    [SerializeField] float up;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, up, 0f), ForceMode.VelocityChange);
            /*
            if (State == true)
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, up, 0f), ForceMode.VelocityChange);
            }
            if(State == false)
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, up * 1.5f, 0f), ForceMode.VelocityChange);
            }
            */
        }
    }
}
