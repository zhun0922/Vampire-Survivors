using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // �����յ��� ������ ����
    public GameObject[] prefabs;
    // Ǯ����� �ϴ� ����Ʈ��

    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        for(int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>(); //������ list��ȸ�ϸ� �ʱ�ȭ 
            
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        // ������Ǯ�� ��� �ִ� (��Ȱ��ȭ��) ���ӿ�����Ʈ ���� 
          // �߰��ϸ� select������ �Ҵ� 

        foreach(GameObject item in pools[index])
        {
            if (!item.activeSelf) //��Ȱ��ȭ �� ���
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }
        // �� ã����? 
        // ���Ӱ� �����ϰ� select�� �Ҵ� 
        if (!select) // !select �� select == null�� ������ 
        {
            select = Instantiate(prefabs[index], transform); //transform�� �θ�(�� PoolManager)�� �ڽ����� �����Ѵٴ¸�
            pools[index].Add(select);
        }
     
        return select;
    }
}
