using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class compare : MonoBehaviour {

    public static Image Background;
    public static Rigidbody2D TextBoxPhysics;
    public static RectTransform rectTransform;

    public Font arial;

    private int fontSize = 18;

    public static GameObject textBoxWin;

    public Color32 winColour = new Color32(3, 252, 40, 255);

    public Text WinText;

    int player1ObtainedValue;
    int player2ObtainedValue;

    public static int sizeofp1hand;
    public static int sizeofp2hand;

    bool draw = false;

    public static GameObject winnerBG;

    // Use this for initialization
    void Start() {

     //   StartCoroutine(waitforKeyDown());

        /* Create a Font object */
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");


        Debug.Log("compareScript started");
        Debug.Log(controller.pickedAttribute);
        Debug.Log("rounds" + controller.rounds);

       // if (controller.rounds == 1)
      //  {
       //     return;
      //  }

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
            draw = false;
            Debug.Log("P1 Wins");
            controller.winner = 1;
           // WinnerGraphic();
            playerHands.player2.Remove(controller.p2ActiveCard);
            playerHands.player1.Add(controller.p2ActiveCard);

            sizeofp1hand = playerHands.player1.Count;
            sizeofp2hand = playerHands.player2.Count;
            Debug.Log("size of p1 hand " + sizeofp1hand);
            Debug.Log("size of p2 hand " + sizeofp2hand);
            controller.p1SizeOfHand = sizeofp1hand;
            controller.p2SizeOfHand = sizeofp2hand;

          //  roundOver = true;
          //  waitforKwyDown();



        }
        else if (player1ObtainedValue < player2ObtainedValue)
        {
            draw = false;
            Debug.Log("P2 Wins");
            controller.winner = 2;
          //  WinnerGraphic();
            playerHands.player1.Remove(controller.p1ActiveCard);
            playerHands.player2.Add(controller.p1ActiveCard);

            sizeofp1hand = playerHands.player1.Count;
            sizeofp2hand = playerHands.player2.Count;
            Debug.Log("size of p1 hand " + sizeofp1hand);
            Debug.Log("size of p2 hand " + sizeofp2hand);
            controller.p1SizeOfHand = sizeofp1hand;
            controller.p2SizeOfHand = sizeofp2hand;

           // roundOver = true;
           // waitforKwyDown();
        }
        else
        {
            Debug.Log("draw");
            draw = true;
          //  roundOver = true;
         //   waitforKwyDown();  //works!!!
        }

        // controller.roundBegin();

        controller.game.AddComponent<roundEnd>();

        //  GameObject winnerBG = new GameObject(); /* Creates a parent humanPlayer GO */


        //  WinnerGraphic();
 
       // controller.confirmRoundOver = true;


    }

    // Update is called once per frame
    void Update() {

   /*     if (Input.GetKeyDown("y"))
        {
            if (roundOver == true) { 

           // Destroy(GameObject.Find("playerWinsGraphic"));
            roundOver = false;
            }

        }

    */



    }
    
    void WinnerGraphic()
    {






    GameObject textBoxWinParent = new GameObject();   
        textBoxWinParent.name = "WinParent";
        textBoxWinParent.AddComponent<Text>();
        textBoxWinParent.AddComponent<Canvas>();   /**/
          textBoxWinParent.AddComponent<CanvasScaler>();      
           textBoxWinParent.AddComponent<GraphicRaycaster>();
           textBoxWinParent.AddComponent<BoxCollider2D>();
           textBoxWinParent.AddComponent<Rigidbody2D>();


           TextBoxPhysics = textBoxWinParent.GetComponent<Rigidbody2D>();
           TextBoxPhysics.gravityScale = 0;

           GameObject Win = (GameObject)Instantiate(textBoxWinParent);
           Win.name = "WinBox";
           Win.transform.SetParent(textBoxWinParent.transform);
          // Win.AddComponent<Text>();

           WinText = Win.GetComponent<Text>();
           if(draw == true)
           {
               WinText.text = "DRAW";
           }
           else
           {
               WinText.text = "Player " + controller.winner + " wins!";
           }

           WinText.fontStyle = FontStyle.Bold;
           WinText.font = arial;
           WinText.fontSize = 70;
           WinText.alignment = TextAnchor.MiddleCenter;
           WinText.color = Color.white;

           Canvas canvas1 = textBoxWinParent.GetComponent<Canvas>();
           canvas1.renderMode = RenderMode.ScreenSpaceOverlay;


           // Provide Text position and size using RectTransform.
           rectTransform = WinText.GetComponent<RectTransform>();
           rectTransform.localPosition = new Vector3(0, 0, 10);
           rectTransform.sizeDelta = new Vector2(500, 300);

       }



    //   IEnumerator waitforKeyDown()
  // {
   //        while (!Input.GetKeyDown("y"))
   //        {
   //            yield return null;
  //         }


          //  controller.roundBegin();
  //         Debug.Log("playersReady3");
  //     }

   }
