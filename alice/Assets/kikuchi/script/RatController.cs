using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour
{
    private Vector3 count;
    private float speed = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        count = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;

        if (transform.position.x-count.x >= 10) Destroy(gameObject);  //ƒe[ƒuƒ‹‚©‚ç—‚¿‚½‚çÁ‚¦‚é
        
    }
}
