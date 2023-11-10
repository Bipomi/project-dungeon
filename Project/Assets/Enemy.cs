using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHP;
    public float curHP;

    public float damage;

    Rigidbody rigid;
    BoxCollider boxCollider;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    public void Attack(Player player, int num)
    {
        if (player.curHP > 0)
        {
            if (num == 1)
            {
                player.curHP -= this.CalDamage();

                Debug.Log("�÷��̾� ü��: " + player.curHP);
            }else if(num == 2) //�ݰ�
            {
                player.curHP -= this.CalDamage() * 1.0f;
                this.curHP -= this.CalDamage() * 0.4f;
                Debug.Log("�÷��̾� ü��: " + player.curHP);
            }
        }
        else
        {
            Destroy(player);
            Debug.Log("���� ����..");
        }
     
    }

    public float CalDamage()
    {
        return this.damage;
    }
}
