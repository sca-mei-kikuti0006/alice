using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceMove : MonoBehaviour
{
    private PlayerController playerController;
    private Animator animator;
    private Vector3 Stop;

    Rigidbody rigid;
    private Vector3 speed;
    private Vector3 RunSpeed;//歩きモーションの上限値
    private Vector3 negaRunSpeed;//歩きモーションの下限値

    void Start()
    {
        //アニメーターを取得
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        rigid = GameObject.Find("Player").GetComponent<Rigidbody>();

        Stop = new Vector3(0, 0, 0);
        RunSpeed = new Vector3(8.1f,0,8.1f);
        negaRunSpeed = new Vector3(-8.1f,0,-8.1f);
    }

    private void Update()
    {
        if (playerController.jumpNow == true)//ジャンプ中はjumpを流す
        {
            animator.SetBool("isStand", false);
            animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isJump", false);
        }
        
        if(playerController.jumpNow == false)
        {
            if(playerController.movingVelocity != Stop)
            {
                /*
                //x軸のスピードが下限以上、上限以下なら歩く
                    if (-8.1f < playerController.movingVelocity.x && playerController.movingVelocity.x < 8.1f)
                    {

                        animator.SetBool("isRun", false);
                        animator.SetBool("isStand", false);
                        animator.SetBool("isWalk", true);
                    }
                //z軸のスピードが下限以上、上限以下なら歩く
                    else if (-8.1f < playerController.movingVelocity.z && playerController.movingVelocity.z < 8.1f)
                    {
                        animator.SetBool("isRun", false);
                        animator.SetBool("isStand", false);
                        animator.SetBool("isWalk", true);
                    }
                    else
                    {
                        animator.SetBool("isWalk", false);
                        animator.SetBool("isStand", false);
                        animator.SetBool("isRun", true);
                    }
                */
                if(-8.1f < playerController.rb.velocity.magnitude && playerController.rb.velocity.magnitude < 8.1f)
                {
                    animator.SetBool("isRun", false);
                    animator.SetBool("isStand", false);
                    animator.SetBool("isWalk", true);
                }
                else
                {
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isStand", false);
                    animator.SetBool("isRun", true);
                }
                    
            }//動きがなければ止まる
            if(playerController.movingVelocity == Stop)
            {
                animator.SetBool("isWalk", false);
                animator.SetBool("isRun", false);
                animator.SetBool("isStand", true);
            }
        }
            
        //magunitude
    }
}