using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Rigidbody2D target; //�÷��̾��� rigidbody�� ��

    bool isLive;

    Rigidbody2D rigid;
    SpriteRenderer spriter;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter= GetComponent<SpriteRenderer>();
        speed = 1f;
        isLive= true;
    }

  
    private void FixedUpdate()
    {
        if (!isLive)
            return;
        Vector2 dirVec = target.position - rigid.position; //��ġ ���� = Ÿ�� ��ġ - ���� ��ġ
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime; //������ ���� ��ġ 
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero; // �÷��̾�� ���Ͱ� �浹�ϸ� ���Ͱ� �� ƨ�ܳ��� .���� �ӵ��� �̵��� ������ ���� �ʵ��� �ӵ� ����
     
    }
    private void LateUpdate()
    {
        if (!isLive)
            return;
        spriter.flipX = target.position.x < rigid.position.x;
    }
}
