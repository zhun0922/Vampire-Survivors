using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Rigidbody2D target; //플레이어의 rigidbody가 들어감

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
        Vector2 dirVec = target.position - rigid.position; //위치 차이 = 타겟 위치 - 나의 위치
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime; //가야할 다음 위치 
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero; // 플레이어와 몬스터가 충돌하면 몬스터가 막 튕겨나감 .물리 속도가 이동에 영향을 주지 않도록 속도 제거
     
    }
    private void LateUpdate()
    {
        if (!isLive)
            return;
        spriter.flipX = target.position.x < rigid.position.x;
    }
}
