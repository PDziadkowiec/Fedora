using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerDialogLadySnail : MonoBehaviour
{
    //Skrypt przypisany do NPC SNAIL

    public AudioSource audioSource;
    public AudioClip ladySnailEncounterSE;

    public Text PressToTalk;
    public Canvas DialogueHUD;
    public Image DialogueBackground;
    public Text Dialogue;
    public Text DialogueCharacter;
    private int DialogueCounter = 0;
    private int DialogueArrayLenght = 0;
    private string[,] currentDialog;

    public Canvas QuestCanvas;
    public Button QuestButton;
    public Button ExitFromQuestsButton;
    public Text QuestsText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Dźwięk Pani Ślimak
            audioSource.GetComponent<AudioSource>().PlayOneShot(ladySnailEncounterSE);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        DialogueLadySnail(collision);
    }

    //Zacina się dialog gdy na OnTriggerStay2D?
    private void DialogueLadySnail(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Jeżeli gracz wchodzi na trigger, pojawia się informacja o możliwości dialogu
            PressToTalk.gameObject.SetActive(true);

            //Jeśli naciśnięto klawisz odpowiedzialny za rozpoczęcie dialogu
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Zmienne z GameData, które odpowiadają, który będzie dialog 
                if (GameData.location == "Las")
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
                PressToTalk.text = "";

                //Klikanie pokazuje kolejna kwestię dialogową
                //Jeżeli jest możliwa kolejna kwestia dialogowa z tablicy danego dialogu
                if (Input.anyKeyDown && (DialogueCounter < DialogueArrayLenght))
                {
                    //Imię postaci, która wypowiada dialog
                    DialogueCharacter.text = currentDialog[DialogueCounter, 0];
                    //Tekst dialogu
                    Dialogue.text = currentDialog[DialogueCounter, 1];
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
                    //Zakończenie rozmowy poprzez odejście od NPCa NIE ZMIENI wartości zmiennej  
                    GameData.firstForestLadySnailDialogue = false;
                    //Zmiana treści questa w Zadaniach
                    GameData.listOfQuests = $"○ Zdobądź składniki do wytworzenia mikstury: " +
                    $"\n- {GameData.hasGrapeBoolToInt()}/1 Winogrono " +
                    $"\n- {GameData.hasBasilBoolToInt()}/1 Bazylia " +
                    $"\n- {GameData.hasWaterBoolToInt()}/1 Woda z Zaczarowanego Źródła " +
                    $"\n- {GameData.hasCrystalBoolToInt()}/1 Kryształ Przemiany " +
                    $"\n\n○ Odszukaj porozmieszczane po całej krainie Zalążki Magii, by zdobyć nowe umiejętności";
                    QuestsText.text = GameData.listOfQuests;
                }
            }
        }
    }

    //Odejście od NPCa przerywa dialog i przywraca domyślne wartości
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            {
                DialogueCounter = 0;
                DialogueHUD.gameObject.SetActive(false);
                PressToTalk.gameObject.SetActive(true);
                PressToTalk.text = "Naciśnij E, \naby porozmawiać...";
            }
    }
}
