﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine.UI;
using UnityEngine;
using System;

public class loadPlayer1Card : MonoBehaviour
{

    public TextAsset xmlRawFile;  //Declare xml file
    public Text playerName;  //Declare
    public Text Appearances;
    public Image Background;
    string changeMeToInt;
    int IntValue;

    //** holds int version of converted string xmlread value **//
    public static int AppearancesInt;
    public static int GoalsInt;
    public static int AssistsInt;
    public static int TeamsInt;
    public static int PremsInt;
    public static int BookingsInt;

    public static int AppearancesValue;

    //** Public value that gets changed by scripts hoverEvent & FindSelectedAttribute to set the attribute box background colour **//
    public static int attributesBoxColour = 0;

    //** Create attribute box state colours **//
    public Color32 hoverColour = new Color32(255, 222, 130, 255);
    public Color32 transparent = new Color32(0, 0, 0, 0);
    public Color32 clickedColour = new Color32(3, 252, 40, 255);


    //** Declare Rigidbody2d for images **//
    Rigidbody2D TextBoxPhysics;

    //** Hold Gravity Value **//
    public float gravityScale;

    private int fontSize = 18;



    //** Receives and holds the current p1 card id **/
    int SelectedCardId = controller.p1ActiveCard;


    //*** Declare a string version of current p1 id *//
    public static string SelectCardId;



    // Use this for initialization
    void Start()
    {

   //     controller.ActivePlayer = 1;

        RectTransform rectTransform;   /* Create a RectTransform to hold position, size, anchor and pivot information for the card elements */
        Font arial;   /* Create a Font object */
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");  /* Set the font type to the font object*/

        XmlDocument doc = new XmlDocument(); /* Create XmlDocument GO called doc */
        doc.Load("Assets/CardsData.xml");    /* load CardsData.xml into doc GO */
        XmlNode root = doc.DocumentElement;  /* Create an XmlNode to set and hold the root element of the xml file <player> */

        XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable); /*Add a namespace to identify this group within the file (necessary)*/
        nsmgr.AddNamespace("default", "urn:newcards-schema"); /* Assign the namespace to match that within the xml (1st input is prefix but not needed in my case) */
        SelectCardId = SelectedCardId.ToString(); //converts current card id to a string
      

        Debug.Log("P1 card in hand Picked " + SelectCardId);
 
        XmlNode node = root.SelectSingleNode("descendant::default:player[default:id='" + SelectCardId + "']", nsmgr); /* selects the correct <player> node by finding a decendent of it that matches the SelectCardId ID */
        XmlNode id = node.FirstChild;
        XmlNode name = id.NextSibling;
        XmlNode apps = name.NextSibling;
        XmlNode goals = apps.NextSibling;
        XmlNode assists = goals.NextSibling;
        XmlNode teams = assists.NextSibling;
        XmlNode prems = teams.NextSibling;
        XmlNode bookings = prems.NextSibling;
        // Debug.Log(name.InnerXml);

        //** Card Parent Game Object **//
        GameObject card = new GameObject();
        card.name = "P1ParentCard";

        //
    //    card.transform.parent = controller.playerInstance01.transform; /**/
        GameObject card01 = (GameObject)Instantiate(card);   /**/
        card01.transform.parent = controller.playerInstance01.transform;   /**/
        card01.name = name.InnerXml;   /**/
     //   card01.transform.parent = card01.transform;   /**/
        card01.AddComponent<Canvas>();   /**/
        card01.AddComponent<CanvasScaler>();   /**/
        card01.AddComponent<GraphicRaycaster>();   /**/


      //  rectTransform = card01.GetComponent<RectTransform>();
     //   rectTransform.localPosition = new Vector3(474, 266, 0);
      //  rectTransform.sizeDelta = new Vector2(948, 533);


        //********************************//
        // Create the Image GameObject
        GameObject ImageBox = new GameObject();
        ImageBox.name = "P1ImageBoxParent";
        ImageBox.transform.parent = card.transform;
        // Instantiate(ImageBox);
        GameObject ImageP1 = (GameObject)Instantiate(ImageBox);

        ImageP1.name = "ImageP1";
        ImageP1.transform.parent = card01.transform;
        ImageP1.AddComponent<Image>(); ;
        ImageP1.AddComponent<GraphicRaycaster>();
        LoadSprite.playerIDInt2 = 1;
        LoadSprite.CardIDInt = SelectedCardId;
        ImageP1.AddComponent<LoadSprite>();

        // Provide Image position and size using RectTransform.
        rectTransform = ImageP1.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-239, 75, 0);
        rectTransform.sizeDelta = new Vector2(350, 223);


        //********************************//
        // Create the Background Image GameObject
        GameObject ImageBackground = new GameObject();
        ImageBackground.name = "ImageBackgroundP1Parent";
        ImageBackground.transform.parent = card.transform;
        // Instantiate(ImageBox);
        GameObject ImageBackgroundP1 = (GameObject)Instantiate(ImageBackground);

        ImageBackgroundP1.name = "ImageBackgroundP1";
        ImageBackgroundP1.transform.parent = card01.transform;
        ImageBackgroundP1.AddComponent<Image>(); ;
        ImageBackgroundP1.AddComponent<GraphicRaycaster>();
        LoadBackground.playerIDInt = 1;
        ImageBackgroundP1.AddComponent<LoadBackground>();

        // Provide Image position and size using RectTransform.
        rectTransform = ImageBackgroundP1.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-239, 5, 0);
        rectTransform.sizeDelta = new Vector2(350, 490);


        GameObject textBoxBGBox = new GameObject();
        textBoxBGBox.name = "TextBoxBGParent";
        textBoxBGBox.transform.parent = ImageBackgroundP1.transform;
        textBoxBGBox.AddComponent<Image>();
        textBoxBGBox.AddComponent<Canvas>();
        textBoxBGBox.AddComponent<CanvasScaler>();
        textBoxBGBox.AddComponent<GraphicRaycaster>();
        textBoxBGBox.AddComponent<BoxCollider2D>();
        textBoxBGBox.AddComponent<Rigidbody2D>();


       // textBoxBGBox.AddComponent<HoverEvent>();
      //  textBoxBGBox.AddComponent<FindSelectedAttribute>();
      //  textBoxBGBox.AddComponent<Button>();

 

        rectTransform = textBoxBGBox.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-60, -60, 0);
        rectTransform.sizeDelta = new Vector2(200, 22);

        TextBoxPhysics = textBoxBGBox.GetComponent<Rigidbody2D>();
        TextBoxPhysics.gravityScale = 0;

        //Create Text Background Image
        GameObject textBoxAppsImage = (GameObject)Instantiate(textBoxBGBox);
        textBoxAppsImage.name = "AppearancesTextImage";
        textBoxAppsImage.transform.parent = ImageBackgroundP1.transform;
        textBoxBGBox.GetComponent<Canvas>();
        textBoxBGBox.GetComponent<CanvasScaler>();
        textBoxBGBox.GetComponent<GraphicRaycaster>();

        TextBoxPhysics = textBoxAppsImage.GetComponent<Rigidbody2D>();
        TextBoxPhysics.gravityScale = 0;

        Background = textBoxBGBox.GetComponent<Image>();
        Background.color = transparent;




        GameObject attributesBox = new GameObject();
        attributesBox.name = "AttributesBoxParent";
        attributesBox.transform.parent = ImageBackgroundP1.transform;
        attributesBox.AddComponent<Text>();
        Appearances = attributesBox.GetComponent<Text>();
        Appearances.fontStyle = FontStyle.Bold;
        Appearances.font = arial;
        Appearances.fontSize = fontSize;
        Appearances.alignment = TextAnchor.MiddleLeft;
        Appearances.color = Color.black;
        attributesBox.AddComponent<BoxCollider2D>();
        attributesBox.AddComponent<Rigidbody2D>();
     //   attributesBox.AddComponent<Timer>();
        attributesBox.AddComponent<HoverEvent>();
        attributesBox.AddComponent<FindSelectedAttribute>();
        attributesBox.AddComponent<Button>();



        TextBoxPhysics = attributesBox.GetComponent<Rigidbody2D>();
        TextBoxPhysics.gravityScale = 0;


        //**PLAYER NAME**//
        // Create the Text GameObject.
        // GameObject textBox = (GameObject)Instantiate(attributesBox);
        GameObject textBox = new GameObject();
        textBox.name = "Player1CardName";
        textBox.transform.parent = card01.transform;
        textBox.AddComponent<Text>();
        textBox.AddComponent<Canvas>();

        // Set Text component properties.
        playerName = textBox.GetComponent<Text>();
        playerName.font = arial;
        playerName.text = name.InnerXml;
        playerName.fontSize = 30;
        playerName.color = Color.black;
        playerName.alignment = TextAnchor.MiddleCenter;

        // Provide Text position and size using RectTransform.             
        rectTransform = playerName.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-239, 215, 0);
        rectTransform.sizeDelta = new Vector2(350, 50);


        //**APPEARANCES**//


       




        // Create the Text GameObject.
        GameObject textBoxApps = (GameObject)Instantiate(attributesBox);
      //  GameObject textBoxApps = new GameObject();
        textBoxApps.name = "AppearancesText";
        textBoxApps.transform.parent = attributesBox.transform;
        Appearances.text = "Appearances: " + apps.InnerXml;

        changeMeToInt = textBoxApps.name;
        AppearancesInt = stringToint(apps.InnerXml);
        ActiveCards.P1cardAttributes[0] = AppearancesInt;



        // Provide Text position and size using RectTransform.
        rectTransform = Appearances.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-55, -60, 1);
        rectTransform.sizeDelta = new Vector2(200, 22);

        //**Button required for FindSelectedAttribute.cs**//
      //  Button textBoxButton;
      //  textBoxApps.AddComponent<Button>();
   //     textBoxButton = textBoxApps.GetComponent<Button>();
  //      textBoxButton.onClick.AddListener(assignToActiveCard);  
 
        //**GOALS**//
        // Create the Text GameObject.
        GameObject textBoxGoals = new GameObject();
        textBoxGoals.name = "GoalsText";
        textBoxGoals.transform.parent = ImageBackgroundP1.transform;
        textBoxGoals.AddComponent<Text>();
        textBoxGoals.AddComponent<BoxCollider2D>();
        textBoxGoals.AddComponent<Rigidbody2D>();

        // Set Text component properties.
        Appearances = textBoxGoals.GetComponent<Text>();
        Appearances.font = arial;
        Appearances.text = "Goals: " + goals.InnerXml;
        Appearances.fontSize = fontSize;
        Appearances.alignment = TextAnchor.MiddleLeft;
        Appearances.color = Color.black;

        changeMeToInt = textBoxGoals.name;
        GoalsInt = stringToint(goals.InnerXml);
        ActiveCards.P1cardAttributes[1] = GoalsInt;

        TextBoxPhysics = textBoxGoals.GetComponent<Rigidbody2D>();
        TextBoxPhysics.gravityScale = 0;

        // Provide Text position and size using RectTransform.
        rectTransform = Appearances.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-55, -90, 0);
        rectTransform.sizeDelta = new Vector2(200, 22);

        //**ASSISTS**//
        // Create the Text GameObject.
        GameObject textBoxAssists = new GameObject();
        textBoxAssists.name = "AssistsText";
        textBoxAssists.transform.parent = ImageBackgroundP1.transform;
        textBoxAssists.AddComponent<Text>();

        // Set Text component properties.
        Appearances = textBoxAssists.GetComponent<Text>();
        Appearances.font = arial;
        Appearances.text = "Assists: " + assists.InnerXml;
        Appearances.fontSize = fontSize;
        Appearances.alignment = TextAnchor.MiddleLeft;
        Appearances.color = Color.black;

        changeMeToInt = textBoxAssists.name;
        AssistsInt = stringToint(assists.InnerXml);
        ActiveCards.P1cardAttributes[2] = AssistsInt;

        // Provide Text position and size using RectTransform.
        rectTransform = Appearances.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-55, -120, 0);
        rectTransform.sizeDelta = new Vector2(200, 22);

        //**TEAMS**//
        // Create the Text GameObject.
        GameObject textBoxTeams = new GameObject();
        textBoxTeams.name = "TeamsText";
        textBoxTeams.transform.parent = ImageBackgroundP1.transform;
        textBoxTeams.AddComponent<Text>();

        // Set Text component properties.
        Appearances = textBoxTeams.GetComponent<Text>();
        Appearances.font = arial;
        Appearances.text = "Teams: " + teams.InnerXml;
        Appearances.fontSize = fontSize;
        Appearances.alignment = TextAnchor.MiddleLeft;
        Appearances.color = Color.black;

        changeMeToInt = textBoxTeams.name;
        TeamsInt = stringToint(teams.InnerXml);
        ActiveCards.P1cardAttributes[3] = TeamsInt;

        // Provide Text position and size using RectTransform.
        rectTransform = Appearances.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-55, -150, 0);
        rectTransform.sizeDelta = new Vector2(200, 22);

        //**PREMS**//
        // Create the Text GameObject.
        GameObject textBoxPrems = new GameObject();
        textBoxPrems.name = "PremsText";
        textBoxPrems.transform.parent = ImageBackgroundP1.transform;
        textBoxPrems.AddComponent<Text>();

        // Set Text component properties.
        Appearances = textBoxPrems.GetComponent<Text>();
        Appearances.font = arial;
        Appearances.text = "Premier Leagues: " + prems.InnerXml;
        Appearances.fontSize = fontSize;
        Appearances.alignment = TextAnchor.MiddleLeft;
        Appearances.color = Color.black;

        changeMeToInt = textBoxPrems.name;
        PremsInt = stringToint(prems.InnerXml);
        ActiveCards.P1cardAttributes[4] = PremsInt;

        // Provide Text position and size using RectTransform.
        rectTransform = Appearances.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-55, -180, 0);
        rectTransform.sizeDelta = new Vector2(200, 22);

        //**BOOKINGS**//
        // Create the Text GameObject.
        GameObject textBoxBookings = new GameObject();
        textBoxBookings.name = "BookingsText";
        textBoxBookings.transform.parent = ImageBackgroundP1.transform;
        textBoxBookings.AddComponent<Text>();

        // Set Text component properties.
        Appearances = textBoxBookings.GetComponent<Text>();
        Appearances.font = arial;
        Appearances.text = "Bookings: " + bookings.InnerXml;
        Appearances.fontSize = fontSize;
        Appearances.alignment = TextAnchor.MiddleLeft;
        Appearances.color = Color.black;

        changeMeToInt = textBoxBookings.name;
        BookingsInt = stringToint(bookings.InnerXml);
        ActiveCards.P1cardAttributes[5] = BookingsInt;

        // Provide Text position and size using RectTransform.
        rectTransform = Appearances.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-55, -210, 0);
        rectTransform.sizeDelta = new Vector2(200, 22);


        //  ActiveCards.P1cardAttributes[0] = AppearancesInt;
        ///  ActiveCards.P1cardAttributes[1] = GoalsInt;
        //  ActiveCards.P1cardAttributes[2] = AssistsInt;
        //   ActiveCards.P1cardAttributes[3] = TeamsInt;
        //  ActiveCards.P1cardAttributes[4] = PremsInt;
        //   ActiveCards.P1cardAttributes[5] = BookingsInt;

       // controller.ActivePlayer = 2;

        //    playerCardClass.playerCard p1Card = new playerCardClass.playerCard(SelectedCardId, textBox.name, AppearancesInt, GoalsInt, AssistsInt, TeamsInt, PremsInt, BookingsInt);

    }



    // Update is called once per frame
    void Update()
    {
     //   float timer = 10;
     //   timer -= Time.deltaTime;


        if (attributesBoxColour == 1)
        {
            Background.color = hoverColour ;
            attributesBoxColour = 0; //reset event so not always returning ==1
            Debug.Log("boxColour =" + attributesBoxColour);

        }
        else if (attributesBoxColour == 2)
        {
            Background.color = transparent;
            attributesBoxColour = 0;  //reset event so not always returning ==2   
            Debug.Log("boxColour =" + attributesBoxColour);
        }
        else if (attributesBoxColour == 3)
        {
            Background.color = clickedColour;
          //  timer -= Time.deltaTime;
      //      attributesBoxColour = 4;  //reset event so not always returning ==2  
            
            Debug.Log("boxColour =" + attributesBoxColour);

        }



    }
 /*   return stringToint(int ){
    // Convert Text number into String
    int.TryParse(apps.InnerXml, out AppearancesInt);
    int Value = AppearancesInt;

        return Value;
    }*/

        int stringToint(string changeMeToInt)
    {
        // Convert Text number into String
        int.TryParse(changeMeToInt, out IntValue);
      //  int IntValue = AppearancesInt;

        return IntValue;
    }

    public void assignToActiveCard()
    {
        Debug.Log("Clicked");
     //   ActiveCards.P1cardAttributes[0] = AppearancesInt;

    }


}