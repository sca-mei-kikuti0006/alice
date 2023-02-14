using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrumpController : MonoBehaviour
{
    GameObject objParent;
    TrumpTriggerController trigger;

    private GameObject target;
    private float speed = 0.005f;//ƒgƒ‰ƒ“ƒv•º‚Ì‘¬“x
    private bool stop = true;

    private float stopTime = 0.3f;

    void Start()
    {
        objParent = transform.parent.gameObject;
        trigger = objParent.GetComponent<TrumpTriggerController>();

        target = GameObject.Find("player");
    }

    void Update()
    {
        if (trigger.chase == true && stop == true)
        {
            transform.LookAt(target.transform);
            transform.position += transform.forward * speed;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")//player‚ª“–‚½‚Á‚½‚ç
        {
            stop = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")//player‚ª“–‚½‚Á‚½‚ç
        {
            StartCoroutine(DelayCoroutine());
        }
    }
        
    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(stopTime);
        stop = true;
    }
        
    }
