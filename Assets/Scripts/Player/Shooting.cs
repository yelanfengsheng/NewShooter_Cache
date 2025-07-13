using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    
    float time = 0f;
    public float timeBetweenShoot = 0.15f;
    
    public float lightBetween= 0.1f;
    private AudioSource gunAudio;
    private Light LightShoot;
    private LineRenderer LineShoot;
    private ParticleSystem particle;
    private Ray shootRay;
    private RaycastHit hitEnemy;
    private RaycastHit hitRewardBox;
    private RaycastHit hitBuilding;
    public int damage = 10; //�ӵ��˺�
    private void Awake()
    {
        gunAudio = GetComponent<AudioSource>();
        LightShoot = GetComponent<Light>();
       LineShoot = GetComponent<LineRenderer>();
        particle = GetComponent<ParticleSystem>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        time =time +Time.deltaTime;
       

        if (Input.GetButton("Fire1")&&time>timeBetweenShoot)
        {
            Shoot();
            
        }
       if(time > timeBetweenShoot*lightBetween)
        {
            LightShoot.enabled = false;
            LineShoot.enabled = false ;
        }

    }
    void Shoot()
    {
        time = 0;
        //����Ч��
        particle.Play();
        //�����ӵ�
        LightShoot.enabled = true;
        LineShoot.SetPosition(0, this.transform.position);
        //LineShoot.SetPosition(1, transform.position + this.transform.forward * 100);
        LineShoot.enabled = true ;
        //��Ч
        gunAudio.Play();
        //����Ƿ����߼�⵽Enemy
        shootRay.origin = this.transform.position;
        shootRay.direction = this.transform.forward;
        int layMask = LayerMask.GetMask("Enemy");
        int layMask2 = LayerMask.GetMask("RewardBox");
        int layMask3 = LayerMask.GetMask("Building");
        //��⵽����
        if (Physics.Raycast(shootRay,out hitEnemy, 100, layMask))
        {
            LineShoot.SetPosition(1, hitEnemy.point);
            EnemyHealth enemyHealth = hitEnemy.collider.GetComponent<EnemyHealth>();
            enemyHealth.TakeDemage(damage,hitEnemy.point);
        }
        else if(Physics.Raycast(shootRay,out hitRewardBox,100,layMask2))
        {
            Debug.Log("Hit RewardBox");
            LineShoot.SetPosition(1, hitRewardBox.point);
            RewardBox rewardBox = hitRewardBox.collider.GetComponent<RewardBox>();
            rewardBox.TakeDemage(damage);
        }
        else if (Physics.Raycast(shootRay, out hitBuilding, 100, layMask3))
        {
            Debug.Log("Hit Building");
            LineShoot.SetPosition(1, hitBuilding.point);

        }
        //û��⵽����
        else
        {
            LineShoot.SetPosition(1, transform.position + this.transform.forward * 100);
        }
    }
    

   
}
