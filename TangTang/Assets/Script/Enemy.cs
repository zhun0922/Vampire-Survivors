using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float maxHealth;
    public RuntimeAnimatorController[] animCon;
    //Animator의 데이터는 AnimatorController인데, 여기선 조금 다르게 Runtime을 붙인다.
    public Rigidbody2D target; //플레이어의 rigidbody가 들어감

    bool isLive;

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriter;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter= GetComponent<SpriteRenderer>();
        anim =GetComponent<Animator>();
    }
  
    private void FixedUpdate()
    {
        if (!isLive)
            return;
        Vector2 dirVec = target.position - rigid.position; //위치 차이 = 타겟 위치 - 나의 위치
        //타겟이 (0,0) enemy가 (1,1) 이라면 (-1,-1)방향으로 이동 
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime; //가야할 다음 위치 
        rigid.MovePosition(rigid.position + nextVec); //moveposition은 순간이동같은거 
        rigid.velocity = Vector2.zero; // 플레이어와 몬스터가 충돌하면 몬스터가 막 튕겨나감 .물리 속도가 존재한다는 말.
                                       // 이동에 영향을 주지 않도록 물리 속도 0으로 고정 new Vector2(0,0) 할거 없이 Vector.zero 

    }
    private void LateUpdate()
    {
        if (!isLive)
            return;
        spriter.flipX = target.position.x < rigid.position.x;
    }

    private void OnEnable() //스크립트가 활성화 될 때 호출되는 이벤트 함수
        //프리팹의 단점이다.
        //플레이어의 rigidbody2D가 들어가야 할 target에 드래그앤드롭이 안된다.
        //왜냐면 프리팹자체는 아직 활성화 되지 않은 상태이기 때문에.
        //그래서 활성화 될때 target에 플레이어를 지정하는 초기화를 여기서 해준다
    {
        target = GameManager.Instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        health = maxHealth;
    }

    public void Init(SpawnData data) //Spawndata를 그대로 가져옴
    {
        anim.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }
}
