using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCrystalItem : MonoBehaviour
{
    //Skrypt przypisany do obiektu CRYSTAL ITEM
    //Skrypt wywołuje się gdy gracz podnosi Kryształ Przemiany

    public AudioSource audioSource;
    public AudioClip getCrystalSE;

    public Text QuestText;

    public Canvas NewItemCanvas;
    public Text ItemText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameData.hasCrystal = true;
            //Zmiana treści questa w Zadaniach
            GameData.listOfQuests = $"○ Zdobądź składniki do wytworzenia mikstury: " +
                $"\n- {GameData.hasGrapeBoolToInt()}/1 Winogrono " +
                $"\n- {GameData.hasBasilBoolToInt()}/1 Bazylia " +
                $"\n- {GameData.hasWaterBoolToInt()}/1 Woda z Zaczarowanego Źródła " +
                $"\n- {GameData.hasCrystalBoolToInt()}/1 Kryształ Przemiany " +
                $"\nGdy zdobędziesz wszystkie, wróć do Pani Ślimak." +
                $"\n\n○ Odszukaj porozmieszczane po całej krainie Zalążki Magii, by zdobyć nowe umiejętności";
            QuestText.text = GameData.listOfQuests;

            audioSource.GetComponent<AudioSource>().PlayOneShot(getCrystalSE);
            Destroy(gameObject);
            Time.timeScale = 0;
            ItemText.text = "Zdobyto przedmiot:\nKRYSZTAŁ PRZEMIANY";
            NewItemCanvas.gameObject.SetActive(true);
        }
    }
}

