using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHeart : MonoBehaviour
{
    private int healthValue = 10; // ÿ��������Ʒ���ӵ�����ֵ
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player collided with heart item");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collided with heart item");
            // ��ȡ��ҵ�Health���
            MyPlayerHealth playerHealth = collision.gameObject.GetComponent<MyPlayerHealth>();
            if (playerHealth.startHealth>0)
            {
                // ������ҵ�����ֵ
                playerHealth.AddHealth(healthValue); // ����ÿ��������Ʒ����10������ֵ
                Destroy(gameObject,0f); // ����������Ʒ
                
            }
        }
    }
   
}
