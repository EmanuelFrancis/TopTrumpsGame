using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winnerScreen : MonoBehaviour {

    public static Image Background;
    public static Rigidbody2D TextBoxPhysics;
    public static RectTransform rectTransform;

    public Font arial;

    private int fontSize = 18;

    public static GameObject textBoxWin;

    public Color32 winColour = new Color32(0, 0, 000, 255);

    public Text WinText;

    bool draw = false;

    // Use this for initialization
    void Start () {

        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");


        StartCoroutine(waitforyDown());


        if (controller.p1SizeOfHand == 0 || controller.p2SizeOfHand==0) {

            controller.game.AddComponent<gameOver>();

        }


        GameObject winnerBG = new GameObject();
        winnerBG.name = "winnerBGParent";
        winnerBG.transform.SetParent(controller.GameBG.transform);

        winnerBG.AddComponent<Canvas>();
        winnerBG.AddComponent<CanvasScaler>();
        winnerBG.AddComponent<GraphicRaycaster>();

        Canvas canvas1 = controller.GameBG.GetComponent<Canvas>();
        canvas1.renderMode = RenderMode.ScreenSpaceOverlay;

        GameObject textBoxWin = new GameObject();
        textBoxWin.name = "textBoxWin";
       // Debug.Log("P1 Bar Created");
       textBoxWin.transform.SetParent(winnerBG.transform);
        textBoxWin.AddComponent<Image>();
        textBoxWin.AddComponent<Rigidbody2D>();

        Image Background = textBoxWin.GetComponent<Image>();
        Background.color = winColour;

        TextBoxPhysics = textBoxWin.GetComponent<Rigidbody2D>();
        TextBoxPhysics.gravityScale = 0;

        rectTransform = textBoxWin.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(319, 850, 10);
        rectTransform.sizeDelta = new Vector2(500, 200);


        GameObject WinTextGO = new GameObject();
        WinTextGO.name = "HUMANWinTextGO";
        WinTextGO.transform.SetParent(textBoxWin.transform);
        WinTextGO.AddComponent<Text>();
        WinTextGO.AddComponent<Canvas>();

        WinText = WinTextGO.GetComponent<Text>();
        Text WinText2 = WinTextGO.GetComponent<Text>();

        // controller.P1mainCard.AddComponent<compare>();

        if (draw == true)
        {
            WinText.text = "DRAW";
        }
        else
        {

           // Text playerName = WinTextGO.GetComponent<Text>();
            string playerName = loadPlayer1Card.PlayerName;


            WinText.text = "Player " + controller.winner + " wins!";

            GameObject ChosenAttr = new GameObject();
            ChosenAttr.name = "ChosenAttr";
            ChosenAttr.transform.SetParent(textBoxWin.transform);
            ChosenAttr.AddComponent<Text>();
            ChosenAttr.AddComponent<Canvas>();

            Text ChosenAttrText = ChosenAttr.GetComponent<Text>();
            ChosenAttrText.font = arial;
           // findPlaceInDeck();
            ChosenAttrText.text = "P 1  " + loadPlayer1Card.PlayerName + ActiveCards.AttributesNames[controller.pickedAttribute];
            ChosenAttrText.fontSize = 30;
            ChosenAttrText.color = Color.white;
            ChosenAttrText.alignment = TextAnchor.MiddleLeft;

            rectTransform = ChosenAttrText.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(-7, 70, 0);
            rectTransform.sizeDelta = new Vector2(488, 50);


            GameObject ChosenValue = new GameObject();
            ChosenValue.name = "ChosenValue";
            ChosenValue.transform.SetParent(textBoxWin.transform);
            ChosenValue.AddComponent<Text>();
            ChosenValue.AddComponent<Canvas>();

            Text ChosenValueText = ChosenValue.GetComponent<Text>();
            ChosenValueText.font = arial;
           // findPlaceInDeck();
            ChosenValueText.text = (ActiveCards.P1cardAttributes[controller.pickedAttribute].ToString());
            ChosenValueText.fontSize = 30;
            ChosenValueText.color = Color.white;
            ChosenValueText.alignment = TextAnchor.MiddleRight;

            rectTransform = ChosenValueText.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(206, 20, 0);
            rectTransform.sizeDelta = new Vector2(80, 50);





            GameObject Chosen2Attr = new GameObject();
            Chosen2Attr.name = "Chosen2Attr";
            Chosen2Attr.transform.SetParent(textBoxWin.transform);
            Chosen2Attr.AddComponent<Text>();
            Chosen2Attr.AddComponent<Canvas>();

            Text Chosen2AttrText = Chosen2Attr.GetComponent<Text>();
            Chosen2AttrText.font = arial;
            // findPlaceInDeck();
            Chosen2AttrText.text = "P 2  " + loadPlayer2Card.PlayerName + ActiveCards.AttributesNames[controller.pickedAttribute];
            Chosen2AttrText.fontSize = 30;
            Chosen2AttrText.color = Color.white;
            Chosen2AttrText.alignment = TextAnchor.MiddleLeft;

            rectTransform = Chosen2AttrText.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(-7, -70, 0);
            rectTransform.sizeDelta = new Vector2(488, 50);


            GameObject Chosen2Value = new GameObject();
            Chosen2Value.name = "Chosen2Value";
            Chosen2Value.transform.SetParent(textBoxWin.transform);
            Chosen2Value.AddComponent<Text>();
            Chosen2Value.AddComponent<Canvas>();

            Text Chosen2ValueText = Chosen2Value.GetComponent<Text>();
            Chosen2ValueText.font = arial;
            // findPlaceInDeck();
            Chosen2ValueText.text = (ActiveCards.P2cardAttributes[controller.pickedAttribute].ToString());
            Chosen2ValueText.fontSize = 30;
            Chosen2ValueText.color = Color.white;
            Chosen2ValueText.alignment = TextAnchor.MiddleRight;

            rectTransform = Chosen2ValueText.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(206, -26, 0);
            rectTransform.sizeDelta = new Vector2(80, 50);


        }
        WinText.font = arial;
        // WinText.text = controller.Player1Name;
        WinText.fontSize = 30;
        WinText.color = Color.white;
        WinText.alignment = TextAnchor.MiddleCenter;

        rectTransform = WinText.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 0);
        rectTransform.sizeDelta = new Vector2(1000, 1000);

        //  controller.rounds++;

        waitforyDown();
}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator waitforyDown()
    {
        while (!Input.GetMouseButtonDown(0))
        {
            //     Debug.Log("null");

            yield return null;


        }

        //   controller newRound = FindObjectOfType<controller>();
        // newRound.game();
        //  controller.roundBegin();
        Destroy(controller.game.GetComponent<game>());
        destroyObjects();
        controller.game.AddComponent<game>();

        Destroy(GameObject.Find("winnerBGParent"));
        Destroy(GameObject.Find("textBoxWin"));
        Destroy(GameObject.Find("HUMANWinTextGO"));
        Destroy(GameObject.Find("ChosenAttr"));
        Destroy(GameObject.Find("ChosenValue"));
             Destroy(GameObject.Find("Chosen2Attr"));
            Destroy(GameObject.Find("Chosen2Value"));
      //  Debug.Log("playersReady3"); 


    }


    void destroyObjects()
    {
           Destroy(GameObject.Find("update bars2"));
          //   Destroy(GameObject.Find("ChosenAttr"));
         //   Destroy(GameObject.Find("ChosenValue"));
          //   Destroy(GameObject.Find("Chosen2Attr"));
        //    Destroy(GameObject.Find("Chosen2Value"));
       //   Destroy(GameObject.Find("no cards in hand"));
           Destroy(GameObject.Find("placeInDeck"));
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
            Destroy(GameObject.Find("P1imageBGSpriteInstance"));
             Destroy(GameObject.Find("P1SpriteBG"));
            Destroy(GameObject.Find("P2imageBGSpriteInstance"));
            Destroy(GameObject.Find("P2SpriteBG"));

        //     Destroy(GameObject.Find("p1MainCard"));
        //     Destroy(GameObject.Find("p2MainCard"));

        //    Destroy(GameObject.Find("winnerBGParent"));
        //    Destroy(GameObject.Find("textBoxWin"));
        //   Destroy(GameObject.Find("HUMANWinTextGO"));

        //  Destroy(GameObject.Find("P1Bar"));
        //  Destroy(GameObject.Find("P2Bar"));
        //   Destroy(GameObject.Find("PlayerBarParent"));
       //    Destroy(GameObject.Find("HUMANPLAYERNAME"));
        Destroy(GameObject.Find("HUMANroundNo"));
        Destroy(GameObject.Find("popupMenu"));


    }


}
