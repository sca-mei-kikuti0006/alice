using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHack : MonoBehaviour
{
    [SerializeField] private GameObject Wall;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Wall.GetComponent<Renderer>().material.color = new Color32(0,0,0,0);
        }

    }
}
