using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgehogController : MonoBehaviour
{
    new Vector3 count;
    private float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        count = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 0.1f));

        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;

        if (transform.position.x - count.x >= 16) Destroy(gameObject);  //’n–Ê‚©‚ço‚½‚çÁ‚¦‚é
    }
}
