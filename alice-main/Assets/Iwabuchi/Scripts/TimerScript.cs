using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public static float CountUpTime; //経過時間
    public Text TextCountUp; //表示用テキスト

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "FirstStage")//第１ステージならリセットする
        {
            CountUpTime = 0;
        }
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