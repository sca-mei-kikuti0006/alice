using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{

    [SerializeField] Scene scene;
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Explanation");
    }
    public void OnClickQuittButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
