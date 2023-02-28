using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    public float speed = 3;

    private void Awake()
    {
        speed = 3;
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();
    }
  
    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec *  speed * Time.fixedDeltaTime;  //다음 나아갈 방향의 크기
        rigid.MovePosition(rigid.position + nextVec); //+ inputVec 대신 정규화 등의 연산을 거친 nextVec사용
     
    }
    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
        //Get<T>:프로필에서 설정한 컨트롤 타입 T값을(프로필에서 Vector2값으로 설정해주었다) 가져오는 함수
        //여기에선 노말라이즈를 이미 사용하고 있기 문에 빼도됨
    }

    private void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0 )
        {
            //스프라이트 인스텍터창을 보면 flipX가 true , false값을 가지는 것을 알 수 있다
            //spriter.flipX = true;
            //라고 쓰는게 맞지만 조건식을 그대로 넣어주자
            spriter.flipX = inputVec.x < 0; //우측 항의 조건식은 true이고, 이 값이 그대로 flipX에 적용된다
        }
        Debug.Log(inputVec.magnitude);
    }
}
