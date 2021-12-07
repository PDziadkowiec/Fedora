using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public static int healthPoints = 3;
    public static int maxHealthPoints = 3;
    public static int coins = 0;
    public static int maxCoins = 100;
    public static bool jump = false;
    public static bool triggerLadySnail = false;
    public static bool firstForestLadySnailDialogue = true;
    public static string location = "Las";


    //Tablice z dialogami
    // [0] - Imię postacii
    // [1] - Kwestia dialogowa

    public static string[,] ladySnailFirstDialogueForest = new string[,]
    {
        {"...", "Ohoho, witaj nieznajomy. Nie spotkałam cię tu jeszcze." },
        {"Rocco" ,"Pomocy! Potrzebuję pomocy!" },
        {"...", "Kochanieńki spokojnie. Najpierw zdradź mi swoje imię." },
        {"Rocco", "Nazywam się Rocco." },
        {"Pani Ślimak", "Dobrze, do mnie zwracają się po prostu Pani Ślimak. \nA teraz w czym mogę ci pomóc, Rocco?" },
        { "Rocco", "Zostałem magicznie zamieniony w żabę! Muszę stać się z powrotem człowiekiem!" },
        {"Pani Ślimak", "Mhm… rozumiem. "},
        {"Pani Ślimak", "Wiem, że istnieje mikstura, która sprawia, że istoty wracają do swojej pierwotnej formy. \nMyślę, że mogłaby zadziałać w twoim przypadku." },
        {"Rocco", "Świetnie! Gdzie mogę ją zdobyć?" },
        { "Pani Ślimak", "Musisz zebrać wszystkie CZTERY potrzebne składniki do jej wytworzenia: WINOGRONO, BAZYLIA, WODA Z ZACZAROWANEGO ŹRÓDŁA i KRYSZTAŁ PRZEMIANY." },
        { "Rocco", "Gdzie mogę je znaleźć?" },
        { "Pani Ślimak", "WINOGRONA szukałabym w Winnicy, a BAZYLIĘ może gdzieś w Mieście. Często jest tam używana do doprawiania różnych potraw. Pozostałe składniki musisz odnaleźć sam." },
        { "Pani Ślimak", "Gdy zdobędziesz wszystkie składniki wróć do mnie." },
        { "Rocco", "Dziękuję bardzo! Wyruszam w drogę!" },
        { "Pani Ślimak", "Poczekaj… Dookoła czyha dużo niebezpieczeństw, więc uważaj na siebie." },
        { "Pani Ślimak", "I och… skoro byłeś człowiekiem, nie wiesz jak używać żabich zdolności…" },
        { "Pani Ślimak", "Poszukaj ZALĄŻKÓW MAGII, one pomogą ci opanować żabie umiejętności." },
        { "Pani Ślimak", "Powodzenia kochanieńki!" }
    };

    public static string[,] ladySnailNoJumpDialogueForest = new string[,]
    {
        { "Pani Ślimak", "Rocco, powinieneś skupić się na znalezieniu ZALĄŻKA MAGII, a nie na zabawianiu mnie rozmową, ho ho ho." },
        {"Pani Ślimak", "Jestem pewna, że znajdziesz jeden gdzieś tutaj w Lesie." }
    };

    public static string[,] ladySnailDialogueForest = new string[,]
   {
        { "Pani Ślimak", "Oh! Opanowałeś skok!" },
        {"Pani Ślimak", "Teraz odnajdywanie składników mikstury będzie o niebo łatwiejsze, nie sądzisz kochanieńki?" }
   };

}
