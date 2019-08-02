using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compare : MonoBehaviour {

    int player1ObtainedValue;
    int player2ObtainedValue;

    int sizeofp1hand;
    int sizeofp2hand;

    // Use this for initialization
    void Start () {

        player1ObtainedValue = ActiveCards.P1cardAttributes[controller.pickedAttribute];
        Debug.Log("p1 value " + player1ObtainedValue);

        player2ObtainedValue = ActiveCards.P2cardAttributes[controller.pickedAttribute];
        Debug.Log("p2 value " + player2ObtainedValue);

        sizeofp1hand = playerHands.player1.Count;
        Debug.Log("size of p1 hand " + sizeofp1hand);

        sizeofp2hand = playerHands.player2.Count;
        Debug.Log("size of p2 hand " + sizeofp2hand);

        if (player1ObtainedValue > player2ObtainedValue)
        {
            Debug.Log("P1 Wins");
            controller.winner = 1;
            playerHands.player2.Remove(controller.p2ActiveCard);
            playerHands.player1.Add(controller.p2ActiveCard);

            sizeofp1hand = playerHands.player1.Count;
            sizeofp2hand = playerHands.player2.Count;
            Debug.Log("size of p1 hand " + sizeofp1hand);
            Debug.Log("size of p2 hand " + sizeofp2hand);
            controller.p1SizeOfHand = sizeofp1hand;
            controller.p2SizeOfHand = sizeofp2hand;

        }
        else if (player1ObtainedValue < player2ObtainedValue)
        {
            Debug.Log("P2 Wins");
            controller.winner = 2;
            playerHands.player1.Remove(controller.p1ActiveCard);
            playerHands.player2.Add(controller.p1ActiveCard);

            sizeofp1hand = playerHands.player1.Count;
            sizeofp2hand = playerHands.player2.Count;
            Debug.Log("size of p1 hand " + sizeofp1hand);
            Debug.Log("size of p2 hand " + sizeofp2hand);
            controller.p1SizeOfHand = sizeofp1hand;
            controller.p2SizeOfHand = sizeofp2hand;

        }
        else
        {
            Debug.Log("draw");

        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
