using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateReward : MonoBehaviour
{ 
    public int rotateSpeed = 120; // ��ת�ٶ�
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime); // ÿ����ת50��
    }
}
