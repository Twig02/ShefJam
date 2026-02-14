using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MessageController : MonoBehaviour
{
    public GameObject emptyButtonPrefab;

    private List<GameObject> messages;
    public Vector2 defaultPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        messages = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onButtonClick()
    {
        // Button has been clicked, create a new message in chat
        Transform parent = EventSystem.current.currentSelectedGameObject.transform.parent.transform.parent.GetChild(1); ;
        GameObject newMessage = Instantiate(emptyButtonPrefab, parent);

        messages.Add(newMessage);
    }
}
