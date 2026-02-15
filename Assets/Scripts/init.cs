using UnityEngine;
using UnityEngine.UI; 
using System;
using TMPro;
using System.Collections.Generic;

 public class Init : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI[] textFields;
    [SerializeField] private Image profileDisplay;
    [SerializeField] private List<Sprite> profileSprites = new List<Sprite>();
    public Swipee currentSwipe;
    public Swiper player;
    public int successfulMatches;
    public int successfulDates;
    void Start() {
        System.Random rmd = new System.Random();
        player = new Swiper(rmd);
        successfulMatches = 0;
        successfulDates = 0;
        currentSwipe = new Swipee(rmd);
        UpdateSwipeScreen(currentSwipe);

    } 

    public void UpdateSwipeScreen(Swipee swipee)
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