using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Clear : MonoBehaviour
{
    [SerializeField] Scene scene;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("ClearScene");
        }

    }

}
