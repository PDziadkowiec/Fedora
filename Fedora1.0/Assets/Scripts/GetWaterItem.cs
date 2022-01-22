using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetWaterItem : MonoBehaviour
{
    //Skrypt przypisany do obiektu WATER ITEM
    // Skrypt wywołuje się po podniesniu Wody Ze Zaczarowanego Źródła

    public AudioSource audioSource;
    public AudioClip getWaterSE;

    public Text QuestText;

    public Canvas NewItemCanvas;
    public Text ItemText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameData.hasWater = true;
            //Zmiana treści questa w Zadaniach
            GameData.listOfQuests = $"○ Zdobądź składniki do wytworzenia mikstury: " +
                $"\n- {GameData.hasGrapeBoolToInt()}/1 Winogrono " +
                $"\n- {GameData.hasBasilBoolToInt()}/1 Bazylia " +
                $"\n- {GameData.hasWaterBoolToInt()}/1 Woda z Zaczarowanego Źródła " +
                $"\n- {GameData.hasCrystalBoolToInt()}/1 Kryształ Przemiany " +
                $"\nGdy zdobędziesz wszystkie, wróć do Pani Ślimak." +
                $"\n\n○ Odszukaj porozmieszczane po całej krainie Zalążki Magii, by zdobyć nowe umiejętności";
            QuestText.text = GameData.listOfQuests;
            
            audioSource.GetComponent<AudioSource>().PlayOneShot(getWaterSE);
            Destroy(gameObject);
            Time.timeScale = 0;
            ItemText.text = "Zdobyto przedmiot:\nWODA Z ZACZAROWANEGO ŹRÓDŁA";
            NewItemCanvas.gameObject.SetActive(true);
        }
    }
}
