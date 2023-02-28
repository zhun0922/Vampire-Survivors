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
        anim= GetComponent<Animator>();
    }
  
    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec *  speed * Time.fixedDeltaTime;  //���� ���ư� ������ ũ��
        rigid.MovePosition(rigid.position + nextVec); //+ inputVec ��� ����ȭ ���� ������ ��ģ nextVec���
     
    }
    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
        //Get<T>:�����ʿ��� ������ ��Ʈ�� Ÿ�� T����(�����ʿ��� Vector2������ �������־���) �������� �Լ�
        //���⿡�� �븻����� �̹� ����ϰ� �ֱ� ������ ������
    }

    private void LateUpdate()
    {
        if (inputVec.x != 0 )
        {
            //��������Ʈ �ν�����â�� ���� flipX�� true , false���� ������ ���� �� �� �ִ�
            //spriter.flipX = true;
            //��� ���°� ������ ���ǽ��� �״�� �־�����
            spriter.flipX = inputVec.x < 0; //���� ���� ���ǽ��� true�̰�, �� ���� �״�� flipX�� ����ȴ�
        }

       
    }
}
