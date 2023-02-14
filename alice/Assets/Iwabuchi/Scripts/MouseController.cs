using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private GameObject target;
    [SerializeField] public float Setspeed;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        speed *= Setspeed;
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
        transform.position += transform.forward * speed;
    }
}
