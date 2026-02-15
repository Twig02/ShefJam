using UnityEngine;

public class Crossscript : MonoBehaviour
{ 
    public GameObject contentObject;
    public void onButtonClick()
    {
        System.Random rmd = new System.Random();
        Swipee currentSwipe = new Swipee(rmd);
        contentObject.GetComponent<Init>().UpdateSwipeScreen(currentSwipe);
    }
}

