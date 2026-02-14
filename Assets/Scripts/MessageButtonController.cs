using TMPro;
using UnityEngine;

public class MessageButtonController : MonoBehaviour
{
    public GameObject[] buttonList = new GameObject[3];

    // Player Responses
    private string[,] playerDialogue = { 
        // Flirty
        {
            "You da real cutie", "Not if I find you cute first", "Calm thyself",
            "Sounds awesome, I’ll bring snacks", "YES, let's do some FUN stuff~", "At least, take me out to dinner first, damn",
            "If you let me tie you up first ;)", "YES YES PLEASE I NEED THIS", "CHILL I’M NOT INTO THAT",
            "Well well, looks like we will have a great night together"
        },
        // Chav
        {
            "Buy me a drink and you’ll get more than that", "Ye type shit *image*", "You first?",
            "Dizzie Rascal absolutely slaps", "I actually knew the Arctic Monkeys before they were big", "Pink Pony Club goes hard in the clurb",
            "You buy the grass I’ll bring some skins", "I got coke if you want somet stronger", "I rate getting wankered on cheap wine instead tbh",
            "You should come West Street Live tonight. Wanna split a £5 round with me?"
        },
        // Dry
        {
            "Hello to you too", "HEYYYY HELLO", "Care to be more conversational?",
            "Say nice if you wanna go on a date", "I’m gonna need a bit more than that", "HMM",
            "LMAO", "lol", "shag?",
            "Okay, the convo didn’t go anywhere. Wanna hang out in person?"
        },
        // Nerd
        {
            "Yes, my favourite class is Rogue", "No? What is that", "Yes, I like to play Zoomer class",
            "Spooder man", "Nah, Deadpool better", "Ewww, what else is tingling",
            "Yes, please, I love reading", "How about a coffee date instead", "NERDDDD",
            "So, fancy a date with me now?"
        },
        // Northern Soul
        {
            "Proper builder’s cuppa nowt better.", "Gotta go with PG tips right?", "I’m actually trying to stay off the caffeine for a bit.",
            "Pie, mash and gravy all the way.", "3 pints of lager and a packet of crisps.", "Cheeky tikka masala down the curry house",
            "I were born in Bradford, but I were made int Royal Navy", "Grew up in Newcastle. Got sausage rolls flowing through me blood", "Just across the Pennines in Manchester",
            "Fancy going t’pub later?"
        }
    };

    public void updateButtons(int responseNumber, int personalityType)
    {
        if (responseNumber == 3) {
            buttonList[0].SetActive(false);
            buttonList[2].SetActive(false);
            buttonList[1].GetComponent<TMP_Text>().text = playerDialogue[personalityType, 9];
        }
        for (int i = 0; i < buttonList.Length; i++) {
            buttonList[i].transform.GetChild(0).GetComponent<TMP_Text>().text = 
                playerDialogue[personalityType, (3*responseNumber)+i];
        }
    }
}
