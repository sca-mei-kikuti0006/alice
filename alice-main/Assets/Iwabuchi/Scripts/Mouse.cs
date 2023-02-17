using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Del", 18f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }
    private void Del()
    { 
        Destroy(gameObject);
    }
}
