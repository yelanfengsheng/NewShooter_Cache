using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGun : MonoBehaviour
{
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
      if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collided with gun item");
            // ��ȡ��ҵ�Shooting���
            Shooting playerShooting = collision.gameObject.GetComponentInChildren<Shooting>();
            if (playerShooting != null)
            {
                // ������ҵ�����
                //playerShooting.AddGun();
                Destroy(gameObject, 0f); // ����ǹ֧��Ʒ
            }
        }
    }
}
