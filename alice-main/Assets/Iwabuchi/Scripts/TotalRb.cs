using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalRb : MonoBehaviour
{
    public Text RabText;
    int RabCounter;
    // Start is called before the first frame update
    void Start()
    {
        RabCounter = RabitCount.CountRabit;
        RabText.text = "X" + ((int)RabCounter).ToString("00");
    }
}
