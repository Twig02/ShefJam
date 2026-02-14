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

    private List<GameObject> messages;
    private Vector2 defaultPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        messages = new List<GameObject>();
        defaultPosition = new Vector2(-12, -95);

        startConversation("Starting the Conversation");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onButtonClick()
    {
        string text = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<TMP_Text>().text;
        createNewMessage(true, text);
        StartCoroutine(RespondToMessage(text));
    }

    public void startConversation(string firstMessageText)
    {
        createNewMessage(false, firstMessageText);
    }

    IEnumerator RespondToMessage(string userMessage)
    {
        float startTime = Time.time;
        yield return new WaitForSeconds(((float)UnityEngine.Random.Range(8, 21)) / 10f);
        createNewMessage(false, "I respond to \"" + userMessage + "\"");

        startTime = Time.time;
        yield return new WaitForSeconds(((float)UnityEngine.Random.Range(3, 15)) / 10f);
        createNewMessage(false, "Heres a question");
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
}
