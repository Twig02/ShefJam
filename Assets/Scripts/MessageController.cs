using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MessageController : MonoBehaviour
{
    public GameObject emptyButtonPrefab;
    public Sprite responseSprite;
    public GameObject[] buttonList = new GameObject[3];

    private List<GameObject> messages;
    private Vector2 defaultPosition;
    int personalityType;
    int messageCounter;
    int score;
    public GameObject tick;

    // Dialogue
    private string[,] characterDialogue = { 
        // Flirty
        {
            "My my, who is this cutie I just found",
            "Soo, do you want to spend the night with me",
            "So what's your opinion on being tied up",
            "Oh, that's one good response",
            "Coming on a bit strong now'",
            "You're no fun",
            "Oh, yes, we will~",
            "It's not me, it's YOU"
        },
        // Chav
        {
            "Wagwan G. U send?",
            "What kinda music you into brev?",
            "I rate we roll one and see what happens yeah?",
            "Nice one brev",
            "Yeah whatever man, you get me",
            "Nah what you sayin blud",
            "Mad ting I'll pick you up in the whip at 8 yeah?",
            "Man got balls askin that so early. Fuck off bro"
        },
        // Dry
        {
            "Hey",
            "hmm",
            "lol",
            "Nice",
            "Yeah fair",
            "*seen*",
            "Sure",
            "No"
        },
        // Nerd
        {
            "Heyyyy. Do you play DnD?",
            "My spider senses tingle",
            "Hear me out, a date in the library",
            "Oh YES I like that",
            "Hmm, I'm not sure that's'",
            "Ew",
            "Hell yeah, we can play DnD after too",
            "Nah, dude, you stink"
        },
        // Northern Soul
        {
            "Ayup. How'd you take your brew?",
            "What are you having for your tea tonight then?",
            "Where abouts up north are ya from?",
            "That's reyt good",
            "Ay, our kid",
            "Your kind bloody disgust me",
            "That sounds lovely pet",
            "I'd rather go down t'pit"
        }
    };

    // Responses
    private string[,] playerDialogue = { 
        // Flirty
        {
            "You da real cutie", "Not if I find you cute first", "Calm thyself",
            "Sounds awesome, I'll bring snacks", "YES, let's do some FUN stuff~", "At least, take me out to dinner first, damn",
            "If you let me tie you up first ;)", "YES YES PLEASE I NEED THIS", "CHILL I'M NOT INTO THAT",
            "Well well, looks like we will have a great night together"
        },
        // Chav
        {
            "Buy me a drink and you'll get more than that", "Ye type shit *image*", "You first?",
            "Dizzie Rascal absolutely slaps", "I actually knew the Arctic Monkeys before they were big", "Pink Pony Club goes hard in the clurb",
            "You buy the grass I'll bring some skins", "I got coke if you want somet stronger", "I rate getting wankered on cheap wine instead tbh",
            "You should come West Street Live tonight. Wanna split a '5 round with me?"
        },
        // Dry
        {
            "Hello to you too", "HEYYYY HELLO", "Care to be more conversational?",
            "Say nice if you wanna go on a date", "I'm gonna need a bit more than that", "HMM",
            "LMAO", "lol", "shag?",
            "Okay, the convo didn't go anywhere. Wanna hang out in person?"
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
            "Proper builder's cuppa nowt better.", "Gotta go with PG tips right?", "I'm actually trying to stay off the caffeine for a bit.",
            "Pie, mash and gravy all the way.", "3 pints of lager and a packet of crisps.", "Cheeky tikka masala down the curry house",
            "I were born in Bradford, but I were made int Royal Navy", "Grew up in Newcastle. Got sausage rolls flowing through me blood", "Just across the Pennines in Manchester",
            "Fancy going t'pub later?"
        }
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject button in buttonList) { button.SetActive(false); }
    }

    public void startMessaging(string personality)
    {
        tick.SetActive(false);

        foreach (GameObject button in buttonList) { button.SetActive(true); }

        switch (personality)
        {
            case "Flirty":
                personalityType = 0; break;
            case "Chav":
                personalityType = 1; break;
            case "Dry":
                personalityType = 2; break;
            case "Nerd":
                personalityType = 3; break;
            case "Northern Soul":
                personalityType = 4; break;
            default:
                personalityType = 5; break;
        }
        personalityType = UnityEngine.Random.Range(0, 5);
        messages = new List<GameObject>();
        defaultPosition = new Vector2(-12, -80);

        messageCounter = 0;
        startConversation(characterDialogue[personalityType, messageCounter]);
        updateButtons();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onButtonClick()
    {
        foreach (GameObject button in buttonList){ button.SetActive(false); }
        string text = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<TMP_Text>().text;
        createNewMessage(true, text);
        int optionIndex = -1;
        for (int j = 0; j < playerDialogue.GetLength(1);j++) 
        {
            if (playerDialogue[personalityType,j].Trim() == text.Trim())
            {
                optionIndex = j;
                break;
            }
        }

        StartCoroutine(RespondToMessage(text, optionIndex));
    }

    public void startConversation(string firstMessageText)
    {
        createNewMessage(false, firstMessageText);
    }

    IEnumerator RespondToMessage(string userMessage, int optionIndex)
    {
        if (optionIndex == 9)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(1.0f, 3.0f));
            int finalResultIndex = 7;
            if (score >= UnityEngine.Random.Range(1,11))
            {
                finalResultIndex = 6;
                GameObject.Find("Content").GetComponent<Init>().successfulDates++;
                Debug.Log(GameObject.Find("Content").GetComponent<Init>().successfulDates);
            }
            else
            {
                finalResultIndex = 7;
            }

            tick.SetActive(true);
                createNewMessage(false, characterDialogue[personalityType, finalResultIndex]);

            foreach (GameObject btn in buttonList) btn.SetActive(false);
            messageCounter = 99;

            yield return new WaitForSeconds(3f);
            foreach (GameObject message in messages) message.SetActive(false);

        }
        else
        {
            messageCounter++;
            yield return new WaitForSeconds(((float)UnityEngine.Random.Range(8, 21)) / 10f);

            int indexOfResponse = 3 + (optionIndex % 3);
            score += 5 - indexOfResponse + 1;
            Debug.Log(score);
            createNewMessage(false, characterDialogue[personalityType, indexOfResponse]);

            yield return new WaitForSeconds(((float)UnityEngine.Random.Range(8, 21)) / 10f);
            if (messageCounter < 3)
            {
                createNewMessage(false, characterDialogue[personalityType, messageCounter]);
            }
            updateButtons();
        }
    }

    private void createNewMessage(bool userMessage, string messageText)
    {
        // Button has been clicked, create a new message in chat
        Transform parent = gameObject.transform.GetChild(1);
        GameObject newMessage = Instantiate(emptyButtonPrefab, parent);

        // Add to list of messages
        shiftMessages();
        messages.Add(newMessage);
        Vector2 position = defaultPosition;

        // Make sure message sprite is right
        if (userMessage)
        {
            newMessage.GetComponent<Image>().sprite = responseSprite;
            position = new Vector2(10, defaultPosition.y);
        }

        // Set position
        newMessage.GetComponent<RectTransform>().localPosition = position;

        // Set text
        newMessage.transform.GetChild(0).GetComponent<TMP_Text>().SetText(messageText);
    }

    private void shiftMessages()
    {
        foreach (GameObject x in messages)
        {
            Vector2 oldPos = x.GetComponent<RectTransform>().localPosition;
            x.GetComponent<RectTransform>().localPosition = new (oldPos.x, oldPos.y+70);
        }

        if (messages.Count >= 3)
        {
            Destroy(messages[0]);
            messages.Remove(messages[0]);
        }
    }

    public void updateButtons()
    {
        if (messageCounter == 3)
        {
            buttonList[0].SetActive(false);
            buttonList[2].SetActive(false);

            buttonList[1].SetActive(true);
            buttonList[1].transform.GetChild(0).GetComponent<TMP_Text>().text = playerDialogue[personalityType, 9];

            return;
        }

        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].SetActive(true);

            int index = (3 * messageCounter) + i;

            buttonList[i].transform.GetChild(0).GetComponent<TMP_Text>().text =
                playerDialogue[personalityType, index];
        }
    }
}
