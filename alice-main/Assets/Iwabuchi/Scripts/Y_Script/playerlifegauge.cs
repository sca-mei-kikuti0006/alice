using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerLifegauge : MonoBehaviour
{
    //�@HP
     private int hp;
    //�@LifeGauge�X�N���v�g
    [SerializeField] private LifeGauge lifeGauge;
    [SerializeField] Scene scene;

    GameObject Player;
    AliceSize SizeScript;

    private string enemyTag = "Enemy";

    // Start is called before the first frame update
    void Start()
    {
            hp = 5;

        //�@�̗̓Q�[�W�ɔ��f
        lifeGauge.SetLifeGauge(hp);

        Player = GameObject.Find("Player");
        SizeScript = Player.GetComponent<AliceSize>();
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
        bool Big = SizeScript.aliceBig;

        if (collision.gameObject.tag == "Enemy")
         {
             if(Big == true)
             {
                 Damage(1);
             }
             if(Big == false)
             {
                 Damage(2);
             }
         }
        if(collision.gameObject.tag == "Poison")
        {
            Damage(1);
        }
        if(collision.gameObject.tag == "Mouse")
        {
            Damage(2);
        }

    }
}
