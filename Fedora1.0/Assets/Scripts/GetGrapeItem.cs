using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetGrapeItem : MonoBehaviour
{

    //Skrypt przypisany do obiektu GRAPE ITEM

    public AudioSource audioSource;
    public AudioClip getGrapeSE;

    public Text QuestText;

    public Canvas NewItemCanvas;
    public Text ItemText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameData.hasGrape = true;
            //Zmiana treści questa w Zadaniach
            GameData.listOfQuests = $"○ Zdobądź składniki do wytworzenia mikstury: \n- 1/1 Winogrono \n- 0/1 Bazylia \n- 0/1 Woda z Zaczarowanego Źródła \n- 0/1 Kryształ Przemiany \n\n○ Odszukaj porozmieszczane po całej krainie Zalążki Magii, by zdobyć nowe umiejętności";
            QuestText.text = GameData.listOfQuests;
            //Zrobić: pokazuje się obrazek winogrona w Przedmiotach
            audioSource.GetComponent<AudioSource>().PlayOneShot(getGrapeSE);
            Destroy(gameObject);
            Time.timeScale = 0;
            ItemText.text = "Zdobyto przedmiot:\nWINOGRONO";
            NewItemCanvas.gameObject.SetActive(true);
        }
    }

}
