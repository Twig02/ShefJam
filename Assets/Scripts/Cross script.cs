using UnityEngine;

public class Crossscript : MonoBehaviour
{ 
    public GameObject contentObject;
    public void onButtonClick()
    {
        Swipee currentSwipe = contentObject.GetComponent<Init>().currentSwipe;

        System.Random rmd = new System.Random();
        currentSwipe = new Swipee(rmd);
        contentObject.GetComponent<Init>().UpdateSwipeScreen(currentSwipe);
    }
}

