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
   // public static int rounds = 1;

    RectTransform rectTransform;

    public static GameObject humanPlayer; /* Define parent human player GameObject */
    public GameObject activeCard; /* Hold ID of the current card in play */

    public GameObject popup;
    public static GameObject GameBG;

    //** is set by pickAttribute() method to randomly pick a card attribute for comparison in compare.cs **//
    public static int pickedAttribute;

    public static GameObject textBoxChooseAtt;
    public Text textBoxChooseAttText;

    bool draw = false;

    public static GameObject ActiveplayerInstance;
    public static GameObject playerInstance01;
    public static GameObject playerInstance02;

    public GameObject player1sActiveCard;
    public GameObject player2sActiveCard;

    public GameObject Player1;

    //Declare Lists(Arrays) that will store the parameter values to be obtained when needed
    List<int> IDs = new List<int>();
    List<int> cardsInHand = new List<int>();
    List<string> names = new List<string>();

    public static Font arial;
    public static Rigidbody2D TextBoxPhysics;

    public static string Player1Name = "Player1";
    public static string Player2Name = "Player2";

    public static List<string> playersInGame = new List<string>(); /* Holds the names of instanced players */
    public static List<string> eliminatedPlayers = new List<string>();

    public static int gameWinner = 0;
    public static int rounds = 1;

    public static int winner = 0;
    public static int attacker;
    public static int defender;

    public static int ActivePlayer = 1; /* Ovrall player game is currently reading */
    public static int ActiveCard; /* Ovrall card game is currently reading */
    public static int p1ActiveCard; /* Receives the p1 picked card ID from p1pickedCard() */
    public static int p2ActiveCard; /* Receives the p2 picked card ID from p2pickedCard() */
    public static int p1SizeOfHand;
    public static int p2SizeOfHand;

    public static int playersReady = 0;

    public static int arrayListNum = 0; /* Receives and holds the picked array slot for the picked attribute to compare from p1pickedCard() */

    public static GameObject P1mainCard;
    public static GameObject P2mainCard;

    public static GameObject game;

    public static bool confirmRoundOver = false;

    public Color32 winColour = new Color32(3, 252, 40, 255);

    public static bool attPicked = false;


    void Start()
    {

      //  StartCoroutine(waitforKwyDown());

        /* Create a Font object */
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        //  StartCoroutine(timeWait());

        //   GameObject StartMenu = new GameObject();
        //   StartMenu.name = "Start Menu";
        //   StartMenu.AddComponent<startMenu>();

        assignCards(); /* calls method to deal cards evenly between the players in game */

        //  popup = new GameObject(); /* Creates a parent humanPlayer GO */
        //   popup.name = "PopupGO";  /* Names the parent humanPlayer GO */
        //    popup.AddComponent<Canvas>();
        //    popup.AddComponent<CanvasScaler>();
        //    popup.AddComponent<GraphicRaycaster>();
        //  popup.AddComponent<playerInfoBar>();



        game = new GameObject();

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


        createInfoBars();
        game.AddComponent<game>();
      //  game();


    } 

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {

         //   P1mainCard.AddComponent<compare>();

            Destroy(GameObject.Find("ChosenAttr"));
            Destroy(GameObject.Find("ChosenValue"));
            Destroy(GameObject.Find("no cards in hand"));
            Destroy(GameObject.Find("placeInDeck"));
            Destroy(GameObject.Find("WinParent"));
            Destroy(GameObject.Find("WinBox"));
            Destroy(GameObject.Find("p1MainCard"));
            Destroy(GameObject.Find("p2MainCard"));
            
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
        }

  //      if(attPicked == true)
  //      {
  //          attPicked = false;
  //          P1mainCard.AddComponent<compare>();
  //          Debug.Log("winner player" + controller.winner);
  //          P1mainCard.AddComponent<winnerScreen>();
            //  waitforKwyDown2();
        //    rounds++;
//
 //           controller newRound = FindObjectOfType<controller>();
  //          newRound.game();

  //      }

    }

    //*FUNCTIONS*//
/*
 public   void game()
    {
        Debug.Log("gameMethod started");

        rounds = 1;

  

        dealCards();
        GameObject updateBars = new GameObject();
        updateBars.name = "update bars";
        updateBars.GetComponent<playerInfoValues>();

       
        for(int x = gameWinner; x == 0; x++)
                {               
                    Debug.Log("game winner " + winner);
                    roundBegin();
                    rounds++;        
                }
        
        Debug.Log("gameMethod end");
    }
*/
/*
   public void roundBegin()
    {

        if (rounds>1)
        {
            destroyObjects();
        }

        Debug.Log("roundBeginMethod started");

        p1SizeOfHand = playerHands.player1.Count;
        p2SizeOfHand = playerHands.player2.Count;


        Debug.Log("p1 hand " + p1SizeOfHand);
        Debug.Log("p2 hand " + p2SizeOfHand);

        if (p1SizeOfHand == 0)
        {
            gameWinner = 2;
        }
        else if (p2SizeOfHand == 0)
        {
            gameWinner = 1;
        }
        else
        {
            ChooseWhosTurn();

            Debug.Log("Player" + attacker + "turn");

                     p1pickCard();

                     P1mainCard = new GameObject();
                     P1mainCard.name = "p1MainCard";
                     P1mainCard.AddComponent<loadPlayer1Card>();

                     p2pickCard();

                     P2mainCard = new GameObject();
                     P2mainCard.name = "p2MainCard";
                     P2mainCard.AddComponent<loadPlayer2Card>();

                     GameObject popupMenu = new GameObject();
                     popupMenu.name = "popupMenu";
                     popupMenu.AddComponent<loadPopup>();

            Debug.Log(attPicked);

          //  if (attPicked == true)
           //          {
          // //              P1mainCard.AddComponent<compare>();
          //           }

                       
               
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



 

    void ChooseWhosTurn()
    {
      //  playersReady = 0;



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
   //     Debug.Log("playersReady1" + playersReady);
     //   playerTurnScreen();
       // playersReady = 0;
   //     timeWait();
   //     Debug.Log("playersReady2" + playersReady);
      //  Destroy(GameObject.Find("PlayerTurnScrnParent"));


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

   //     p1SizeOfHand = playerHands.player1.Count;   /*count how many cards player has*/

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
     //   p2SizeOfHand = playerHands.player2.Count;


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

  //  void pickAttribute()
  //  {
   //     int attrListNum;
        // int noOfattributes = ActiveCards.P1cardAttributes.Length;

     //   Debug.Log("array length" + ActiveCards.P1cardAttributes.Length);

 //       if (attacker == 1)
  //      {
  //          attrListNum = Random.Range(0, 5);
  //          Debug.Log("P1 picked array slot" + attrListNum);
//            //  attrListNum = 2;
 //           pickedAttribute = attrListNum;
       //     Debug.Log("current attributes" + attrListNum);
        //    Debug.Log("picked attribute" + pickedAttribute);
   //     }
  //      else
  //      {
 //           attrListNum = Random.Range(0, 5);
 //           Debug.Log("P2 picked array slot" + attrListNum);
            //   attrListNum = 2;
  //          pickedAttribute = attrListNum;
      //      Debug.Log("current attributes" + attrListNum);
   //     }
            
        
 //   }

  
    void takeCard()
    {

    }

    void gameOverCheck()
    {
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
    }

    void playerTurnScreen()
    {


        GameObject PlayerTurnScrnParent = new GameObject();
        PlayerTurnScrnParent.name = "PlayerTurnScrnParent";
        PlayerTurnScrnParent.AddComponent<Text>();
        PlayerTurnScrnParent.AddComponent<Canvas>();   /**/
        PlayerTurnScrnParent.AddComponent<CanvasScaler>();
        PlayerTurnScrnParent.AddComponent<GraphicRaycaster>();
        PlayerTurnScrnParent.AddComponent<BoxCollider2D>();
        PlayerTurnScrnParent.AddComponent<Rigidbody2D>();


        TextBoxPhysics = PlayerTurnScrnParent.GetComponent<Rigidbody2D>();
        TextBoxPhysics.gravityScale = 0;

        GameObject PlayerTurnScrn = (GameObject)Instantiate(PlayerTurnScrnParent);
        PlayerTurnScrn.name = "PlayerTurnScrn";
        PlayerTurnScrn.transform.SetParent(PlayerTurnScrnParent.transform);
      //  PlayerTurnScrn.AddComponent<Text>();

        Text PlayerTurnScrnText = PlayerTurnScrn.GetComponent<Text>();
        PlayerTurnScrnText.text = "Player " + attacker + " Turn";
        PlayerTurnScrnText.fontStyle = FontStyle.Bold;
        PlayerTurnScrnText.font = arial;
        PlayerTurnScrnText.fontSize = 70;
        PlayerTurnScrnText.alignment = TextAnchor.MiddleCenter;
        PlayerTurnScrnText.color = Color.white;

        Canvas canvas1 = PlayerTurnScrnParent.GetComponent<Canvas>();
        canvas1.renderMode = RenderMode.ScreenSpaceOverlay;


        // Provide Text position and size using RectTransform.
        rectTransform = PlayerTurnScrnText.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 10);
        rectTransform.sizeDelta = new Vector2(500, 300);

       // return;
    }

  //  IEnumerator timeWait()
  //  {
  //      while (!Input.GetKeyDown("y"))
 //       {
 //           yield return null;
 //       }

       // playersReady = 1;
       // roundBegin();
 //       Debug.Log("playersReady3");
//    }

void createCards()
{
        //  if (playersReady == 1)
        //  {
        Debug.Log("oiii");
//        Destroy(GameObject.Find("PlayerTurnScrnParent"));
 //       Destroy(GameObject.Find("PlayerTurnScrn"));
        //Pick Random Card
        p1pickCard();

        P1mainCard = new GameObject();
        P1mainCard.name = "p1MainCard";
    //    Debug.Log("oiiiiiii");
        // P1mainCard.transform.parent = playerInstance01.transform;
        P1mainCard.AddComponent<loadPlayer1Card>();

        //  ActivePlayer = 2;


        //Pick Random Card
        p2pickCard();

        P2mainCard = new GameObject();
        P2mainCard.name = "p2MainCard";
        //   P2mainCard.transform.parent = playerInstance02.transform;
        P2mainCard.AddComponent<loadPlayer2Card>();

          //  pickAttribute();
         //   P1mainCard.AddComponent<compare>();
      

        //  playersReady = 0;
 

   //     rounds++;
       // game();
     //   }
}

    void destroyObjects()
    {
     //   Destroy(GameObject.Find("update bars2"));
   //     Destroy(GameObject.Find("ChosenAttr"));
    //    Destroy(GameObject.Find("ChosenValue"));
   //     Destroy(GameObject.Find("Chosen2Attr"));
    //    Destroy(GameObject.Find("Chosen2Value"));
        //  Destroy(GameObject.Find("no cards in hand"));
        //   Destroy(GameObject.Find("placeInDeck"));
    //    Destroy(GameObject.Find("WinParent"));
    //    Destroy(GameObject.Find("WinBox"));
        Destroy(GameObject.Find("p1MainCard"));
        Destroy(GameObject.Find("p2MainCard"));

        Destroy(GameObject.Find("P1ParentCard"));
        Destroy(GameObject.Find("P2ParentCard"));

   //     Destroy(GameObject.Find("P2ParentCard"));
        Destroy(GameObject.Find("P1imageSpriteInstance"));
        Destroy(GameObject.Find("P1SpriteParent"));
        Destroy(GameObject.Find("P2imageSpriteInstance"));
        Destroy(GameObject.Find("P2SpriteParent"));
//
    //    Destroy(GameObject.Find("P1imageBGSpriteInstance"));
   //     Destroy(GameObject.Find("P1SpriteBG"));
    //    Destroy(GameObject.Find("P2imageBGSpriteInstance"));
    //    Destroy(GameObject.Find("P2SpriteBG"));

   //     Destroy(GameObject.Find("p1MainCard"));
   //     Destroy(GameObject.Find("p2MainCard"));

    //    Destroy(GameObject.Find("winnerBGParent"));
    //    Destroy(GameObject.Find("textBoxWin"));
     //   Destroy(GameObject.Find("HUMANWinTextGO"));

      //  Destroy(GameObject.Find("P1Bar"));
      //  Destroy(GameObject.Find("P2Bar"));
     //   Destroy(GameObject.Find("PlayerBarParent"));
     //   Destroy(GameObject.Find("HUMANPLAYERNAME"));


    }

    void createInfoBars()
    {
        GameBG = new GameObject(); /* Creates a parent humanPlayer GO */
        GameBG.name = "PlayerBarGO";  /* Names the parent humanPlayer GO */
        GameBG.AddComponent<Canvas>();
        GameBG.AddComponent<CanvasScaler>();
        GameBG.AddComponent<GraphicRaycaster>();
        GameBG.AddComponent<playerInfoBar>();
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

    IEnumerator waitforKwyDown2()
    {
        while (!Input.GetKeyDown("u"))
        {


            yield return null;


        }

        controller newRound = FindObjectOfType<controller>();
      //  newRound.game();
       
        Debug.Log("roundOver");


    }





}
