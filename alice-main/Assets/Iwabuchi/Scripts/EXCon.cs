using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXCon : MonoBehaviour
{
    int RabCounter;
    // Start is called before the first frame update
    void Start()
    {
        RabCounter = RabitCount2.Cr;
        if(RabCounter >= 6)
        {
            gameObject.SetActive(true);
        }
    }
}
