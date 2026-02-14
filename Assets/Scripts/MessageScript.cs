using UnityEngine;

public class MessageScript : MonoBehaviour
{
    GameObject textChild;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textChild = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
