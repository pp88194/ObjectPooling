using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ObjectPooling objectPooling;

    private void Update()
    {
        if (Input.anyKey) //�ƹ�Ű�� ������ ����
            Shoot();
    }

    public void Shoot()
    {
        GameObject gameObject = objectPooling.GetObject(); //�̸� �����ص� ������Ʈ�� ������
        gameObject.transform.position = transform.position; //������ ������Ʈ�� ��ġ�� �ڽ��� ���� ��ġ�� �ٲ�
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward, ForceMode.Impulse); //������ ������Ʈ�� Rigidbody�� GetComponent�� ������ AddForce�� ���� ����
        Bullet bullet = gameObject.GetComponent<Bullet>(); //������ ������Ʈ�� Bullet ��ũ��Ʈ�� GetComponent�� ������
        bullet.objectPooling = objectPooling;
    }
}