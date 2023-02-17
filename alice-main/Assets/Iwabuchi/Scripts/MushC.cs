using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushC : MonoBehaviour
{
    [SerializeField] float up;
    GameObject Player;

    void Start()
    {
        Player = GameObject.Find("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, up, 0f), ForceMode.VelocityChange);
        }
    }
}
