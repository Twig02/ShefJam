using UnityEngine;

public class ScreenSizer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(
            gameObject.transform.parent.GetComponent<RectTransform>().sizeDelta.x
            );
    }
}
