using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerInfoBar : MonoBehaviour {

    public Rigidbody2D TextBoxPhysics;

    public RectTransform rectTransform;

    public float gravityScale;

    public Color32 MenuBGcolour = new Color32(0, 0, 0, 255);
    public Color32 GameEnvcolour = new Color32(52, 125, 235, 255);

    public Font arial;

    public int placeInDeck;

    public static GameObject P1Bar;



    // Use this for initialization
    void Start () {

        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        GameObject playerBar = new GameObject(); /* Creates a parent humanPlayer GO */
        playerBar.name = "PlayerBarParent";
        playerBar.transform.SetParent(controller.GameBG.transform);

        playerBar.AddComponent<Canvas>();
        playerBar.AddComponent<CanvasScaler>();
        playerBar.AddComponent<GraphicRaycaster>();

        Canvas canvas1 = controller.GameBG.GetComponent<Canvas>();
        canvas1.renderMode = RenderMode.ScreenSpaceOverlay;




        P1Bar = new GameObject();
        P1Bar.name = "P1Bar";
        Debug.Log("P1 Bar Created");
        P1Bar.transform.SetParent(playerBar.transform);
        P1Bar.AddComponent<Image>();
        P1Bar.AddComponent<Rigidbody2D>();

        Image Background = P1Bar.GetComponent<Image>();
        Background.color = GameEnvcolour;

        TextBoxPhysics = P1Bar.GetComponent<Rigidbody2D>();
        TextBoxPhysics.gravityScale = 0;

        rectTransform = P1Bar.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -410, 0);
        rectTransform.sizeDelta = new Vector2(640, 141);


        GameObject playerName = new GameObject();
        playerName.name = "HUMANPLAYERNAME";
        playerName.transform.SetParent(P1Bar.transform);
        playerName.AddComponent<Text>();
        playerName.AddComponent<Canvas>();

        Text playerNameText = playerName.GetComponent<Text>();
        playerNameText.font = arial;
        playerNameText.text = controller.Player1Name;
        playerNameText.fontSize = 30;
        playerNameText.color = Color.black;
        playerNameText.alignment = TextAnchor.MiddleCenter;

        rectTransform = playerNameText.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-240, 40, 0);
        rectTransform.sizeDelta = new Vector2(150, 50);


        findPlaceInDeck();

        GameObject noCardsInHandTitle = new GameObject();
        noCardsInHandTitle.name = "noCardsInHandTitle";
        noCardsInHandTitle.transform.SetParent(playerInfoBar.P1Bar.transform);
        noCardsInHandTitle.AddComponent<Text>();
        noCardsInHandTitle.AddComponent<Canvas>();

        Text noCardsInHandTitleText = noCardsInHandTitle.GetComponent<Text>();
        noCardsInHandTitleText.font = arial;
        
        noCardsInHandTitleText.text = "Cards In Hand";
        noCardsInHandTitleText.fontSize = 20;
        noCardsInHandTitleText.color = Color.black;
        noCardsInHandTitleText.alignment = TextAnchor.MiddleCenter;

        rectTransform = noCardsInHandTitleText.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-102, 40, 0);
        rectTransform.sizeDelta = new Vector2(222, 50);

        GameObject noCardsInHand = new GameObject();
        noCardsInHand.name = "no cards in hand";
        noCardsInHand.transform.SetParent(playerInfoBar.P1Bar.transform);
        noCardsInHand.AddComponent<Text>();
        noCardsInHand.AddComponent<Canvas>();

        Text noCardsLeft = noCardsInHand.GetComponent<Text>();
        noCardsLeft.font = arial;
        noCardsLeft.text = (controller.p1SizeOfHand.ToString());
        noCardsLeft.fontSize = 30;
        noCardsLeft.color = Color.black;
        noCardsLeft.alignment = TextAnchor.MiddleCenter;

        rectTransform = noCardsLeft.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-100, -11, 0);
        rectTransform.sizeDelta = new Vector2(80, 50);













        /***PLAYER 2****/

        GameObject P2Bar = new GameObject();
        P2Bar.name = "P2Bar";
        P2Bar.transform.SetParent(playerBar.transform);
        P2Bar.AddComponent<Image>();
        P2Bar.AddComponent<Rigidbody2D>();

        Background = P2Bar.GetComponent<Image>();
        Background.color = GameEnvcolour;

        TextBoxPhysics = P2Bar.GetComponent<Rigidbody2D>();
        TextBoxPhysics.gravityScale = 0;

        rectTransform = P2Bar.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 410, 0);
        rectTransform.sizeDelta = new Vector2(640, 141);
        //      Debug.Log("P2 Bar Created");


 

    }

    // Update is called once per frame
    void Update () {
		
	}

    void findPlaceInDeck()
    {

        for (int x = 0; x < controller.p1SizeOfHand; x++)
        {
            //    Debug.Log(x + "is pos in Array");
            if (playerHands.player1[x] == controller.p1ActiveCard)
            {
                placeInDeck = x + 1;
                //     Debug.Log(placeInDeck + "placeinDeck");
                return;
            }
        }
    }

}
