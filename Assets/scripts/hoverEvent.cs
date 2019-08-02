using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    

    //public UnityEvent OnHover = new UnityEvent();
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        loadPlayer1Card.attributesBoxColour = 1; //Hover Colour
        Debug.Log(loadPlayer1Card.attributesBoxColour + "ColourValue");

    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (loadPlayer1Card.attributesBoxColour == 4)  //Null value no colour
        {
            Debug.Log("=3" + loadPlayer1Card.attributesBoxColour);
            Debug.Log(loadPlayer1Card.attributesBoxColour + "ColourValue");

        }
        else if(loadPlayer1Card.attributesBoxColour != 3) { //if colour is NOT set to selected colour
            loadPlayer1Card.attributesBoxColour = 2;  //Transparent
            Debug.Log("abc");
            Debug.Log(loadPlayer1Card.attributesBoxColour + "ColourValue");
        }

    }

}
