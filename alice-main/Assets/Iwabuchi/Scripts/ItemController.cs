using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public AudioClip se;
    //AudioSource audiosouce1;

    void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(se, transform.position);
            Destroy(gameObject);
        }
    }
}
