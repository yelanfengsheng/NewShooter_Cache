using UnityEngine;
using UnityEngine.UI; // ʹ����ȷ�������ռ�

public class HeartControl : MonoBehaviour
{
    public Slider heartSlider; // Inspector ����ק��ֵ
    private MyPlayerHealth playerHealth; // ��ҽ����ű�����
    private void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<MyPlayerHealth>();
    }
    private void Start()
    {
        heartSlider.value = 10; // ��ʼ�����λ����ֵ

    }

    private void Update()
    {
        heartSlider.value = playerHealth.startHealth; // �������λ����ֵΪ��ҵ�ǰ������ֵ

    }
}