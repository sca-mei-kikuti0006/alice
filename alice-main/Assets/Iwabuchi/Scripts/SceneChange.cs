using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    [SerializeField] Scene scene;

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Explanation");
        Time.timeScale = 1f;
    }

    public void OnClickTitleButton()
    {
        SceneManager.LoadScene("TitelScene");
    }

    public void OnClickEXButton()
    {
        SceneManager.LoadScene("EXStage");
    }

    public void OnClickQuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
