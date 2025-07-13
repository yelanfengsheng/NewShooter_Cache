using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class RewardBox : MonoBehaviour
{
    public int startHealth = 20; // ������ĳ�ʼ����ֵ
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDemage(int value)
    {
       startHealth -= value; // ���ٽ����������ֵ
         if (startHealth <= 0)
         {
              Dead(); // �������ֵС�ڵ���0��������������
        }
    }
    private void Dead()
    {
        Destroy(gameObject, 0f); //�������ٽ�����
        //����ڽ�����λ�����ɽ���
        RandomReward();

    }
    private void RandomReward()
    {
        int randomReward = UnityEngine.Random.Range(1, 100); // ����1��100֮��������
        if (randomReward <= 30)
        {
            // ����ҽ�ư�
            GameObject heart = Resources.Load<GameObject>("Heart");
            Instantiate(heart, transform.position, Quaternion.identity);

        }
        else if (randomReward <= 60)
        {
            // ��������һ��ǹ֧
            GameObject newGan = Resources.Load<GameObject>("Gan");
            Instantiate(newGan, transform.position, Quaternion.identity);
        }
        //else
        //{
        //    // ����ҽ�ư�
        //    GameObject healthPack = Resources.Load<GameObject>("HealthPack");
        //    Instantiate(healthPack, transform.position, Quaternion.identity);
        //}
    }

}
