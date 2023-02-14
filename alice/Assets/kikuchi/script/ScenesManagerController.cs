using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManagerController : MonoBehaviour
{
    private int _getRabbit = 0;
   
    // Update is called once per frame
    void Update()
    {
        if(_getRabbit == 3) {
            SceneManager.LoadScene("Stage4Scene");
        }
    }

    //getset
    public int getRabbit
    {
        set { this._getRabbit = value; }
        get { return this._getRabbit; }
    }
}
