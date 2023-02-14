using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Clear : MonoBehaviour
{
    [SerializeField] Scene scene;
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            SceneManager.LoadScene("ClearScene");
        }
        if(Input.GetKey(KeyCode.X))
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
    
}
