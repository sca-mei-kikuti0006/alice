using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public static float CountUpTime; //�o�ߎ���
    public Text TextCountUp; //�\���p�e�L�X�g

    void Start()
    {
        CountUpTime = 0;
    }

    void Update()
    {
        //�o�ߎ��Ԃ𐮌`���ĕ\��
        TextCountUp.text = ((int)(CountUpTime / 60)).ToString("00") + ":" + ((int)CountUpTime % 60).ToString("00");
        // �o�ߎ����𑫂��Ă���
        CountUpTime += Time.deltaTime;
    }
    public static float GetTime()
    {
        return CountUpTime;
    }
}