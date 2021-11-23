using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScripts : MonoBehaviour
{
    public Text HealthAmmount;
    public Text CoinAmmount;
    public Image JumpSkillImage;
    public Text PressToTalk;

    private void Start()
    {
        JumpSkillImage.gameObject.SetActive(false);
    }

    void Update()
    {
        //Wyświetlanie ilości życia
        HealthAmmount.text = (GameData.healthPoints).ToString() + " / " + (GameData.maxHealthPoints).ToString();

        //Wyświetlanie liczby monet
        CoinAmmount.text = (GameData.coins).ToString() + " / " + (GameData.maxCoins).ToString();

        //Wyświetlenie ikonki skoku, jesli gracz go posiada
        if(GameData.jump==true)
        {
            JumpSkillImage.gameObject.SetActive(true);
        }
        if(GameData.triggerLadySnail==true)
        {
            PressToTalk.gameObject.SetActive(true);
        }
    }
    
   
}
