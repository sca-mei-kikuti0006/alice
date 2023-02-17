using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollSetting : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoint;
    [SerializeField] private GameObject Doll;

    // Start is called before the first frame update
    void Start()
    {//設定したポイントからランダムにウサギを置く
        GameObject randomPoint = spawnPoint[Random.Range(0, spawnPoint.Length)];
        Instantiate(Doll, randomPoint.transform.position, Quaternion.identity);
    }
}