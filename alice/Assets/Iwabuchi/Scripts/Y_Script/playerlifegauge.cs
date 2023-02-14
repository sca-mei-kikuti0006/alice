using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerLifegauge : MonoBehaviour
{
    //�@HP
    [SerializeField] private int hp;
    //�@LifeGauge�X�N���v�g
    [SerializeField] private LifeGauge lifeGauge;
    [SerializeField] Scene scene;

    private string enemyTag = "Enemy";

    // Start is called before the first frame update
    void Start()
    {
        //�@�̗̓Q�[�W�ɔ��f
        lifeGauge.SetLifeGauge(hp);
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    //�@�_���[�W�������\�b�h�i�S�폜��HP���쐬�j
    public void Damage(int damage)
    {
        hp -= damage;
        //�@0��艺�̐��l�ɂȂ�Ȃ��悤�ɂ���
        hp = Mathf.Max(0, hp);

        if (hp >= 0)
        {
            lifeGauge.SetLifeGauge(hp);
        }
    }
    //�@�_���[�W�������\�b�h�i�_���[�W���������A�C�R�����폜�j
    public void Damage2(int damage)
    {
        hp -= damage;
        if (hp < 0)
        {
            //�@�_���[�W����
            damage = Mathf.Abs(hp + damage);
            hp = 0;
        }
        if (damage > 0)
        {
            lifeGauge.SetLifeGauge2(damage);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.tag == "Enemy")
            {
                Damage(1);
            }
    }
}
