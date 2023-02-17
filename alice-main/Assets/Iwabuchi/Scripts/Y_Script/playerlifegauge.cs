using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerLifegauge : MonoBehaviour
{
    //　HP
     private int hp;
    //　LifeGaugeスクリプト
    [SerializeField] private LifeGauge lifeGauge;
    [SerializeField] Scene scene;

    GameObject Player;
    AliceSize SizeScript;

    private string enemyTag = "Enemy";

    // Start is called before the first frame update
    void Start()
    {
            hp = 5;

        //　体力ゲージに反映
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

    //　ダメージ処理メソッド（全削除＆HP分作成）
    public void Damage(int damage)
    {
        hp -= damage;
        //　0より下の数値にならないようにする
        hp = Mathf.Max(0, hp);

        if (hp >= 0)
        {
            lifeGauge.SetLifeGauge(hp);
        }
    }
    //　ダメージ処理メソッド（ダメージ数分だけアイコンを削除）
    public void Damage2(int damage)
    {
        hp -= damage;
        if (hp < 0)
        {
            //　ダメージ調整
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
