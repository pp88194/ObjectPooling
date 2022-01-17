using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ObjectPooling objectPooling;

    private void Update()
    {
        if (Input.anyKey) //아무키나 누르면 실행
            Shoot();
    }

    public void Shoot()
    {
        GameObject gameObject = objectPooling.GetObject(); //미리 생성해둔 오브젝트를 가져옴
        gameObject.transform.position = transform.position; //가져온 오브젝트의 위치를 자신의 현재 위치로 바꿈
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward, ForceMode.Impulse); //가져온 오브젝트의 Rigidbody를 GetComponent로 가져와 AddForce로 힘을 가함
        Bullet bullet = gameObject.GetComponent<Bullet>(); //가져온 오브젝트의 Bullet 스크립트를 GetComponent로 가져옴
        bullet.objectPooling = objectPooling;
    }
}