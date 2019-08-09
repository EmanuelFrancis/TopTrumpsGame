using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour
{

    [SerializeField]
    public static int totalCards = 20;  /*SET NUMBER OF TOTAL CARDS */
    public static int noOfPlayers = 2;  /*SET NUMBER OF PLAYERS HERE */
    private int y = 1;
    int rounds = 1;

    RectTransform rectTransform;

    public static GameObject humanPlayer; /* Define parent human player GameObject */
   public GameObject activeCard; /* Hold ID of the current card in play */

    //** is set by pickAttribute() method to randomly pick a card attribute for comparison in compare.cs **//
    public static int pickedAttribute;

    public static GameObject ActiveplayerInstance;
    public static GameObject playerInstance01;
    public static GameObject playerInstance02;

    public GameObject player1sActiveCard;
    public GameObject player2sActiveCard;

    // public GameObject Player1;

    //Declare Lists(Arrays) that will store the parameter values to be obtained when needed
    List<int> IDs = new List<int>();
    List<int> cardsInHand = new List<int>();
    List<string> names = new List<string>();

    string Player1Name = "Player1";
    string Player2Name = "Player2";

    public static List<string> playersInGame = new List<string>(); /* Holds the names of instanced players */
    public static List<string> eliminatedPlayers = new List<string>();
    

    public static int winner = 0;
    public static int attacker;
    public static int defender;

    public static int ActivePlayer=1; /* Ovrall player game is currently reading */
    public static int ActiveCard; /* Ovrall card game is currently reading */
    public static int p1ActiveCard; /* Receives the p1 picked card ID from p1pickedCard() */
    public static int p2ActiveCard; /* Receives the p2 picked card ID from p2pickedCard() */
    public static int p1SizeOfHand;
    public static int p2SizeOfHand;

    public static int arrayListNum = 0; /* Receives and holds the picked array slot for the picked attribute to compare from p1pickedCard() */

    public static GameObject P1mainCard;
    public static GameObject P2mainCard;


    void Start()
    {

     //   GameObject StartMenu = new GameObject();
     //   StartMenu.name = "Start Menu";
     //   StartMenu.AddComponent<startMenu>();
 
        assignCards(); /* calls method to deal cards evenly between the players in game */


        humanPlayer = new GameObject(); /* Creates a parent humanPlayer GO */
        humanPlayer.name = "PlayerParentGameObject";  /* Names the parent humanPlayer GO */




        playerInstance01 = (GameObject)Instantiate(humanPlayer); /* creates an instance of the humanPlayer GO called playerInstance01 */
        playerInstance01.name = Player1Name; /* Sets the name of the p1 instance to whatever has been specified at Player1Name */
        playersInGame.Add(Player1Name); /* Add the player name string to the players in game list */

        playerInstance01.AddComponent<Canvas>();   /**/
        playerInstance01.AddComponent<CanvasScaler>();   /**/
        playerInstance01.AddComponent<GraphicRaycaster>();   /**/




        playerInstance02 = (GameObject)Instantiate(humanPlayer);
        playerInstance02.name = Player2Name;
        playersInGame.Add(Player2Name);

        playerInstance02.AddComponent<Canvas>();   /**/
        playerInstance02.AddComponent<CanvasScaler>();   /**/
        playerInstance02.AddComponent<GraphicRaycaster>();   /**/


        ActiveplayerInstance = (GameObject)Instantiate(humanPlayer); /* creates an instance of the humanPlayer GO called playerInstance01 */
        ActiveplayerInstance.name = "ActivePlayer"; /* Sets the name of the p1 instance to whatever has been specified at Player1Name */




        dealCards();

        int remainingNoPlayers = playersInGame.Count;

        if (rounds > 1 && p1SizeOfHand == 0)
        {
            Debug.Log("game over P2 Wins");
            // Time.timeScale = 0;
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            //  roundBegin();
        }
        else if (rounds > 1 && p2SizeOfHand == 0)
        {
            Debug.Log("game over P1 Wins");
            // Time.timeScale = 0;
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
        else if (remainingNoPlayers > 1)
        {
  
            game();
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {

              Destroy(GameObject.Find("p1MainCard"));
              Destroy(GameObject.Find("p2MainCard"));
;
            Destroy(GameObject.Find("P1ParentCard"));
            Destroy(GameObject.Find("P2ParentCard"));
 
            Destroy(GameObject.Find("P2ParentCard"));
            Destroy(GameObject.Find("P1imageSpriteInstance"));
            Destroy(GameObject.Find("P1SpriteParent"));
            Destroy(GameObject.Find("P2imageSpriteInstance"));
            Destroy(GameObject.Find("P2SpriteParent"));

            Destroy(GameObject.Find("P1imageBGSpriteInstance"));
            Destroy(GameObject.Find("P1SpriteBG"));
            Destroy(GameObject.Find("P2imageBGSpriteInstance"));
            Destroy(GameObject.Find("P2SpriteBG"));


            roundBegin();

        }

        if (rounds > 1 && p1SizeOfHand == 0)
        {
            Debug.Log("game over P2 Wins");
            // Time.timeScale = 0;
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            //  roundBegin();
            playerHands.player1.Clear();
            playerHands.player2.Clear();
        }
        else if (rounds > 1 && p2SizeOfHand == 0)
        {
            Debug.Log("game over P1 Wins");
            // Time.timeScale = 0;
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            playerHands.player1.Clear();
            playerHands.player2.Clear();
        }



    }

    //*FUNCTIONS*//

    void game()
    {






        roundBegin();

        return;
    }


    void roundBegin()
    {

        Debug.Log("Round " + rounds);

        //  Debug.Log("p1SizeOfHand" + p1SizeOfHand);
        //   Debug.Log("p2SizeOfHand" + p2SizeOfHand);

  


        ChooseWhosTurn();

        Debug.Log("Player" + attacker +"turn");



        //Pick Random Card
        p1pickCard();

        P1mainCard = new GameObject();
        P1mainCard.name = "p1MainCard";
       // P1mainCard.transform.parent = playerInstance01.transform;
        P1mainCard.AddComponent<loadPlayer1Card>();

      //  ActivePlayer = 2;


        //Pick Random Card
        p2pickCard();

        P2mainCard = new GameObject();
        P2mainCard.name = "p2MainCard";
     //   P2mainCard.transform.parent = playerInstance02.transform;
        P2mainCard.AddComponent<loadPlayer2Card>();

        pickAttribute();
        P1mainCard.AddComponent<compare>();

        //attacker pick value







        //determine result


        //round consequences






        rounds++;
        return;

      
        

 


        //end round
    }


    //Create player ID
    /*
    void createID()
    {
        for (int x = 0; x <= noOfPlayers; x++) //if x(current players) is less than number of players, current players ++
        {
            int ID;

            //create playerID
            for (y = y; y <= noOfPlayers; y++)
            {
                ID = y;
                IDs.Add(ID);
                playersInGame.Add(ID);
            }
        }
    }
    */

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
        int cards = totalCards / noOfPlayers;
        int remainder = totalCards - (cards * noOfPlayers);

        for (int x = 0; x < noOfPlayers; x++)
        {
            if (remainder > 0)
            {
                cards++;
                remainder--;
                cardsInHand.Add(cards);
                cards--;
            }
            else
            {
                cards = totalCards / noOfPlayers;
                cardsInHand.Add(cards);
            }
        }
    }



    //Deal cards to each player one at a time
    void dealCards()
    {
        int cardsToDeal = totalCards; //gets the amount of cards available for dealing set in controller.cs
        int c = 1;  //set starting amount of cards already dealt, updated ++ after each card is given

        for (c = c; c < cardsToDeal;) //loops through the amount of cards left to deal
        {



            for (int x = 1; x <= noOfPlayers; x++) //loops through the number of players so a card can be dealt to each
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

    void ChooseWhosTurn()
    {

        if (winner == 0)
        {
            attacker = 1;
            defender = attacker + 1;
            ActiveplayerInstance = playerInstance01;
        }
        else
        {
            attacker = winner;
            defender = attacker + 1;
            ActiveplayerInstance = playerInstance02;
        }
    }

    void OnMouseDown()
    {

        Debug.Log("clicked");

    }

    void playerOut()
    {

    }

    void p1pickCard()
    {

        int pickedCard;

        p1SizeOfHand = playerHands.player1.Count;   /*count how many cards player has*/

        if (rounds == 1) /* If its the first round of the game select a random card to start with */
        {
            
            arrayListNum = Random.Range(0, p1SizeOfHand); /* Randomly select an array slot to choose which card to select from the players hand */           
            pickedCard = playerHands.player1[arrayListNum]; /* obtains the cards ID held in the picked array slot arrayListnum and stores to pickedCard */
            p1ActiveCard = pickedCard; /* stores the picked card ID to global int p1ActiveCard */
            ActiveCard = pickedCard; /* stores the picked card ID to global int p1ActiveCard */

        }
        else /* otherwise select the next card in the players hand */
        {
            if (arrayListNum > p1SizeOfHand - 2)  /* if the selected array slot number is higher than available array slots... */  /*CHECK MEEE*/
            {

                arrayListNum = 0; /* reset selected array slot to the beginning of the array */
                pickedCard = playerHands.player1[arrayListNum];  /* obtains the cards ID held in the picked array slot arrayListnum and stores to pickedCard */
                p1ActiveCard = pickedCard; /* stores the picked card ID to global int p1ActiveCard */
                ActiveCard = pickedCard; /* stores the picked card ID to global int p1ActiveCard */
                arrayListNum++; /* move to the next card in the array */

            }
            else /* otherwise the selected array slot is within the players available cards */
            {

                arrayListNum++; /* move to the next card in the array */
                pickedCard = playerHands.player1[arrayListNum]; /* obtains the cards ID held in the picked array slot arrayListnum and stores to pickedCard */

                p1ActiveCard = pickedCard; /* stores the picked card ID to global int p1ActiveCard */
                ActiveCard = pickedCard; /* stores the picked card ID to global int p1ActiveCard */
            }
        }
    }


    void p2pickCard()
    {

        
        int pickedCard;

        //count how many cards player has
        p2SizeOfHand = playerHands.player2.Count;


        if (rounds == 1)
        {
            //pick random num
            arrayListNum = Random.Range(0, p2SizeOfHand);


            //reveal value of random num from list
            pickedCard = playerHands.player2[arrayListNum];

            p2ActiveCard = pickedCard;
            ActiveCard = pickedCard; /* stores the picked card ID to global int p1ActiveCard */
        }
        else
        {
            if (arrayListNum > p2SizeOfHand - 2)
            {
                arrayListNum = 0;

                //reveal value of random num from list
                pickedCard = playerHands.player2[arrayListNum];

                p2ActiveCard = pickedCard;
                ActiveCard = pickedCard; /* stores the picked card ID to global int p1ActiveCard */
                arrayListNum++;

            }
            else
            {
                arrayListNum++;

                //reveal value of random num from list
                pickedCard = playerHands.player2[arrayListNum];

                p2ActiveCard = pickedCard;
                ActiveCard = pickedCard; /* stores the picked card ID to global int p1ActiveCard */
            }
        }
    }

    void pickAttribute()
    {
        int attrListNum;
        // int noOfattributes = ActiveCards.P1cardAttributes.Length;

     //   Debug.Log("array length" + ActiveCards.P1cardAttributes.Length);

        if (attacker == 1)
        {
            attrListNum = Random.Range(0, 5);
            Debug.Log("P1 picked array slot" + attrListNum);
            //  attrListNum = 2;
            pickedAttribute = attrListNum;
       //     Debug.Log("current attributes" + attrListNum);
        //    Debug.Log("picked attribute" + pickedAttribute);
        }
        else
        {
            attrListNum = Random.Range(0, 5);
            Debug.Log("P2 picked array slot" + attrListNum);
            //   attrListNum = 2;
            pickedAttribute = attrListNum;
      //      Debug.Log("current attributes" + attrListNum);
        }
            
        
    }

  
    void takeCard()
    {

    }

    void gameOver()
    {

    }

}
