using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player");
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
        /**
        float RotY = 0.0f;
        if (Input.GetKey(KeyCode.K) && transform.localEulerAngles.y >= -20.0f)
        {
            RotY -= 1f;
        }

        if (Input.GetKey(KeyCode.L) && transform.localEulerAngles.y <= 20.0f)
        {
            RotY += 1f;
        }

        if(direY <= 20.0f)
        {
            transform.localEulerAngles.y = 20.0f;
        }
        if (direY >= -20.0f)
        {
            transform.localEulerAngles.y = -20.0f;
        }
        
        transform.Rotate(0f, RotY, 0f);
**/

    }
}
