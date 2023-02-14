using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    [SerializeField]
    private Slider hpSlider;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            hpSlider.value -= 1;
        }
    }
}
