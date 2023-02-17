using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabitCount2 : MonoBehaviour
{
    public static int Cr;
    public Text TextRabit;
    // Start is called before the first frame update
    void Start()
    {
        Cr = RabitCount.CountRabit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rabbit"))
        {
            Cr++;
            TextRabit.text = "X" + ((int)Cr).ToString("00");
        }
    }
}
