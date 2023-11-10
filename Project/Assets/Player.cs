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

    public float maxHP = 100;
    public float curHP = 100;
    public float mp = 100;

    public float str = 10; //��
    public float dex = 10; //��ø
    public float vision = 10; //�þ�
    public float defense = 10; //����
    public float offense = 10; //���ݷ�

    public float damage;

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

    public float CalDamage()
    {
        float damage = this.offense;
        int critical = Random.Range(0, 100);

        if (critical % 4 == 0)
        {
            damage = (str * offense) * 0.05f;
            Debug.Log("ũ��Ƽ��!");
        }
        else
            damage = (str * offense) * 0.03f;

        return damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            curHP -= enemy.CalDamage();

            Debug.Log("�÷��̾� ü��: " + curHP);
        }
    }
}