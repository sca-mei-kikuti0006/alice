using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public static float CountUpTime; //経過時間
    public Text TextCountUp; //表示用テキスト

    void Start()
    {
        CountUpTime = 0;
    }

    void Update()
    {
        //経過時間を整形して表示
        TextCountUp.text = ((int)(CountUpTime / 60)).ToString("00") + ":" + ((int)CountUpTime % 60).ToString("00");
        // 経過時刻を足していく
        CountUpTime += Time.deltaTime;
    }
    public static float GetTime()
    {
        return CountUpTime;
    }
}