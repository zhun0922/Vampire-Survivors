using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData; //�ٵ� �̰� �ν�����â���� ������ �ʴ´�.
    //�׷��� SpawnData Ŭ������ [[System.Serializable]�� ���� ����ȭ�Ѵ�

    int level;
    float timer;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
            //GetComponents : ������Ʈ �ϳ��� �ƴ� �������� �Ѳ����� ������ �� �ִ� �Լ�
            //GetComponentsInChildren
    }
    private void Update()
    {
        timer += Time.deltaTime;
        level = Mathf.FloorToInt(GameManager.Instance.gameTime / 10f);
        
        //FloorToInt : �Ҽ��� �Ʒ��� ������ Int������ �ٲٴ� �Լ�
        //CeilToInt : �ø� , int�� ����ȯ

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
        //Random.Range�� 0�̾ƴ϶� 1�� ����? 
        //GetComponentsInChildren�� �ڱ� �ڽŵ� �����̴�. �ڱ� �ڽ��� 0�� �Ǵ°�.
        //�ڱ� �ڽ��� �ʿ䰡 ���� �ڽĵ鸸 �ʿ��ϹǷ� 1���� ����.
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
            //������Ʈ Ǯ���� ������ ������Ʈ���� ENemy������Ʈ ���� (Init�� ����ϱ� ����)
    }
}

[System.Serializable]
public class SpawnData
{
    public float spawnTime; //�� ������ �� ��ũ��Ʈ������ ����
    public int spriteType; //0 -> �ذ� 1-> ����
    public int health;
    public float speed;
}
