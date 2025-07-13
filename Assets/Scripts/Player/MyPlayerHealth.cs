using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyPlayerHealth : MonoBehaviour
{
    public int startHealth = 50;
    public int maxHealth = 50;
    public bool isDead = false;
    private AudioSource Audio;
    public AudioClip deadAudio;
    private Animator animator;
    private PlayerMovement move;
    private Shooting shoot;
    private GameObject canvas;
    private float time = 0f;
    private float maxTime = 3f;
    
    private void Awake()
    {
        Audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        move = GetComponent<PlayerMovement>();
        shoot = GetComponentInChildren<Shooting>();
        canvas = GameObject.Find("Canvas");
       

    }

    // Update is called once per frame
    void Update()
    {
        
        if (isDead)
        {
            time = time + Time.deltaTime;
            Debug.Log(time);
            //��������Ҳ������ƶ�
            move.enabled = false;
            //��������Ҳ������
            shoot.enabled = false;
            RestartLevel();
        }

    }
    public void TakeDamage(int value)
    {
        //����֮��������
        if(isDead) return;  
        startHealth-=value;
        //������Ч
        Audio.Play();
        //���˵�����Ч��

        //���˶���
        //�˺���������
        if(startHealth <=0)
        {
            
            Dead();
        }
        
    }
    private void Dead()
    {
        isDead = true;
        //���������Ĳ���
        animator.SetTrigger("IsDead");
        Debug.Log("�������");
        //������Ч�Ĳ���
        Audio.clip = deadAudio;
        Audio.Play();
       


    }
    public void RestartLevel()
    {
        if (time >= maxTime)
        //����
        {
            AddScore.score = 0; //���÷���
            SceneManager.LoadScene(0);
        }
        //��������������ui����
     
    }

    public  void AddHealth(int value)
    {  if(startHealth ==maxHealth )
        {
            return; // �����ǰ����ֵ�Ѿ������ֵ��������
        }
        startHealth += value;
    }
}
