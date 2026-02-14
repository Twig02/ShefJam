using UnityEngine;

public class Crossscript : MonoBehaviour
{ 
    public GameObject contentObject;
    public void onButtonClick()
    {
        System.Random rmd = new System.Random();
        Swipee currentSwipee = new Swipee(rmd);
        contentObject.GetComponent<Init>().UpdateSwipeScreen(currentSwipee);
    }
}

