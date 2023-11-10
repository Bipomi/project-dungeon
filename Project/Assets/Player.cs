using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 destPos;
    Vector3 dir;
    Quaternion lookTarget;

    public float maxHP;
    public float curHP;
    public float mp;

    float str; //��
    float dex; //��ø
    float vision; //�þ�
    float defense; //����
    float offense = 10; //���ݷ�

    int tempOffense;

    bool move = false;

    private void Start()
    {

    }

    private void Update()
    {
        // ���� ���콺 ��ư�� ������ ��
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            // ���� ī�޶� ���� ���콺 Ŭ���� ���� ray ������ ������
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // ray�� ���� ��ü�� �ִ��� �˻�
            if (Physics.Raycast(ray, out hit, 100f))
            {
                print(hit.transform.name);

                // hit.point �� ���콺 Ŭ���� ���� ���� ��ǥ.
                // �� �������� ĳ������ y ��(����) �� ������ �ʱ� ������ 
                // �Ʒ��� ���� ��ǥ��ġ�� �缳���մϴ�.
                destPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);

                // ���� ��ġ�� ��ǥ ��ġ�� ���� ����
                dir = destPos - transform.position;

                // �ٶ� ���ƾ� �� ���� Quaternion
                lookTarget = Quaternion.LookRotation(dir);
                move = true;
            }
        }

        Move();
    }

    void Move()
    {
        if (move)
        {
            // �̵��� �������� Time.deltaTime * 2f �� �ӵ��� ������.
            transform.position += dir.normalized * Time.deltaTime * 2f;
            // ���� ���⿡�� ���������� �������� �ε巴�� ȸ��
            transform.rotation = Quaternion.Lerp(transform.rotation, lookTarget, 0.25f);

            // ĳ������ ��ġ�� ��ǥ ��ġ�� �Ÿ��� 0.05f ���� ū ���ȸ� �̵�
            move = (transform.position - destPos).magnitude > 0.05f;
        }
    }

    public float CalDamage() //temp�� ���� �� ������ ���� �Ͻ��� ���ݷ� ������
    {
        float damage;

        //ũ��Ƽ�� Ȯ��
        int critical = Random.Range(0, 100);
        if (critical % 4 == 0)
        {
            damage = (offense + tempOffense) * 0.5f;
            Debug.Log("ũ��Ƽ��!");
        }
        else
            damage = (offense + tempOffense) * 0.3f;

        return damage;
    }

    public void Attack(Enemy enemy)
    {
        if (enemy.curHP > 0)
        {
            Debug.Log("����");
            enemy.curHP -= this.CalDamage();
            tempOffense = 0;

            Debug.Log("�� ü��: " + enemy.curHP);

            enemy.Attack(this, 1);
        }
        else
        {
            Debug.Log("���� ����!");
            
        }
    }

    public void CounterAttack(Enemy enemy)
    {
        if (enemy.curHP > 0)
        {
            Debug.Log("�ݰ�");
            enemy.Attack(this, 2);

            Debug.Log("�� ü��: " + enemy.curHP);
        }
        else
        {
            Debug.Log("���� ����!");

        }
    }

    public void Focusing(Enemy enemy)
    {
        Debug.Log("����");
        tempOffense += 5;
        enemy.Attack(this, 1);
    }
}