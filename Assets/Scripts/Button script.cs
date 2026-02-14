using UnityEngine;

public class TestButtonLogic : MonoBehaviour, IClickable
{
    public void OnClick()
    {
        Debug.Log("Button Clicked!");
    }
}