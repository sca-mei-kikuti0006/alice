using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleC : MonoBehaviour
{

    GameObject Player;
    PlayerController SpeedS;

    void Start()
    {
        Player = GameObject.Find("Player");
        SpeedS = Player.GetComponent<PlayerController>();
    }

    
    
}
