using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ObjectPooling objectPooling;
    private void OnEnable()
    {
        Invoke("DestroyObject", 1f); //1�ʵڿ� DestroyObject�Լ� ����
    }

    void DestroyObject()
    {
        objectPooling.ReturnObject(this.gameObject); //�ڱ� �ڽ��� �ٽ� objectPool�� ��ȯ��
    }
}