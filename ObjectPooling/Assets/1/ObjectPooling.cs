using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    //오브젝트 풀링은 오브젝트를 미리 만들어두고 사용하는 메모리 관리 기법임
    //게임오브젝트를 Instantiate로 생성했다가 Destroy로 삭제하는 과정을 여러번 반복하면 메모리를 많이 잡아먹음(가비지 컬렉터)
    //그래서 주로 많이 생성했다 지우는 총알이나 먼지이펙트같은 것들을 오브젝트풀링기법을 활용함

    //Queue를 이용해 오브젝트를 순서대로 관리한다
    public Queue<GameObject> objectPool = new Queue<GameObject>(); //Queue는 먼저 집어넣은 데이터가 먼저 나오는 구조로 이루어짐(선입선출, 예) 식당 대기열)
    public GameObject prefab; //생성할 프리펩

    //오브젝트 생성
    public GameObject CreateObject()
    {
        GameObject gameObject = Instantiate(prefab); //새 오브젝트를 만듦
        return gameObject; //만든 오브젝트를 반환
    }
    //오브젝트 빌려주는 함수
    public GameObject GetObject()
    {
        if(objectPool.Count > 0) //objectPool에 담겨있는 자료의 개수가 0보다 크면 ( objectPool이 비어있지 않으면 )
        {
            GameObject gameObject = objectPool.Dequeue(); //objectPool에서 하나를 꺼내 옴
            gameObject.SetActive(true); //비활성화 상태였던 오브젝트를 활성화해줌
            return gameObject; //꺼내 온 오브젝트를 반환
        }
        else
        {
            GameObject gameObject = CreateObject(); //새로운 오브젝트를 생성함
            gameObject.SetActive(true); //비활성화 상태였던 오브젝트를 활성화해줌
            return gameObject;
        }
    }
    //오브젝트 돌려받는 함수
    public void ReturnObject(GameObject gameObject)
    {
        gameObject.SetActive(false); //사용하고있지 않은 오브젝트는 비활성화 시켜줌
        objectPool.Enqueue(gameObject); //매개변수로 받아온 GameObject를 objectPool에 담아줌
    }
}