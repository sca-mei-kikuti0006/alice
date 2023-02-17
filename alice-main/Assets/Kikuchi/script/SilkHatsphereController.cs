using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SilkHatsphereController : MonoBehaviour
{
    private int count = 3; //点滅する回数
    private float countColer = 0.5f ;//色が変わる秒数
    private bool decision = false; //範囲内に入ったか
    private bool one = false; //一度だけ実行

    [SerializeField] private GameObject hat;
    private float hatY = 20.0f;//シルクハットが生成されるｙ座標

    MeshRenderer mr;
    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mr.material.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (decision == true)
        {
            if(one == false) {
                Instantiate(hat, new Vector3(transform.position.x, transform.position.y + hatY, transform.position.z), transform.rotation);
                StartCoroutine(DelayCoroutine());
                one = true;
            }
            decision = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            decision = true;
        }
    }

    private IEnumerator DelayCoroutine()
    {
        for (int i = 0; i < count; i++)//点滅
        {
            mr.material.color = new Color(150, 0, 0, 1);
            yield return new WaitForSeconds(countColer);
            mr.material.color = new Color(0, 0, 0, 0);
            yield return new WaitForSeconds(countColer);
            
        }
    }

    
}
