using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData; //근데 이게 인스펙터창에서 보이지 않는다.
    //그래서 SpawnData 클래스를 [[System.Serializable]를 붙혀 직렬화한다

    int level;
    float timer;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
            //GetComponents : 컴포넌트 하나가 아닌 여러개를 한꺼번에 가져올 수 있는 함수
            //GetComponentsInChildren
    }
    private void Update()
    {
        timer += Time.deltaTime;
        level = Mathf.FloorToInt(GameManager.Instance.gameTime / 10f);
        
        //FloorToInt : 소수점 아래는 버리고 Int형으로 바꾸는 함수
        //CeilToInt : 올림 , int로 형변환

        if (timer > spawnData[level].spawnTime)
        { 
            timer = 0;
            Spawn();
        }

    }

    void Spawn()
    {
        GameObject enemy = GameManager.Instance.pool.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1,spawnPoint.Length)].transform.position;
        //Random.Range가 0이아니라 1인 이유? 
        //GetComponentsInChildren은 자기 자신도 포함이다. 자기 자신이 0이 되는것.
        //자기 자신은 필요가 없고 자식들만 필요하므로 1부터 시작.
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
            //오브젝트 풀에서 가져온 오브젝트에서 ENemy컴포넌트 접근 (Init을 사용하기 위해)
    }
}

[System.Serializable]
public class SpawnData
{
    public float spawnTime; //이 변수는 이 스크립트에서만 쓴다
    public int spriteType; //0 -> 해골 1-> 좀비
    public int health;
    public float speed;
}
