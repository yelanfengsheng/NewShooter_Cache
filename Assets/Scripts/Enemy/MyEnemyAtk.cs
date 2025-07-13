using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyEnemyAtk : MonoBehaviour
{
    public int enemyAtk = 5;
    private GameObject player;
    private MyPlayerHealth playerHealth;
    private bool isRange ;
    private float time = 0;
    private float timeBetween = 2;
    private Animator animator;
    private EnemyMovement enemyMove;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //ͨ���ű�player���player�ϵĽű�
        playerHealth = player.GetComponent<MyPlayerHealth>();
        animator = GetComponent<Animator>();
        enemyMove = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        if (isRange&&!playerHealth.isDead)
        {
            if (time > timeBetween)
            {
                //���빥������ʵ�й���
                Atk();
            }

        }
        if (playerHealth.isDead)
        {
            //���ڹ��� ������Ϊideo
            animator.SetTrigger("PlayerDead");
            //���������ΪĿ������ƶ�
            enemyMove.enabled = false;
        }

    }

    private void Atk()
    {
        //���˹�����ҿ�Ѫ
       playerHealth.TakeDamage(enemyAtk);
        //���������Ĺ�������
        time = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject==player)
        {
           
            isRange = true;
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isRange = false;
            
        }
    }
}
