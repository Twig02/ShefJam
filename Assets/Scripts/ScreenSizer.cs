using UnityEngine;

public class ScreenSizer : MonoBehaviour
{
    private RectTransform myRect;
    private RectTransform parentRect;

    void Awake()
    {
        myRect = GetComponent<RectTransform>();
        parentRect = transform.parent.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (parentRect != null)
        {
            myRect.sizeDelta = parentRect.sizeDelta;
        }
    }
}