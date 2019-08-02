using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

// pointerPress example.
// Note that an image was added to a Canvas->Image.  This Image has the
// following script added.  OnPointerUp is called when the texture is
// clicked and released.

public class FindSelectedAttribute : MonoBehaviour, IPointerUpHandler
{
    // The mouse was released from the GameObject.
    public void OnPointerUp(PointerEventData eventData)
    {
       // loadPlayer1Card.attributesBoxColour = 3;
        StartCoroutine(BlinkTimer());
      //  loadPlayer1Card.attributesBoxColour = 0;
        Debug.Log(eventData.pointerPress + "was clicked");
        Debug.Log(loadPlayer1Card.attributesBoxColour + "ColourValue");
    }

    IEnumerator BlinkTimer()
    {
        

        loadPlayer1Card.attributesBoxColour = 3;
        yield return new WaitForSeconds(2);
        loadPlayer1Card.attributesBoxColour = 2;
 

    }

}