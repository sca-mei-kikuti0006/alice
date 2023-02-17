using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RabitCount : MonoBehaviour
{
    public static int CountRabit;
    public Text TextRabit;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "FirstStage")
        {
            CountRabit = 0;
        }
    }

    void Update()
    {
        TextRabit.text = "X" + ((int)CountRabit).ToString("00");
    }

    private void OnCollisionEnter(Collision collision)
     {
         if(collision.gameObject.CompareTag("Rabbit"))
        {
           CountRabit ++;
           
        }
     }

    public static int GetRabit()
    {
        return CountRabit;
    }
}