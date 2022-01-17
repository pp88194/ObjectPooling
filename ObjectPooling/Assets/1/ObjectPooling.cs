using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    //������Ʈ Ǯ���� ������Ʈ�� �̸� �����ΰ� ����ϴ� �޸� ���� �����
    //���ӿ�����Ʈ�� Instantiate�� �����ߴٰ� Destroy�� �����ϴ� ������ ������ �ݺ��ϸ� �޸𸮸� ���� ��Ƹ���(������ �÷���)
    //�׷��� �ַ� ���� �����ߴ� ����� �Ѿ��̳� ��������Ʈ���� �͵��� ������ƮǮ������� Ȱ����

    //Queue�� �̿��� ������Ʈ�� ������� �����Ѵ�
    public Queue<GameObject> objectPool = new Queue<GameObject>(); //Queue�� ���� ������� �����Ͱ� ���� ������ ������ �̷����(���Լ���, ��) �Ĵ� ��⿭)
    public GameObject prefab; //������ ������

    //������Ʈ ����
    public GameObject CreateObject()
    {
        GameObject gameObject = Instantiate(prefab); //�� ������Ʈ�� ����
        return gameObject; //���� ������Ʈ�� ��ȯ
    }
    //������Ʈ �����ִ� �Լ�
    public GameObject GetObject()
    {
        if(objectPool.Count > 0) //objectPool�� ����ִ� �ڷ��� ������ 0���� ũ�� ( objectPool�� ������� ������ )
        {
            GameObject gameObject = objectPool.Dequeue(); //objectPool���� �ϳ��� ���� ��
            gameObject.SetActive(true); //��Ȱ��ȭ ���¿��� ������Ʈ�� Ȱ��ȭ����
            return gameObject; //���� �� ������Ʈ�� ��ȯ
        }
        else
        {
            GameObject gameObject = CreateObject(); //���ο� ������Ʈ�� ������
            gameObject.SetActive(true); //��Ȱ��ȭ ���¿��� ������Ʈ�� Ȱ��ȭ����
            return gameObject;
        }
    }
    //������Ʈ �����޴� �Լ�
    public void ReturnObject(GameObject gameObject)
    {
        gameObject.SetActive(false); //����ϰ����� ���� ������Ʈ�� ��Ȱ��ȭ ������
        objectPool.Enqueue(gameObject); //�Ű������� �޾ƿ� GameObject�� objectPool�� �����
    }
}