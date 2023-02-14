using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class playerdamage : MonoBehaviour
{

    [SerializeField]
    private Slider hpSlider;

   

    private string enemyTag = "Enemy";
    
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            Debug.Log("ìGÇ∆ê⁄êGÇµÇΩÅI");
            hpSlider.value -=1;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
