using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Start : MonoBehaviour
{
    [SerializeField] Scene scene;
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("FirstStage");
        }
        if(Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
