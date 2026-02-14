using UnityEngine;
using System;
using TMPro;

public class Init : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] textFields;

    void Start()
    {
        System.Random rmd = new System.Random();
        Swiper player = new Swiper(rmd);
        Swipee[] successfulMatches = new Swipee[15];
        Swipee currentSwipe = new Swipee(rmd);
        UpdateSwipeScreen(currentSwipe);
    }

    void UpdateSwipeScreen(Swipee swipee)
    {
        textFields[0].text = swipee.Name;
        textFields[1].text = "Age: " + swipee.Age.ToString();
        textFields[2].text = "Height: " + swipee.Height;
        textFields[3].text = "Purity: " + swipee.RicePurityScore;
        textFields[4].text = "Job:\n" + swipee.Job;
        textFields[5].text = "Dating Intentions:\n" + swipee.DatingIntentions;
        textFields[6].text = swipee.Description;
    }
}
