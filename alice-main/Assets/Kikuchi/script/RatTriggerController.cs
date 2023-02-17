using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RatTriggerController : MonoBehaviour
{
    [SerializeField] private GameObject rat;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(rat, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
