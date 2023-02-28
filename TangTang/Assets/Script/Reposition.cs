using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;
        //�÷��̾��� position
        Vector3 playerpos = GameManager.Instance.player.transform.position;
        //�� ������Ʈ�� position
        Vector3 myPos = transform.position;
        //x��� y�� �Ÿ� ��� => Math.Abs()�Լ��� ����� �������� 
        float diffX = Mathf.Abs(playerpos.x - myPos.x);
        float diffY = Mathf.Abs(playerpos.y - myPos.y);
        

        //�÷��̾� ������ �����ϱ� ���� ���� �߰� 
        Vector3 playerDir = GameManager.Instance.player.inputVec;
        //3�� ������ ��� (����) ? (true�϶� ��) : (false�� ��)
        //���� normalized �� ������ ���� �̰� �� �ʿ� x
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if(diffX >= diffY)
                {
                    transform.Translate(Vector3.right * dirX * 40);
                }
                //�� ���ǿ��� �÷��̾ y�ຸ�� x������ �̵��� �ϰ� �ִ� ���̴� Ÿ�ϸʵ� ���������� x������ �̵������ش�
                //Translate() : ������ �� ��ŭ ������ġ���� �̵� 
                //���������ŭ �̵��ϰڴٴ� ���̱� ������ ��ǥ�� �ƴ� �̵��� ���� �˷��ִ� ��
                //
                //������ ������ Vector3. 
                //Vector3.right�� ���콺 �÷������� (1,0,0) �� Ȯ�ΰ���
                //������ �÷��̾ �����ʻ� �ƴ϶� �������� �� �� �� �ֱ� ������ �Ʊ� ���� dirX�� ���Ѵ� (�����̸� -1)
                //Ÿ�ϸ� 4���� Ȱ���� 40X40�������̹Ƿ� *40
                else if (diffX <= diffY)
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }


                break;
            case "Enemy":

                break;
        }
    }
}
