using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatUiController : MonoBehaviour
{
    GameObject player;
    PlayerController script;

    [SerializeField] Text text;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        script = player.GetComponent<PlayerController>();

        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(script.move == false) {
            text.enabled = true;
        }else {
            text.enabled = false;
        }
    }
}
