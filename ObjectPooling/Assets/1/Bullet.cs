using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ObjectPooling objectPooling;
    private void OnEnable()
    {
        Invoke("DestroyObject", 1f); //1초뒤에 DestroyObject함수 실행
    }

    void DestroyObject()
    {
        objectPooling.ReturnObject(this.gameObject); //자기 자신을 다시 objectPool로 반환함
    }
}