using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    [SerializeField] Scene scene;
    [SerializeField] GameObject ONButton;
    [SerializeField] GameObject OFFButton;

    GameObject Player;
    PlayerController PlayerC;

    void Start()
    {
//        Player = GameObject.Find("Player");
//        PlayerC = Player.GetComponent<PlayerController>();
    }

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Explanation");
    }

    public void OnClickTitleButton()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void OnClickQuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

    public void OnClickONButton()
    {
        Player = GameObject.Find("Player");
        PlayerC = Player.GetComponent<PlayerController>();

        ONButton.SetActive(false);
        PlayerC.Running = true;
        OFFButton.SetActive(true);
    }

    public void OnClickOFFButton()
    {
        Player = GameObject.Find("Player");
        PlayerC = Player.GetComponent<PlayerController>();

        OFFButton.SetActive(false);
        PlayerC.Running = false;
        ONButton.SetActive(true);
    }

}
