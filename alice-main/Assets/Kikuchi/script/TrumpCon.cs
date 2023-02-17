using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpCon : MonoBehaviour
{
    private GameObject target;
    GameObject objParent;
    TrumpTriggerController trigger;
    private Animator animator;

    private float speed = 0.01f;//ƒgƒ‰ƒ“ƒv•º‚Ì‘¬“x
    private bool stop = false;

    private float stopTime = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        objParent = transform.parent.gameObject;
        trigger = objParent.GetComponent<TrumpTriggerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.chase == true && stop == false)
        {
            animator.SetBool("Walk", true);
            var direction = target.transform.position - transform.position;
            direction.y = 0;

            var lookRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);

            
            transform.position += transform.forward * speed;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            stop = true;
            animator.SetBool("Walk", true);
            Invoke("Walking", 1f);
        }
    }

    private void Walking()
    {
        stop = false;
    }
}
