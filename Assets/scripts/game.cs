using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game : MonoBehaviour {
    public RectTransform rectTransform;
    public Font arial;
    // Use this for initialization
    void Start () {

        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        Debug.Log("gameMethod started");

      //  controller.rounds = 1;


        if (controller.rounds == 1)
        {

        
       // dealCards();
         //   createInfoBars();
            GameObject updateBars = new GameObject();
        updateBars.name = "update bars";
        updateBars.GetComponent<playerInfoValues>();
        }

        for (int x = controller.gameWinner; x == 0; x++)
        {
            Debug.Log("game winner " + controller.winner);
            roundBegin();
            controller.rounds++;
        }



    }

    // Update is called once per frame
    void Update () {
		
	}

    //Deal cards to each player one at a time
    void dealCards()
    {
        int cardsToDeal = controller.totalCards; //gets the amount of cards available for dealing set in controller.cs
        int c = 1;  //set starting amount of cards already dealt, updated ++ after each card is given

        for (c = c; c < cardsToDeal;) //loops through the amount of cards left to deal
        {



            for (int x = 1; x <= controller.noOfPlayers; x++) //loops through the number of players so a card can be dealt to each
            {

                int dealCard = c;
                if (x == 1)
                {
                    playerHands.player1.Add(dealCard); //stores value (card ID) into players hand in playerHands.cs

                    c++;

                }
                else if (x == 2 && c <= cardsToDeal)
                {
                    playerHands.player2.Add(dealCard);

                    c++;

                }
                else if (x == 3 && c <= cardsToDeal)
                {
                    playerHands.player3.Add(dealCard);

                    c++;

                }
                else if (x == 4 && c <= cardsToDeal)
                {
                    playerHands.player4.Add(dealCard);

                    c++;

                }
            }
        }
    }


    public void roundBegin()
    {

        GameObject roundNo = new GameObject();
        roundNo.name = "HUMANroundNo";
        roundNo.transform.SetParent(playerInfoBar.P1Bar.transform);
        roundNo.AddComponent<Text>();
        roundNo.AddComponent<Canvas>();

        Text roundNoText = roundNo.GetComponent<Text>();
        roundNoText.font = arial;
        roundNoText.text = "Round " + (controller.rounds.ToString());
        roundNoText.fontSize = 30;
        roundNoText.color = Color.black;
        roundNoText.alignment = TextAnchor.MiddleCenter;

        rectTransform = roundNoText.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-240, 118, 0);
        rectTransform.sizeDelta = new Vector2(150, 50);

        Debug.Log("roundBeginMethod started");

        controller.p1SizeOfHand = playerHands.player1.Count;
        controller.p2SizeOfHand = playerHands.player2.Count;


        Debug.Log("p1 hand " + controller.p1SizeOfHand);
        Debug.Log("p2 hand " + controller.p2SizeOfHand);

        if (controller.p1SizeOfHand == 0)
        {
            controller.gameWinner = 2;
        }
        else if (controller.p2SizeOfHand == 0)
        {
            controller.gameWinner = 1;
        }
        else
        {
            ChooseWhosTurn();

            Debug.Log("Player" + controller.attacker + "turn");

            p1pickCard();

            controller.P1mainCard = new GameObject();
            controller.P1mainCard.name = "p1MainCard";
            controller.P1mainCard.AddComponent<loadPlayer1Card>();

            p2pickCard();

            controller.P2mainCard = new GameObject();
            controller.P2mainCard.name = "p2MainCard";
            controller.P2mainCard.AddComponent<loadPlayer2Card>();

            GameObject popupMenu = new GameObject();
            popupMenu.name = "popupMenu";
            popupMenu.AddComponent<loadPopup>();

            Debug.Log(controller.attPicked);

            //  if (attPicked == true)
            //          {
            // //              P1mainCard.AddComponent<compare>();
            //           }



        }

    }

    void ChooseWhosTurn()
    {
        //  playersReady = 0;



        if (controller.winner == 0)
        {
            controller.attacker = 1;
            controller.defender = controller.attacker + 1;
            controller.ActiveplayerInstance = controller.playerInstance01;
        }
        else
        {
            controller.attacker = controller.winner;
            controller.defender = controller.attacker + 1;
            controller.ActiveplayerInstance = controller.playerInstance02;
        }
        //     Debug.Log("playersReady1" + playersReady);
        //   playerTurnScreen();
        // playersReady = 0;
        //     timeWait();
        //     Debug.Log("playersReady2" + playersReady);
        //  Destroy(GameObject.Find("PlayerTurnScrnParent"));


    }

    void p1pickCard()
    {

        int pickedCard;

        //     p1SizeOfHand = playerHands.player1.Count;   /*count how many cards player has*/

        if (controller.rounds == 1) /* If its the first round of the game select a random card to start with */
        {

            controller.arrayListNum = Random.Range(0, controller.p1SizeOfHand); /* Randomly select an array slot to choose which card to select from the players hand */
            pickedCard = playerHands.player1[controller.arrayListNum]; /* obtains the cards ID held in the picked array slot arrayListnum and stores to pickedCard */
            controller.p1ActiveCard = pickedCard; /* stores the picked card ID to global int p1ActiveCard */
            controller.ActiveCard = pickedCard; /* stores the picked card ID to global int p1ActiveCard */

        }
        else /* otherwise select the next card in the players hand */
        {
            if (controller.arrayListNum > controller.p1SizeOfHand - 2)  /* if the selected array slot number is higher than available array slots... */  /*CHECK MEEE*/
            {

                controller.arrayListNum = 0; /* reset selected array slot to the beginning of the array */
                pickedCard = playerHands.player1[controller.arrayListNum];  /* obtains the cards ID held in the picked array slot arrayListnum and stores to pickedCard */
                controller.p1ActiveCard = pickedCard; /* stores the picked card ID to global int p1ActiveCard */
                controller.ActiveCard = pickedCard; /* stores the picked card ID to global int p1ActiveCard */
                controller.arrayListNum++; /* move to the next card in the array */

            }
            else /* otherwise the selected array slot is within the players available cards */
            {

                controller.arrayListNum++; /* move to the next card in the array */
                pickedCard = playerHands.player1[controller.arrayListNum]; /* obtains the cards ID held in the picked array slot arrayListnum and stores to pickedCard */

                controller.p1ActiveCard = pickedCard; /* stores the picked card ID to global int p1ActiveCard */
                controller.ActiveCard = pickedCard; /* stores the picked card ID to global int p1ActiveCard */
            }
        }
    }


    void p2pickCard()
    {


        int pickedCard;

        //count how many cards player has
        //   p2SizeOfHand = playerHands.player2.Count;


        if (controller.rounds == 1)
        {
            //pick random num
            controller.arrayListNum = Random.Range(0, controller.p2SizeOfHand);


            //reveal value of random num from list
            pickedCard = playerHands.player2[controller.arrayListNum];

            controller.p2ActiveCard = pickedCard;
            controller.ActiveCard = pickedCard; /* stores the picked card ID to global int p1ActiveCard */
        }
        else
        {
            if (controller.arrayListNum > controller.p2SizeOfHand - 2)
            {
                controller.arrayListNum = 0;

                //reveal value of random num from list
                pickedCard = playerHands.player2[controller.arrayListNum];

                controller.p2ActiveCard = pickedCard;
                controller.ActiveCard = pickedCard; /* stores the picked card ID to global int p1ActiveCard */
                controller.arrayListNum++;

            }
            else
            {
                controller.arrayListNum++;

                //reveal value of random num from list
                pickedCard = playerHands.player2[controller.arrayListNum];

                controller.p2ActiveCard = pickedCard;
                controller.ActiveCard = pickedCard; /* stores the picked card ID to global int p1ActiveCard */
            }
        }
    }

    void createInfoBars()
    {
        controller.GameBG = new GameObject(); /* Creates a parent humanPlayer GO */
        controller.GameBG.name = "PlayerBarGO";  /* Names the parent humanPlayer GO */
        controller.GameBG.AddComponent<Canvas>();
        controller.GameBG.AddComponent<CanvasScaler>();
        controller.GameBG.AddComponent<GraphicRaycaster>();
        controller.GameBG.AddComponent<playerInfoBar>();
    }

    IEnumerator waitforKwyDown()
    {
        while (!Input.GetKeyDown("y"))
        {
            //     Debug.Log("null");

            yield return null;


        }

        //   controller newRound = FindObjectOfType<controller>();
        // newRound.game();
        //  controller.roundBegin();
        Destroy(GameObject.Find("SelectAttParent"));
        Destroy(GameObject.Find("textBoxChooseAtt"));
        Destroy(GameObject.Find("ChooseTextGO"));
        Debug.Log("playersReady3");


    }


}
