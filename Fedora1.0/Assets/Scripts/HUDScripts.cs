using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScripts : MonoBehaviour
{

    //Skrypt przypisany do obiektu HUD SCRIPTS

    public Text HealthAmmount;
    public Text CoinAmmount;
    public Image JumpSkillImage;
    public Text locationNameText;

    public Canvas QuestCanvas;
    public Button QuestButton;
    public Button ExitFromQuestsButton;
    public Text QuestsText;
    
    public Canvas EquipmentCanvas;
    public Button EquipmentButton;
    public Button ExitFromEquipmentButton;

    private void Start()
    {
        JumpSkillImage.gameObject.SetActive(false);

        //Wyświetlenie nazwy lokacji
        locationNameText.text = GameData.location;

        //Wyświetlanie ilości życia
        HealthAmmount.text = (GameData.healthPoints).ToString() + " / " + (GameData.maxHealthPoints).ToString();

        //Wyświetlanie liczby monet
        CoinAmmount.text = (GameData.coins).ToString() + " / " + (GameData.maxCoins).ToString();
    }

    void Update()
    {

    }
    

    public void OpenQuestCanvas()
    {
        QuestCanvas.enabled = true;
        QuestsText.text = GameData.listOfQuests;
    }
   
    public void ExitQuestCanvas()
    {
        QuestCanvas.enabled = false;
    }

    public void OpenEquipmentCanvas()
    {
        EquipmentCanvas.enabled = true;
    }

    public void ExitEquipmentCanvas()
    {
        EquipmentCanvas.enabled = false;
    }

}
