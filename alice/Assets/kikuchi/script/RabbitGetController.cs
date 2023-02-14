using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitGetController: MonoBehaviour
{
    private int _getRabbit = 0;
    private int count = 0;

    GameObject SceneManager;
    ScenesManagerController scMa;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager = GameObject.Find("SceneManager");
        scMa= SceneManager.GetComponent<ScenesManagerController >();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")//player‚ª”ÍˆÍ“à‚É“ü‚Á‚½‚ç’Ç]
        {
            if(count == 0)
            {
                scMa.getRabbit++;
                count++;
                Destroy(gameObject);
            }
           
        }
    }

}
