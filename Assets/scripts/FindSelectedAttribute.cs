using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// pointerPress example.
// Note that an image was added to a Canvas->Image.  This Image has the
// following script added.  OnPointerUp is called when the texture is
// clicked and released.





public class FindSelectedAttribute : MonoBehaviour, IPointerUpHandler
{

    public static Image Background;
    public static Rigidbody2D TextBoxPhysics;
    public static RectTransform rectTransform;

    public Font arial;

    private int fontSize = 18;

   // public static GameObject textBoxWin;

    public Color32 winColour = new Color32(0, 0, 000, 255);

    public Text WinText;

    bool draw = false;






        // The mouse was released from the GameObject.
        public void OnPointerUp(PointerEventData eventData)
    {
       // loadPlayer1Card.attributesBoxColour = 3;
        StartCoroutine(waitforKwyDown());
        //  loadPlayer1Card.attributesBoxColour = 0;
  
       // Text clickValue = eventData.pointerPress.GetComponent<Text>();
       // clickValue.text = loadPlayer1Card.appearancesTitle;

        if (eventData.pointerPress.name == "AppearancesText")
        {
            controller.pickedAttribute = 0;
     
        }else if (eventData.pointerPress.name == "GoalsText")
        {
            controller.pickedAttribute = 1;
        }
        else if (eventData.pointerPress.name == "AssistsText")
        {
            controller.pickedAttribute = 2;
        }
        else if (eventData.pointerPress.name == "TeamsText")
        {
            controller.pickedAttribute = 3;
        }
        else if (eventData.pointerPress.name == "PremsText")
        {
            controller.pickedAttribute = 4;
        }
        else if (eventData.pointerPress.name == "BookingsText")
        {
            controller.pickedAttribute = 5;
        }


        //  controller.P1mainCard.AddComponent<compare>();

        Destroy(GameObject.Find("update bars2"));
        Destroy(GameObject.Find("ChosenAttr"));
        Destroy(GameObject.Find("ChosenValue"));
       Destroy(GameObject.Find("no cards in hand"));
        Destroy(GameObject.Find("placeInDeck"));
        GameObject updateBars2 = new GameObject();
        updateBars2.name = "update bars2";
        updateBars2.AddComponent<playerInfoValues>();


        // WinnerGraphic();
        
    //controller.P1mainCard.AddComponent<compare>();
   // waitforKwyDown();



       

        Debug.Log(eventData.pointerPress + "was clicked");
        controller.attPicked = true;
        //  Debug.Log(loadPlayer1Card.attributesBoxColour + "ColourValue");
    }
    

    IEnumerator waitforKwyDown()
    {
        while (!Input.GetKeyDown("y"))
        {
       
            
            yield return null;
            
           
        }
 
        controller newRound = FindObjectOfType<controller>();
        newRound.game();
        //  controller.roundBegin();
        Debug.Log("playersReady3");
    }


    void destroyObjects()
    {
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

/*    void WinnerGraphic()
    {

        GameObject textBoxWinParent = new GameObject();
        textBoxWinParent.name = "WinParent";
        textBoxWinParent.AddComponent<Text>();
        textBoxWinParent.AddComponent<Canvas>();   
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
        if (draw == true)
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

    } */

/*

    void WinnerGraphic()
    {



        compare.winnerBG.name = "winnerBGParent";
        compare.winnerBG.transform.SetParent(controller.GameBG.transform);

        compare.winnerBG.AddComponent<Canvas>();
        compare.winnerBG.AddComponent<CanvasScaler>();
        compare.winnerBG.AddComponent<GraphicRaycaster>();

        Canvas canvas1 = controller.GameBG.GetComponent<Canvas>();
        canvas1.renderMode = RenderMode.ScreenSpaceOverlay;




        textBoxWin = new GameObject();
        textBoxWin.name = "textBoxWin";
        Debug.Log("P1 Bar Created");
        textBoxWin.transform.SetParent(compare.winnerBG.transform);
        textBoxWin.AddComponent<Image>();
        textBoxWin.AddComponent<Rigidbody2D>();

        Image Background = textBoxWin.GetComponent<Image>();
        Background.color = winColour;

        TextBoxPhysics = textBoxWin.GetComponent<Rigidbody2D>();
        TextBoxPhysics.gravityScale = 0;

        rectTransform = textBoxWin.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(319, 473, 10);
        rectTransform.sizeDelta = new Vector2(500, 300);


        GameObject WinTextGO = new GameObject();
        WinTextGO.name = "HUMANWinTextGO";
        WinTextGO.transform.SetParent(textBoxWin.transform);
        WinTextGO.AddComponent<Text>();
        WinTextGO.AddComponent<Canvas>();

        WinText = WinTextGO.GetComponent<Text>();

     

        if (draw == true)
        {
            WinText.text = "DRAW";
        }
        else
        {
            WinText.text = "Player " + controller.winner + " wins!";
        }
        WinText.font = arial;
       // WinText.text = controller.Player1Name;
        WinText.fontSize = 30;
        WinText.color = Color.white;
        WinText.alignment = TextAnchor.MiddleCenter;

        rectTransform = WinText.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 0);
        rectTransform.sizeDelta = new Vector2(1000, 1000);
    }*/




}