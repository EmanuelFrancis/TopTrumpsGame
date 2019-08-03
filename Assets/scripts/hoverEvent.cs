using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public static int BgColourHeight;

    public static RectTransform rectTransform;

    public int noOfAttributes = 6;

    public GameObject attributeHovered;

    //public UnityEvent OnHover = new UnityEvent();
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        loadPlayer1Card.attributesBoxColour = 1; //Hover Colour
        Debug.Log(loadPlayer1Card.attributesBoxColour + "ColourValue");

        Debug.Log(pointerEventData.pointerEnter + "pinterEventData");
       // Debug.Log(loadPlayer1Card.textBoxGoals.name + "TBG");
      //  Debug.Log(loadPlayer1Card.textBoxApps + "TBA");

        attributeHovered = pointerEventData.pointerEnter;

        //   BgColourHeight = pointerEventData.pointerEnter

        
        if (pointerEventData.pointerEnter.name == loadPlayer1Card.textBoxApps.name)
        {
            loadPlayer1Card.rectTransform = loadPlayer1Card.textBoxBGBox.GetComponent<RectTransform>();
            loadPlayer1Card.rectTransform.localPosition = new Vector3(-55, -60, 0);
            loadPlayer1Card.rectTransform.sizeDelta = new Vector2(200, 22);
            Debug.Log("-60");
        }
        else if(pointerEventData.pointerEnter.name == loadPlayer1Card.textBoxGoals.name)
        {
            loadPlayer1Card.rectTransform = loadPlayer1Card.textBoxBGBox.GetComponent<RectTransform>();
            loadPlayer1Card.rectTransform.localPosition = new Vector3(-55, -90, 0);
            loadPlayer1Card.rectTransform.sizeDelta = new Vector2(200, 22);
            Debug.Log("-90");
        }




      //  loadPlayer1Card.rectTransform = loadPlayer1Card.textBoxBGBox.GetComponent<RectTransform>();

        //    loadPlayer1Card.rectTransform.localPosition = new Vector3(-60, -100, 0);
        //   loadPlayer1Card.rectTransform.sizeDelta = new Vector2(200, 22);


     //   loadPlayer1Card.textBoxBGBox.transform.Translate(0, -30, 0);

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
