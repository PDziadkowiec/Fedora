﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetGrapeItem : MonoBehaviour
{
    public Text QuestText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameData.hasGrape = true;
            //Zmiana treści questa w Zadaniach
            GameData.listOfQuests = $"○ Zdobądź składniki do wytworzenia mikstury: \n- 1/1 Winogrono \n- 0/1 Bazylia \n- 0/1 Woda z Zaczarowanego Źródła \n- 0/1 Kryształ Przemiany \n\n○ Odszukaj porozmieszczane po całej krainie Zalążki Magii, by zdobyć nowe umiejętności";
            QuestText.text = GameData.listOfQuests;
            //Zrobić: pokazuje się obrazek winogrona w Przedmiotach
            Destroy(gameObject);
        }
    }

}
