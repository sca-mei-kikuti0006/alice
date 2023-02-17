using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ONOFF : MonoBehaviour
{
    [SerializeField] Scene scene;
    [SerializeField] GameObject ONButton;
    [SerializeField] GameObject OFFButton;

    GameObject Player;
    PlayerController PlayerC;

    void Start()
    {
        Player = GameObject.Find("Player");
        PlayerC = Player.GetComponent<PlayerController>();
    }

    public void OnClickONButton()
    {
        Player = GameObject.Find("Player");
        PlayerC = Player.GetComponent<PlayerController>();

        ONButton.SetActive(false);
        PlayerC.Running = false;
        OFFButton.SetActive(true);
    }

    public void OnClickOFFButton()
    {
        Player = GameObject.Find("Player");
        PlayerC = Player.GetComponent<PlayerController>();

        OFFButton.SetActive(false);
        PlayerC.Running = true;//ÉvÉåÉCÉÑÅ[ÇèÌéûëñÇÁÇπÇÈ
        ONButton.SetActive(true);
    }
}
