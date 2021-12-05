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
    public Text locationNameText;

    public Canvas DialogueHUD;
    public Image DialogueBackground;
    public Text Dialogue;
    public Text DialogueCharacter;
    private int DialogueCounter = 0;
    private int DialogueArrayLenght = 0;
    private string[,] currentDialog;

    private void Start()
    {
        JumpSkillImage.gameObject.SetActive(false);
        locationNameText.text = GameData.location;
    }

    void Update()
    {

        //Przerzucić to z Update na triggery

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
            //Jeżeli gracz wchodzi na trigger, pojawia się informacja o możliwości dialogu
            PressToTalk.gameObject.SetActive(true);

            //Jeśli naciśnięto klawisz odpowiedzialny za rozpoczęcie dialogu
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Zmienne z GameData, które odpowiadają, który będzie dialog 
                if (GameData.location=="Las")
                {
                    //Pierwszy dialog z Panią Ślimak w lesie
                    if (GameData.firstForestLadySnailDialogue == true)
                    {
                        currentDialog = GameData.ladySnailFirstDialogueForest;
                    }
                    else
                    {
                        //Gdy gracz nie posiada skoku
                        if (GameData.jump == false)
                        {
                            currentDialog = GameData.ladySnailNoJumpDialogueForest;
                        }
                        //Gdy gracz posiada skok
                        else
                        {
                            currentDialog = GameData.ladySnailDialogueForest;
                        }
                    }
                }
                //Długość dialogu
                DialogueArrayLenght = currentDialog.GetLength(0);

                //Wyświetlenie okna rozmowy
                DialogueHUD.gameObject.SetActive(true);

                //Wyłączenie napisu informacyjnego o możliwosci rozpoczęcia dialogu

                //Przez gameObjects.SetActive(false) nie działało !!!!
                PressToTalk.text = "";

                //Klikanie pokazuje kolejna kwestię dialogową
                //Jeżeli jest możliwa kolejna kwestia dialogowa z tablicy danego dialogu
                if (Input.anyKeyDown && (DialogueCounter < DialogueArrayLenght))
                {
                    //Imię postaci, która wypowiada dialog
                    DialogueCharacter.text = currentDialog[DialogueCounter, 0];
                    //Tekst dialogu
                    Dialogue.text = currentDialog[DialogueCounter,1];
                    //Przesunięcie zmiennej odpowiedzialnej za kolejną kwestię dialogową
                    DialogueCounter += 1;
                }
                //Jeżeli wyczerpią się kwestie dialogowe
                //Przywrócenie domyślnych wartości
                else
                {
                    DialogueCounter = 0;
                    PressToTalk.gameObject.SetActive(true);
                    DialogueHUD.gameObject.SetActive(false);
                    PressToTalk.text = "Naciśnij E, \naby porozmawiać...";
                    //Upewnienie się, gracz przeczyta cały pierwszy dialog
                    //Zakończenie rozmowy poprzez odejście od NPCa nie zmienni wartości zmiennej  
                    GameData.firstForestLadySnailDialogue = false;

                }

            }
        }
        //Odejście od NPCa przerywa dialog i przywraca domyślne wartości
        if (GameData.triggerLadySnail == false)
        {
            DialogueCounter = 0;
            DialogueHUD.gameObject.SetActive(false);
            PressToTalk.gameObject.SetActive(false);
            PressToTalk.text = "Naciśnij E, \naby porozmawiać...";
        }
    }
    
   
}
