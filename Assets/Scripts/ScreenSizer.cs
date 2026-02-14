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
<<<<<<< HEAD
        if (parentRect != null)
        {
            myRect.sizeDelta = parentRect.sizeDelta;
        }
=======

>>>>>>> b719a45c911854be66d8bdd7e3b976a880d3afe9
    }
}