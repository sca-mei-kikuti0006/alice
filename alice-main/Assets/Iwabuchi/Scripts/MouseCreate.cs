using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCreate : MonoBehaviour
{
    Transform myTransform;
    public GameObject MousePrefab;
    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.transform;
        Vector3 pos = myTransform.position;
        Instantiate(MousePrefab, pos, Quaternion.Euler(0, -90, 0));

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.frameCount % 350 == 0)
        {
            Vector3 pos = myTransform.position; 
            Instantiate(MousePrefab, pos, Quaternion.Euler(0,-90,0));
        }
    }
}
