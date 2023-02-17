using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] int rot;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rot, 0, 0));
    }
}
