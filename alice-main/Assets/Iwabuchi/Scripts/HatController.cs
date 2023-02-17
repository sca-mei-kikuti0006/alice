using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour
{
    private float CountDown;
    private int Rest;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            CountDown = 5f;
            Rest = 10;
            CountDown -= Time.deltaTime;
            if(CountDown >= 0.1f)
            {
                if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                {
                    Rest --;

                }
            }
            else if(CountDown <= 0.0f)
            {

            }
        }
    }
}
