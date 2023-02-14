using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalTime : MonoBehaviour
{
    public Text TimeText;
    float Time;

    // Start is called before the first frame update
    void Start()
    {
        //TimerScriptから時間を取得、成形して表示
        Time = TimerScript.GetTime();
        TimeText.text = ((int)(Time / 60)).ToString("00") + ":" + ((int)Time % 60).ToString("00");
    }
}
