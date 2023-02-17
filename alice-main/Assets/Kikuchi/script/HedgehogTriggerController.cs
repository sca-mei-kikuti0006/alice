using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgehogTriggerController : MonoBehaviour
{
    private float countTime;
    public float nextTime = 1.0f;
    

    [SerializeField] private GameObject hedgehog;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;

        if(countTime > nextTime) {
            Instantiate(hedgehog, transform.position, transform.rotation);
            countTime = 0f;
        }

    }
}
