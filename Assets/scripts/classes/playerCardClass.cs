using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class playerCardClass : MonoBehaviour
{
   // int noOfPlayers = controller.noOfPlayers;
  //  public GameObject humanPlayer;

    //private int noOfPlayers = 3;  /*SET NUMBER OF PLAYERS HERE */
   // private int y = 1;



    //Define human player class
    public class playerCard
	{
        public int cardId;
        public string cardName;
        public int appearances;
        public int goals;
        public int assists;
        public int teams;
        public int premsWon;
        public int bookings;

        //constructor to allow the creation of 'player' class objects
        public playerCard(int id, string name, int apps, int gls, int assts, int tms, int prems, int bkngs)
		{
            cardId = id;
            cardName = name;
            appearances = apps;
            goals = gls;
            assists = assts;
            teams = tms;
            premsWon = prems;
            bookings = bkngs;
        }
	}

    void Start()
    {
        // Debug.Log("run?");    
    }

    void Update ()
	{
	}



    //Create player ID


    //*FUNCTIONS*//
    //Create player ID
    /* void createID()
     {
         for (int x = 0; x <= noOfPlayers; x++) //if x(current players) is less than number of players, current players ++
         {
             int ID; 

             //create playerID
             for (y = y; y <= noOfPlayers; y++)
             {
                 ID = y;
                 IDs.Add(ID);
                 controller.playersInGame.Add(ID);
             }
         }
     }

     //Create player name
     void createName()
     {
         string playerID;

         for (int x = 0; x < noOfPlayers; x++)
         {
             playerID = IDs[x].ToString();
             names.Add("player " + playerID);
         }
     }

     //Calculate how many cards to deal to players
     void assignCards()
     {
         int cards = controller.totalCards/noOfPlayers;
         int remainder = controller.totalCards - (cards*noOfPlayers);

         for (int x = 0; x < noOfPlayers; x++)
         {
             if (remainder > 0)
             {
                 cards++;
                 remainder--;
                 cardsInHand.Add(cards);
                 cards--;
             }
             else{
                 cards = controller.totalCards / noOfPlayers;
                 cardsInHand.Add(cards);
             }
         }
     }

     //Deal cards to each player one at a time
     void dealCards()
     {
         int cardsToDeal = controller.totalCards; //gets the amount of cards available for dealing set in controller.cs
         int c = 0;  //set starting amount of cards already dealt, updated ++ after each card is given

         for(c = c; c < cardsToDeal; c++) //loops through the amount of cards left to deal
         {
             for(int x = 0; x<noOfPlayers; x++) //loops through the number of players so a card can be dealt to each
             {
                 int dealCard = c + 1;
                 if (x == 0) { 
                 playerHands.player1.Add(dealCard); //stores value (card ID) into players hand in playerHands.cs
                 c++;
                 }
                 else if (x == 1)
                 {
                     playerHands.player2.Add(dealCard);
                     c++;
                 }
                 else if (x == 2)
                 {
                     playerHands.player3.Add(dealCard);
                     c++;
                 }
                 else if (x == 3)
                 {
                     playerHands.player4.Add(dealCard);
                     c++;
                 }
             }
         }
     }
     */
}