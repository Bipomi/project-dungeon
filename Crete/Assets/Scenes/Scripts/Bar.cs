using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Slider HP_Slider;
    public Slider Mental_Slider;
    public Slider Exp_Slider;
    public Text HP_Text;
    public Text Mental_Text;
    public Text Exp_Text;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        HP_Slider = GameObject.Find("HP_Slider").GetComponent<Slider>();
        Mental_Slider = GameObject.Find("Mental_Slider").GetComponent<Slider>();
        Exp_Slider = GameObject.Find("Exp_Slider").GetComponent<Slider>();
        HP_Slider.minValue = 0;
        Mental_Slider.minValue = 0;
        Exp_Slider.minValue = 0;

    }
    void Update()
    {
        HP_Slider.maxValue = player.MaxHealth;//�����̴��� �ִ밪�� ������ �ִ�ü������ ����
        Mental_Slider.maxValue = player.MaxMental;//�����̴��� �ִ밪�� ������ �ִ��Ż�� ����
        Exp_Slider.maxValue = player.MaxExp;//�����̴��� �ִ밪�� ������ �ִ����ġ�� ����
        HP_Slider.value = player.Health;//�����̴��� ���� ������ ü������ ����
        Mental_Slider.value = player.Mental;//�����̴��� ���� ������ �������� ����
        Exp_Slider.value = player.Exp;//�����̴��� ���� ������ ��Ż�� ����
        HP_Text.text = (player.Health.ToString() + "/" + player.MaxHealth.ToString());//�ؽ�Ʈ�� ���� ������ ü������ ����
        Mental_Text.text = (player.Mental.ToString() + "/" + player.MaxMental.ToString());//�ؽ�Ʈ�� ���� ������ �������� ����
        Exp_Text.text = (player.Exp.ToString() + "/" + player.MaxExp.ToString());//�ؽ�Ʈ�� ���� ������ �������� ����
    }
}