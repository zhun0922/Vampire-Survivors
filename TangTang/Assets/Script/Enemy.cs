using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float maxHealth;
    public RuntimeAnimatorController[] animCon;
    //Animator�� �����ʹ� AnimatorController�ε�, ���⼱ ���� �ٸ��� Runtime�� ���δ�.
    public Rigidbody2D target; //�÷��̾��� rigidbody�� ��

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
        Vector2 dirVec = target.position - rigid.position; //��ġ ���� = Ÿ�� ��ġ - ���� ��ġ
        //Ÿ���� (0,0) enemy�� (1,1) �̶�� (-1,-1)�������� �̵� 
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime; //������ ���� ��ġ 
        rigid.MovePosition(rigid.position + nextVec); //moveposition�� �����̵������� 
        rigid.velocity = Vector2.zero; // �÷��̾�� ���Ͱ� �浹�ϸ� ���Ͱ� �� ƨ�ܳ��� .���� �ӵ��� �����Ѵٴ� ��.
                                       // �̵��� ������ ���� �ʵ��� ���� �ӵ� 0���� ���� new Vector2(0,0) �Ұ� ���� Vector.zero 

    }
    private void LateUpdate()
    {
        if (!isLive)
            return;
        spriter.flipX = target.position.x < rigid.position.x;
    }

    private void OnEnable() //��ũ��Ʈ�� Ȱ��ȭ �� �� ȣ��Ǵ� �̺�Ʈ �Լ�
        //�������� �����̴�.
        //�÷��̾��� rigidbody2D�� ���� �� target�� �巡�׾ص���� �ȵȴ�.
        //�ֳĸ� ��������ü�� ���� Ȱ��ȭ ���� ���� �����̱� ������.
        //�׷��� Ȱ��ȭ �ɶ� target�� �÷��̾ �����ϴ� �ʱ�ȭ�� ���⼭ ���ش�
    {
        target = GameManager.Instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        health = maxHealth;
    }

    public void Init(SpawnData data) //Spawndata�� �״�� ������
    {
        anim.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }
}
