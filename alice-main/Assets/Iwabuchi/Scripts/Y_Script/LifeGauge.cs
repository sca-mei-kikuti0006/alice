using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGauge : MonoBehaviour
{
    //�@���C�t�Q�[�W�v���n�u
    [SerializeField]
    private GameObject lifeObj;


    //�@���C�t�Q�[�W�S�폜��HP���쐬
    public void SetLifeGauge(int life)
    {
        //�@�̗͂���U�S�폜
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        //�@���݂̗̑͐����̃��C�t�Q�[�W���쐬
        for (int i = 0; i < life; i++)
        {
            Instantiate<GameObject>(lifeObj, transform);
        }
    }
    //�@�_���[�W�������폜
    public void SetLifeGauge2(int damage)
    {
        for (int i = 0; i < damage; i++)
        {
            //�@�Ō�̃��C�t�Q�[�W���폜
            Destroy(transform.GetChild(i).gameObject);
            //Destroy(transform.GetChild(transform.childCount - 1 - i).gameObject);
        }
    }
}
