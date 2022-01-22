using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScripts : MonoBehaviour
{

    //Skrypt przypisany do obiektu HUD SCRIPTS

    public Text HealthAmmount;
    public Text CoinAmmount;
    public Text locationNameText;

    public Image JumpSkillImage;
    public Image GrappleSkillImage;
    public Image SwimmingSkillImage;

    public Canvas QuestCanvas;
    public Button QuestButton;
    public Button ExitFromQuestsButton;
    public Text QuestsText;
    
    public Canvas EquipmentCanvas;
    public Button EquipmentButton;
    public Button ExitFromEquipmentButton;
    public GameObject GrapeImage;
    public GameObject BasilImage;
    public GameObject WaterImage;
    public GameObject CrystalImage;

    private void Start()
    {
        if(GameData.jump==true)
        {
            JumpSkillImage.gameObject.SetActive(true);
        }
        if (GameData.grapple == true)
        {
            GrappleSkillImage.gameObject.SetActive(true);
        }
        if (GameData.swimming == true)
        {
            SwimmingSkillImage.gameObject.SetActive(true);
        }

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
        
        //Wyświetlenie rzeczy w ekwipunku
        if (GameData.hasGrape == true)
        {
            GrapeImage.gameObject.SetActive(true);
        }
        if (GameData.hasBasil == true)
        {
            BasilImage.gameObject.SetActive(true);
        }
        if (GameData.hasWater == true)
        {
            WaterImage.gameObject.SetActive(true);
        }
        if (GameData.hasCrystal == true)
        {
           CrystalImage.gameObject.SetActive(true);
        }
    }

    public void ExitEquipmentCanvas()
    {
        EquipmentCanvas.enabled = false;
        GrapeImage.gameObject.SetActive(false);
        BasilImage.gameObject.SetActive(false);
        WaterImage.gameObject.SetActive(false);
        CrystalImage.gameObject.SetActive(false);
    }

}
