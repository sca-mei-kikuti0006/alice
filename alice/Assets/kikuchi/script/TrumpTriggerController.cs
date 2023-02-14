using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpTriggerController : MonoBehaviour
{
    private bool _chase=false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")//playerが範囲内に入ったら追従
        {
                chase = true;

        }
    }
    void OnTriggerExit(Collider other)//通り抜けたら止まる
    {
        if (other.gameObject.tag == "Player")
        {
            chase = false;
        }
    }

    public bool chase
    {
        set { this._chase = value; }
        get { return this._chase; }
    }
}
