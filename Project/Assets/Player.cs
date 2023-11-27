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


    private void Start()
    {

    }

    private void Update()
    {
        float moveZ = 0f;
        float moveX = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            moveZ += 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveZ -= 1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveX -= 1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveX += 1f;
        }

        transform.Translate(new Vector3(moveX, 0f, moveZ) * 0.1f);
    }

    public float CalDamage() //temp�� ���� �� ������ ���� �Ͻ��� ���ݷ� ������
    {
        float damage;

        //ũ��Ƽ�� Ȯ��
        int critical = Random.Range(0, 100);
        if (critical % 4 == 0)
        {
            damage = (offense + tempOffense) * 1.5f;
            Debug.Log("ũ��Ƽ��!");
        }
        else
            damage = (offense + tempOffense) * 1.0f;

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
            Destroy(enemy.gameObject);
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
            Destroy(enemy.gameObject);
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