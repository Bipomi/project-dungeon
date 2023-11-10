using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameCam;
    public int stage;

    public GameObject GamePanel;
    public GameObject SettingSet;
    public Text stageTxt;
    public Text playerHealthTxt;
    public Text playerMentalTxt;
    public Text playerExpTxt;
    public Text playerDexTxt;
    public Text playerSightTxt;
    public Text playerADTxt;
    public Text playerDFTxt;
    public Image Attack;
    public Image Shield;
    public Image CCR;
    public Image Skill;
    public Image Bag;
    public Image Map;
    public Image Setting;
    public Player player;

    void Update()
    {
        //Sub Menu
        if (Input.GetButtonDown("Cancel")) {
            if(SettingSet.activeSelf)
                SettingSet.SetActive(false);  
            else
                SettingSet.SetActive(true);
        }
    }
    void LateUpdate()
    {
        //�÷��̾� UI
        playerHealthTxt.text = "HP : " + player.Health + " / " + player.MaxHealth;
        playerMentalTxt.text = "Mental : " + player.Mental + " / " + player.MaxMental;
        playerExpTxt.text = "Exp : " + player.Exp + " / " + player.MaxExp;
        playerDexTxt.text = "��ø : " + string.Format("{0:n0}",player.Dex);
        playerSightTxt.text = "�þ� : " + string.Format("{0:n0}",player.Sight);
        playerDFTxt.text = "���� : " + string.Format("{0:n0}",player.DF);
        playerADTxt.text = "���� ���ݷ� " + string.Format("{0:n0}",player.AD);
        //�������� UI
        stageTxt.text = "STAGE" + stage;
    }


}
