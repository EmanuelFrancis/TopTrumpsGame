using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerInfoValues : MonoBehaviour {

    public Rigidbody2D TextBoxPhysics;

    public RectTransform rectTransform;

    public float gravityScale;

    public Color32 MenuBGcolour = new Color32(0, 0, 0, 255);
    public Color32 GameEnvcolour = new Color32(52, 125, 235, 255);

    public Font arial;

    public int placeInDeck;

    // Use this for initialization
    void Start () {

        Debug.Log("loadPlayerInfoValuesScript started");

        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        //   Canvas canvas1 = controller.GameBG.GetComponent<Canvas>();
        //   canvas1.renderMode = RenderMode.ScreenSpaceOverlay;

        findPlaceInDeck();

        Destroy(GameObject.Find("no cards in hand"));

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

        GameObject placeInDeckTitle = new GameObject();
        placeInDeckTitle.name = "placeInDeckTitle";
        placeInDeckTitle.transform.SetParent(playerInfoBar.P1Bar.transform);
        placeInDeckTitle.AddComponent<Text>();
        placeInDeckTitle.AddComponent<Canvas>();

        Text placeInDeckTitleText = placeInDeckTitle.GetComponent<Text>();
        placeInDeckTitleText.font = arial;
        findPlaceInDeck();
        placeInDeckTitleText.text = "card pos in deck";
        placeInDeckTitleText.fontSize = 20;
        placeInDeckTitleText.color = Color.black;
        placeInDeckTitleText.alignment = TextAnchor.MiddleCenter;

        rectTransform = placeInDeckTitleText.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(32, 40, 0);
        rectTransform.sizeDelta = new Vector2(222, 50);


        GameObject PlaceInDeck = new GameObject();
        PlaceInDeck.name = "placeInDeck";
        PlaceInDeck.transform.SetParent(playerInfoBar.P1Bar.transform);
        PlaceInDeck.AddComponent<Text>();
        PlaceInDeck.AddComponent<Canvas>();

        Text placeInDeckText = PlaceInDeck.GetComponent<Text>();
        placeInDeckText.font = arial;
        findPlaceInDeck();
        placeInDeckText.text = (placeInDeck.ToString());
        placeInDeckText.fontSize = 30;
        placeInDeckText.color = Color.black;
        placeInDeckText.alignment = TextAnchor.MiddleCenter;

        rectTransform = placeInDeckText.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(35, -11, 0);
        rectTransform.sizeDelta = new Vector2(80, 50);


        GameObject ChosenAttr = new GameObject();
        ChosenAttr.name = "ChosenAttr";
        ChosenAttr.transform.SetParent(playerInfoBar.P1Bar.transform);
        ChosenAttr.AddComponent<Text>();
        ChosenAttr.AddComponent<Canvas>();

        Text ChosenAttrText = ChosenAttr.GetComponent<Text>();
        ChosenAttrText.font = arial;
        findPlaceInDeck();
        ChosenAttrText.text = ActiveCards.AttributesNames[controller.pickedAttribute];
        ChosenAttrText.fontSize = 30;
        ChosenAttrText.color = Color.black;
        ChosenAttrText.alignment = TextAnchor.MiddleRight;

        rectTransform = ChosenAttrText.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(207, 40, 0);
        rectTransform.sizeDelta = new Vector2(222, 50);


        GameObject ChosenValue = new GameObject();
        ChosenValue.name = "ChosenValue";
        ChosenValue.transform.SetParent(playerInfoBar.P1Bar.transform);
        ChosenValue.AddComponent<Text>();
        ChosenValue.AddComponent<Canvas>();

        Text ChosenValueText = ChosenValue.GetComponent<Text>();
        ChosenValueText.font = arial;
        findPlaceInDeck();
        ChosenValueText.text = (ActiveCards.P1cardAttributes[controller.pickedAttribute].ToString());
        ChosenValueText.fontSize = 30;
        ChosenValueText.color = Color.black;
        ChosenValueText.alignment = TextAnchor.MiddleRight;

        rectTransform = ChosenValueText.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(277, -11, 0);
        rectTransform.sizeDelta = new Vector2(80, 50);







    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void findPlaceInDeck()
    {

        for (int x = 0; x < controller.p1SizeOfHand; x++) {
        //    Debug.Log(x + "is pos in Array");
            if (playerHands.player1[x] == controller.p1ActiveCard)
            {
                placeInDeck = x+1;
           //     Debug.Log(placeInDeck + "placeinDeck");
                return;
            }
        }
    }
}
