using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverC : MonoBehaviour
{
    [SerializeField] float posx;
    [SerializeField] float posy;
    [SerializeField] float posz;

    void Update()
    {
        //Vector3 tmp = GameObject.Find("Player").transform.position;
        //GameObject.Find("Player").transform.position = new Vector3(0, 53, 270);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Player").transform.position = new Vector3(posx, posy, posz);
        }
    }
}
