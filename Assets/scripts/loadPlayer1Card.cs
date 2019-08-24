using System.Collections;
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
    public static Image Background;
    string changeMeToInt;
    int IntValue;

    //** holds int version of converted string xmlread value **//
    public static int AppearancesInt;
    public static int GoalsInt;
    public static int AssistsInt;
    public static int TeamsInt;
    public static int PremsInt;
    public static int BookingsInt;

    public static int AppearancesBoxHeight = -60;
    public static int GoalsBoxHeight = -60;
    public static int AssistsBoxHeight = -90;
    public static int TeamsBoxHeight = -60;
    public static int PremsBoxHeight = -60;
    public static int BookingsBoxHeight = -60;

    //  public static int AppearancesValue;

    //** Public value that gets changed by scripts hoverEvent & FindSelectedAttribute to set the attribute box background colour **//
    public static int attributesBoxColour = 0;

    //** Create attribute box state colours **//
    public Color32 hoverColour = new Color32(255, 222, 130, 255);
    public Color32 transparent = new Color32(0, 0, 0, 0);
    public Color32 clickedColour = new Color32(3, 252, 40, 255);

    public Vector3 cardPosition = new Vector3(0, 20, 0);
    public Vector2 cardSize = new Vector2(350, 490);


    //** Declare Rigidbody2d for images **//
   public static Rigidbody2D TextBoxPhysics;

    //** Hold Gravity Value **//
    public float gravityScale;

    private int fontSize = 18;




    //** Receives and holds the current p1 card id **/
    int SelectedCardId = controller.p1ActiveCard;


    //*** Declare a string version of current p1 id *//
    public static string SelectCardId;

    public static string PlayerName;
    public static string appearancesTitle;

    public static RectTransform rectTransform;

    public static GameObject textBoxBGBox;
    public static GameObject textBoxImage;
    

    public static GameObject textBoxApps;
    public static GameObject textBoxGoals;
    public static GameObject textBoxAssists;
    public static GameObject textBoxTeams;
    public static GameObject textBoxPrems;
    public static GameObject textBoxBookings;

    public static int boxHeight;

    // Use this for initialization
    void Start()
    {

        //     controller.ActivePlayer = 1;

        /* Create a RectTransform to hold position, size, anchor and pivot information for the card elements */
   //     RectTransform rectTransform;
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
        XmlNode trivia = bookings.NextSibling;
        // Debug.Log(name.InnerXml);

        //** Card Parent Game Object **//
        GameObject card = new GameObject();
        card.name = "P1ParentCard";
        //card.transform.parent = controller.P1mainCard.transform;
        card.transform.SetParent(controller.P1mainCard.transform);
     //   card.transform.localScale = new Vector2(350, 490);

        card.AddComponent<Canvas>();   /**/
        card.AddComponent<CanvasScaler>();   /**/
        card.AddComponent<GraphicRaycaster>();

        rectTransform = card.GetComponent<RectTransform>();
    //    rectTransform.localPosition = new Vector3(0, 0, 0);
        rectTransform.sizeDelta = new Vector2(350, 490);


        GameObject card01 = (GameObject)Instantiate(card);   /**/
        card01.transform.SetParent(card.transform);
       // card01.transform.localScale = new Vector2(350, 490);
        card01.name = "P1Card";   /**/


        rectTransform = card01.GetComponent<RectTransform>();
       // rectTransform.localPosition = cardPosition;
      //  rectTransform.sizeDelta = cardSize;
       // card01.transform.position = cardPosition;
     //   card01.transform.localScale = cardSize;

        //********************************//
        // Create the Image GameObject
        GameObject ImageBox = new GameObject();
        ImageBox.name = "P1ImageBoxParent";

     //   rectTransform = ImageBox.GetComponent<RectTransform>();
        // ImageBox.transform.parent = card01.transform;
        ImageBox.transform.SetParent(card.transform);
        // Instantiate(ImageBox);
        GameObject ImageP1 = (GameObject)Instantiate(ImageBox);

        ImageP1.name = "ImageP1";
 
        ImageP1.AddComponent<Image>(); ;
        ImageP1.AddComponent<GraphicRaycaster>();
        ImageP1.transform.SetParent(ImageBox.transform);
        LoadSprite.playerIDInt2 = 1;
        LoadSprite.CardIDInt = SelectedCardId;
        ImageP1.AddComponent<LoadSprite>();

        // Provide Image position and size using RectTransform.
        rectTransform = ImageP1.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 75, 0);
        rectTransform.sizeDelta = new Vector2(350, 223);


        //********************************//
        // Create the Background Image GameObject
        GameObject ImageBackground = new GameObject();
        ImageBackground.name = "ImageBackgroundP1Parent";
      //  ImageBackground.transform.parent = card01.transform;
        ImageBackground.transform.SetParent(card.transform);
     //   ImageBackground.transform.localScale = card01.transform.localScale;
        //  ImageBackground.AddComponent<Image>(); ;
        // ImageBackground.AddComponent<GraphicRaycaster>();


        //     rectTransform = ImageBackground.GetComponent<RectTransform>();
        //    rectTransform.localPosition = new Vector3(-239, 5, 0);
        //    rectTransform.sizeDelta = new Vector2(350, 490);

        // Instantiate(ImageBox);
        GameObject ImageBackgroundP1 = (GameObject)Instantiate(ImageBackground);

        ImageBackgroundP1.name = "ImageBackgroundP1";
        //ImageBackgroundP1.transform.parent = ImageBackground.transform;
        ImageBackgroundP1.transform.SetParent(card.transform);
       // ImageBackgroundP1.transform.localScale = card.transform.localScale;
        ImageBackgroundP1.AddComponent<Image>(); ;
        ImageBackgroundP1.AddComponent<GraphicRaycaster>();
        LoadBackground.playerIDInt = 1;
        ImageBackgroundP1.AddComponent<LoadBackground>();

        rectTransform = ImageBackgroundP1.GetComponent<RectTransform>();
       // rectTransform.localPosition = new Vector3(-478, 10, 0);
        rectTransform.sizeDelta = cardSize;


        // Background Colour box for attributes Parent
        textBoxBGBox = new GameObject();
        textBoxBGBox.name = "TextBoxBGParent";
        textBoxBGBox.transform.parent = ImageBackgroundP1.transform;
        textBoxBGBox.AddComponent<Image>();
        textBoxBGBox.AddComponent<Canvas>();
       textBoxBGBox.AddComponent<CanvasScaler>();
       textBoxBGBox.AddComponent<GraphicRaycaster>();

  

        //Background = textBoxBGBox.GetComponent<Image>();
      //  Background.color = transparent;

     //   rectTransform = textBoxBGBox.GetComponent<RectTransform>();
      //  rectTransform.localPosition = new Vector3(288, 205, 0);
      //  rectTransform.sizeDelta = new Vector2(200, 22);

     //   TextBoxPhysics = textBoxBGBox.GetComponent<Rigidbody2D>();
     //   TextBoxPhysics.gravityScale = 0;

        GameObject textBoxImage = (GameObject)Instantiate(textBoxBGBox);
        textBoxImage.name = "TextBoxBG";
       //   textBoxImage.transform.parent = textBoxBGBox.transform;
        textBoxImage.transform.SetParent(textBoxBGBox.transform);
        textBoxBGBox.GetComponent<Canvas>();
        textBoxBGBox.GetComponent<CanvasScaler>();
        textBoxBGBox.GetComponent<GraphicRaycaster>();
        textBoxImage.AddComponent<BoxCollider2D>();
        textBoxImage.AddComponent<Rigidbody2D>();

        Background = textBoxImage.GetComponent<Image>();
        Background.color = transparent;


        //  textBoxImage.AddComponent<Image>();
        // Background = textBoxBGBox.GetComponent<Canvas>();
        //  Background = textBoxBGBox.GetComponent<CanvasScaler>();
        //  Background = textBoxImage.AddComponent<GraphicRaycaster>();




        rectTransform = textBoxBGBox.GetComponent<RectTransform>();
       // rectTransform.localPosition = new Vector3(593, 220, 0);
        rectTransform.sizeDelta = new Vector2(200, 22);

        TextBoxPhysics = textBoxImage.GetComponent<Rigidbody2D>();
        TextBoxPhysics.gravityScale = 0;

        Background = textBoxBGBox.GetComponent<Image>();
        Background.color = transparent;







        //////


        //**PLAYER NAME**//
        // Create the Text GameObject.
        // GameObject textBox = (GameObject)Instantiate(textBoxApps);

        GameObject textBox = new GameObject();
        textBox.name = "Player1CardName";
        textBox.transform.parent = card.transform;
        textBox.AddComponent<Text>();
        textBox.AddComponent<Canvas>();

        // Set Text component properties.
        playerName = textBox.GetComponent<Text>();
        playerName.font = arial;
        playerName.text = name.InnerXml;
        PlayerName = playerName.text;
        playerName.fontSize = 30;
        playerName.color = Color.black;
        playerName.alignment = TextAnchor.MiddleCenter;

        // Provide Text position and size using RectTransform.             
        rectTransform = playerName.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 215, 0);
        rectTransform.sizeDelta = new Vector2(350, 50);

        Debug.Log(playerName.text);


        //**-------APPEARANCES-------------**//
        //Create Text Background Colour Box
        /*     GameObject textBoxAppsImage = (GameObject)Instantiate(textBoxBGBox);
             textBoxAppsImage.name = "AppearancesTextImage";
           //  textBoxAppsImage.transform.parent = ImageBackgroundP1.transform;
             textBoxBGBox.GetComponent<Canvas>();
             textBoxBGBox.GetComponent<CanvasScaler>();
             textBoxBGBox.GetComponent<GraphicRaycaster>();
             textBoxAppsImage.AddComponent<BoxCollider2D>();
             textBoxAppsImage.AddComponent<Rigidbody2D>();

             rectTransform = textBoxBGBox.GetComponent<RectTransform>();

             TextBoxPhysics = textBoxAppsImage.GetComponent<Rigidbody2D>();
             TextBoxPhysics.gravityScale = 0;

             Background = textBoxBGBox.GetComponent<Image>();
             Background.color = transparent;  */



        textBoxApps = new GameObject();
        
        textBoxApps.name = "AppearancesText";
       // textBoxApps.tag = "apps";
       // textBoxApps.transform.parent = ImageBackgroundP1.transform;
        textBoxApps.transform.SetParent(ImageBackgroundP1.transform);
        textBoxApps.AddComponent<Text>();
        Appearances = textBoxApps.GetComponent<Text>();
        Appearances.text = "Appearances: ";
       // Appearances.tag = "apps";
        ActiveCards.AttributesNames[0] = "Appearances";
        appearancesTitle = Appearances.text;
        Appearances.fontStyle = FontStyle.Bold;
        Appearances.font = arial;
        Appearances.fontSize = fontSize;
        Appearances.alignment = TextAnchor.MiddleLeft;
        Appearances.color = Color.black;

        textBoxApps.AddComponent<BoxCollider2D>();
        textBoxApps.AddComponent<Rigidbody2D>();
        textBoxApps.AddComponent<HoverEvent>();
        textBoxApps.AddComponent<FindSelectedAttribute>();
        textBoxApps.AddComponent<Button>();

        TextBoxPhysics = textBoxApps.GetComponent<Rigidbody2D>();
        TextBoxPhysics.gravityScale = 0;

        //    changeMeToInt = textBoxApps.name;
        //   AppearancesInt = stringToint(apps.InnerXml);
        //    ActiveCards.P1cardAttributes[0] = AppearancesInt;

        // Provide Text position and size using RectTransform.
        rectTransform = Appearances.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-55, -60, 0);
        rectTransform.sizeDelta = new Vector2(200, 22);


        /*-----------Apps Value--------*/
        GameObject AppsValue = new GameObject();
        AppsValue.name = "AppearancesValue";
        AppsValue.transform.parent = textBoxApps.transform;
        AppsValue.AddComponent<Text>();
        Appearances = AppsValue.GetComponent<Text>();
        Appearances.text = apps.InnerXml;
        Appearances.fontStyle = FontStyle.Bold;
        Appearances.font = arial;
        Appearances.fontSize = fontSize;
        Appearances.alignment = TextAnchor.MiddleCenter;
        Appearances.color = Color.black;

        AppsValue.AddComponent<BoxCollider2D>();
        AppsValue.AddComponent<Rigidbody2D>();
        //   AppsValue.AddComponent<HoverEvent>();
        //    AppsValue.AddComponent<FindSelectedAttribute>();
        //   AppsValue.AddComponent<Button>();

        TextBoxPhysics = AppsValue.GetComponent<Rigidbody2D>();
        TextBoxPhysics.gravityScale = 0;

        changeMeToInt = AppsValue.name;
        AppearancesInt = stringToint(apps.InnerXml);
        ActiveCards.P1cardAttributes[0] = AppearancesInt;

     //   Debug.Log("AppearancesInt " + AppearancesInt);

        // Provide Text position and size using RectTransform.
        rectTransform = Appearances.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(60, 0, 0);
        rectTransform.sizeDelta = new Vector2(30, 22);









        //**GOALS**//
        // Create the Text GameObject.
        textBoxGoals = new GameObject();
        // textBoxGoals = (GameObject)Instantiate(textBoxApps);
        textBoxGoals.name = "GoalsText";
        textBoxGoals.transform.parent = textBoxApps.transform;
        textBoxGoals.AddComponent<Text>();
        //  Appearances = textBoxApps.GetComponent<Text>();
        textBoxGoals.AddComponent<BoxCollider2D>();
        textBoxGoals.AddComponent<Rigidbody2D>();
      //  textBoxGoals.AddComponent<HoverEvent>();
        textBoxGoals.AddComponent<FindSelectedAttribute>();
        textBoxGoals.AddComponent<Button>();

        // Set Text component properties.
        Appearances = textBoxGoals.GetComponent<Text>();
        Appearances.font = arial;
        Appearances.text = "Goals: ";
        ActiveCards.AttributesNames[1] = "Goals";
        Appearances.fontStyle = FontStyle.Bold;
        Appearances.fontSize = fontSize;
        Appearances.alignment = TextAnchor.MiddleLeft;
        Appearances.color = Color.black;

        //   changeMeToInt = textBoxGoals.name;
        //   GoalsInt = stringToint(goals.InnerXml);
        //   ActiveCards.P1cardAttributes[1] = GoalsInt;

        TextBoxPhysics = textBoxGoals.GetComponent<Rigidbody2D>();
        TextBoxPhysics.gravityScale = 0;

        // Provide Text position and size using RectTransform.
        rectTransform = Appearances.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -30, 0);
        rectTransform.sizeDelta = new Vector2(200, 22);


        /*-----------Goals Value--------*/
        GameObject GoalsValue = new GameObject();
        GoalsValue.name = "GoalsValue";
        GoalsValue.transform.parent = textBoxGoals.transform;
        GoalsValue.AddComponent<Text>();
        Appearances = GoalsValue.GetComponent<Text>();
        Appearances.text = goals.InnerXml;
        Appearances.fontStyle = FontStyle.Bold;
        Appearances.font = arial;
        Appearances.fontSize = fontSize;
        Appearances.alignment = TextAnchor.MiddleCenter;
        Appearances.color = Color.black;

        GoalsValue.AddComponent<BoxCollider2D>();
        GoalsValue.AddComponent<Rigidbody2D>();


        TextBoxPhysics = GoalsValue.GetComponent<Rigidbody2D>();
        TextBoxPhysics.gravityScale = 0;

        changeMeToInt = GoalsValue.name;
        GoalsInt = stringToint(goals.InnerXml);
        ActiveCards.P1cardAttributes[1] = GoalsInt;


        // Provide Text position and size using RectTransform.
        rectTransform = Appearances.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(60, 0, 0);
        rectTransform.sizeDelta = new Vector2(30, 22);


        //**-----------ASSISTS----------**//
        // Create the Text GameObject.
        textBoxAssists = new GameObject();
        //textBoxAssists = (GameObject)Instantiate(textBoxApps);
        textBoxAssists.name = "AssistsText";
        textBoxAssists.transform.parent = textBoxApps.transform;
        textBoxAssists.AddComponent<Text>();
        textBoxAssists.AddComponent<BoxCollider2D>();
        textBoxAssists.AddComponent<Rigidbody2D>();

        TextBoxPhysics = textBoxAssists.GetComponent<Rigidbody2D>();
        TextBoxPhysics.gravityScale = 0;

     //   textBoxAssists.AddComponent<HoverEvent>();
        textBoxAssists.AddComponent<FindSelectedAttribute>();
        textBoxAssists.AddComponent<Button>();


        // Set Text component properties.
        Appearances = textBoxAssists.GetComponent<Text>();
        Appearances.font = arial;
        Appearances.text = "Assists: ";
        ActiveCards.AttributesNames[2] = "Assists";
        Appearances.fontStyle = FontStyle.Bold;
        Appearances.fontSize = fontSize;
        Appearances.alignment = TextAnchor.MiddleLeft;
        Appearances.color = Color.black;

     //   TextBoxPhysics = textBoxAssists.GetComponent<Rigidbody2D>();
    //    TextBoxPhysics.gravityScale = 0;

        // changeMeToInt = textBoxAssists.name;
        //  AssistsInt = stringToint(assists.InnerXml);
        //  ActiveCards.P1cardAttributes[2] = AssistsInt;

        // Provide Text position and size using RectTransform.
        rectTransform = Appearances.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -60, 0);
        rectTransform.sizeDelta = new Vector2(200, 22);

    //    textBoxAssists.AddComponent<HoverEvent>();
     //   textBoxAssists.AddComponent<FindSelectedAttribute>();
     //   textBoxAssists.AddComponent<Button>();

        /*-----------Assists Value--------*/
        GameObject AssistsValue = new GameObject();
        AssistsValue.name = "AssistsValue";
        AssistsValue.transform.parent = textBoxAssists.transform;
        AssistsValue.AddComponent<Text>();
        Appearances = AssistsValue.GetComponent<Text>();
        Appearances.text = assists.InnerXml;
        Appearances.fontStyle = FontStyle.Bold;
        Appearances.font = arial;
        Appearances.fontSize = fontSize;
        Appearances.alignment = TextAnchor.MiddleCenter;
        Appearances.color = Color.black;

        AssistsValue.AddComponent<BoxCollider2D>();
        AssistsValue.AddComponent<Rigidbody2D>();
        //   AssistsValue.AddComponent<HoverEvent>();
        //   AssistsValue.AddComponent<FindSelectedAttribute>();
        //    AssistsValue.AddComponent<Button>();

        TextBoxPhysics = AssistsValue.GetComponent<Rigidbody2D>();
        TextBoxPhysics.gravityScale = 0;

        changeMeToInt = AssistsValue.name;
        AssistsInt = stringToint(assists.InnerXml);
        ActiveCards.P1cardAttributes[2] = AssistsInt;


        // Provide Text position and size using RectTransform.
        rectTransform = Appearances.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(60, 0, 0);
        rectTransform.sizeDelta = new Vector2(30, 22);



        //**-----------TEAMS--------------**//
        // Create the Text GameObject.
        //textBoxTeams = (GameObject)Instantiate(textBoxAssists);
        textBoxTeams = new GameObject();
        textBoxTeams.name = "TeamsText";
        textBoxTeams.transform.parent = textBoxApps.transform;
        textBoxTeams.AddComponent<Text>();

        textBoxTeams.AddComponent<BoxCollider2D>();
        textBoxTeams.AddComponent<Rigidbody2D>();
     //   textBoxTeams.AddComponent<HoverEvent>();
        textBoxTeams.AddComponent<FindSelectedAttribute>();
        textBoxTeams.AddComponent<Button>();

        // Set Text component properties.
        Appearances = textBoxTeams.GetComponent<Text>();
        Appearances.font = arial;
        Appearances.text = "Teams: ";
        ActiveCards.AttributesNames[3] = "Teams";
        Appearances.fontStyle = FontStyle.Bold;
        Appearances.fontSize = fontSize;
        Appearances.alignment = TextAnchor.MiddleLeft;
        Appearances.color = Color.black;

        // changeMeToInt = textBoxTeams.name;
        // TeamsInt = stringToint(teams.InnerXml);
        //  ActiveCards.P1cardAttributes[3] = TeamsInt;

        TextBoxPhysics = textBoxTeams.GetComponent<Rigidbody2D>();
        TextBoxPhysics.gravityScale = 0;

        // Provide Text position and size using RectTransform.
        rectTransform = Appearances.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -90, 0);
        rectTransform.sizeDelta = new Vector2(200, 22);

        /*-----------Teams Value--------*/
        GameObject TeamsValue = new GameObject();
        TeamsValue.name = "TeamsValue";
        TeamsValue.transform.parent = textBoxTeams.transform;
        TeamsValue.AddComponent<Text>();
        Appearances = TeamsValue.GetComponent<Text>();
        Appearances.text = teams.InnerXml;
        Appearances.fontStyle = FontStyle.Bold;
        Appearances.font = arial;
        Appearances.fontSize = fontSize;
        Appearances.alignment = TextAnchor.MiddleCenter;
        Appearances.color = Color.black;

        TeamsValue.AddComponent<BoxCollider2D>();
        TeamsValue.AddComponent<Rigidbody2D>();
        //   TeamsValue.AddComponent<HoverEvent>();
        //   TeamsValue.AddComponent<FindSelectedAttribute>();
        //   TeamsValue.AddComponent<Button>();

        TextBoxPhysics = TeamsValue.GetComponent<Rigidbody2D>();
        TextBoxPhysics.gravityScale = 0;

        changeMeToInt = TeamsValue.name;
        TeamsInt = stringToint(teams.InnerXml);
        ActiveCards.P1cardAttributes[3] = TeamsInt;


        // Provide Text position and size using RectTransform.
        rectTransform = Appearances.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(60, 0, 0);
        rectTransform.sizeDelta = new Vector2(30, 22);

        //**PREMS**//
        // Create the Text GameObject.
        textBoxPrems = new GameObject();
        textBoxPrems.name = "PremsText";
        textBoxPrems.transform.parent = textBoxApps.transform;
        textBoxPrems.AddComponent<Text>();

        textBoxPrems.AddComponent<BoxCollider2D>();
        textBoxPrems.AddComponent<Rigidbody2D>();
     //   textBoxPrems.AddComponent<HoverEvent>();
        textBoxPrems.AddComponent<FindSelectedAttribute>();
        textBoxPrems.AddComponent<Button>();

        // Set Text component properties.
        Appearances = textBoxPrems.GetComponent<Text>();
        Appearances.font = arial;
        Appearances.text = "Premier Leagues: ";
        ActiveCards.AttributesNames[4] = "Prems";
        Appearances.fontStyle = FontStyle.Bold;
        Appearances.fontSize = fontSize;
        Appearances.alignment = TextAnchor.MiddleLeft;
        Appearances.color = Color.black;

        TextBoxPhysics = textBoxPrems.GetComponent<Rigidbody2D>();
        TextBoxPhysics.gravityScale = 0;

        //  changeMeToInt = textBoxPrems.name;
        //   PremsInt = stringToint(prems.InnerXml);
        //  ActiveCards.P1cardAttributes[4] = PremsInt;

        // Provide Text position and size using RectTransform.
        rectTransform = Appearances.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -120, 0);
        rectTransform.sizeDelta = new Vector2(200, 22);


        /*-----------Prems Value--------*/
        GameObject PremsValue = new GameObject();
        PremsValue.name = "PremsValue";
        PremsValue.transform.parent = textBoxPrems.transform;
        PremsValue.AddComponent<Text>();
        Appearances = PremsValue.GetComponent<Text>();
        Appearances.text = prems.InnerXml;
        Appearances.fontStyle = FontStyle.Bold;
        Appearances.font = arial;
        Appearances.fontSize = fontSize;
        Appearances.alignment = TextAnchor.MiddleCenter;
        Appearances.color = Color.black;

        PremsValue.AddComponent<BoxCollider2D>();
        PremsValue.AddComponent<Rigidbody2D>();
        //   PremsValue.AddComponent<HoverEvent>();
        //   PremsValue.AddComponent<FindSelectedAttribute>();
        //   PremsValue.AddComponent<Button>();

        TextBoxPhysics = PremsValue.GetComponent<Rigidbody2D>();
        TextBoxPhysics.gravityScale = 0;

        changeMeToInt = PremsValue.name;
        PremsInt = stringToint(prems.InnerXml);
        ActiveCards.P1cardAttributes[4] = PremsInt;


        // Provide Text position and size using RectTransform.
        rectTransform = Appearances.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(60, 0, 0);
        rectTransform.sizeDelta = new Vector2(30, 22);



        //**BOOKINGS**//
        // Create the Text GameObject.
        textBoxBookings = new GameObject();
        textBoxBookings.name = "BookingsText";
        textBoxBookings.transform.parent = textBoxApps.transform;
        textBoxBookings.AddComponent<Text>();

        textBoxBookings.AddComponent<BoxCollider2D>();
        textBoxBookings.AddComponent<Rigidbody2D>();
    //    textBoxBookings.AddComponent<HoverEvent>();
        textBoxBookings.AddComponent<FindSelectedAttribute>();
        textBoxBookings.AddComponent<Button>();

        // Set Text component properties.
        Appearances = textBoxBookings.GetComponent<Text>();
        Appearances.font = arial;
        Appearances.text = "Bookings: ";
        ActiveCards.AttributesNames[5] = "Bookings";
        Appearances.fontStyle = FontStyle.Bold;
        Appearances.fontSize = fontSize;
        Appearances.alignment = TextAnchor.MiddleLeft;
        Appearances.color = Color.black;

        TextBoxPhysics = textBoxBookings.GetComponent<Rigidbody2D>();
        TextBoxPhysics.gravityScale = 0;

        //   changeMeToInt = textBoxBookings.name;
        //  BookingsInt = stringToint(bookings.InnerXml);
        //  ActiveCards.P1cardAttributes[5] = BookingsInt;

        // Provide Text position and size using RectTransform.
        rectTransform = Appearances.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -150, 0);
        rectTransform.sizeDelta = new Vector2(200, 22);


        /*-----------Bookings Value--------*/
        GameObject BookingsValue = new GameObject();
        BookingsValue.name = "BookingsValue";
        BookingsValue.transform.parent = textBoxBookings.transform;
        BookingsValue.AddComponent<Text>();
        Appearances = BookingsValue.GetComponent<Text>();
        Appearances.text = bookings.InnerXml;
        Appearances.fontStyle = FontStyle.Bold;
        Appearances.font = arial;
        Appearances.fontSize = fontSize;
        Appearances.alignment = TextAnchor.MiddleCenter;
        Appearances.color = Color.black;

        BookingsValue.AddComponent<BoxCollider2D>();
        BookingsValue.AddComponent<Rigidbody2D>();
        //  BookingsValue.AddComponent<HoverEvent>();
        //   BookingsValue.AddComponent<FindSelectedAttribute>();
        //  BookingsValue.AddComponent<Button>();

        TextBoxPhysics = BookingsValue.GetComponent<Rigidbody2D>();
        TextBoxPhysics.gravityScale = 0;

        changeMeToInt = BookingsValue.name;
        BookingsInt = stringToint(bookings.InnerXml);
        ActiveCards.P1cardAttributes[5] = BookingsInt;


        // Provide Text position and size using RectTransform.
        rectTransform = Appearances.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(60, 0, 0);
        rectTransform.sizeDelta = new Vector2(30, 22);




        //**Trivia**//
        // Create the Text GameObject.
        GameObject textBoxTrivia = new GameObject();
        textBoxTrivia.name = "TriviaText";
        textBoxTrivia.transform.parent = textBoxApps.transform;
        textBoxTrivia.AddComponent<Text>();

        textBoxTrivia.AddComponent<BoxCollider2D>();
        textBoxTrivia.AddComponent<Rigidbody2D>();
        //  textBoxTrivia.AddComponent<HoverEvent>();
        //   textBoxTrivia.AddComponent<FindSelectedAttribute>();
        //   textBoxTrivia.AddComponent<Button>();

        // Set Text component properties.
        Appearances = textBoxTrivia.GetComponent<Text>();
        Appearances.font = arial;
        Appearances.text = trivia.InnerXml;
        // Appearances.fontStyle = FontStyle.Bold;
        Appearances.fontSize = 11;
        Appearances.alignment = TextAnchor.MiddleLeft;
        Appearances.color = Color.black;

        TextBoxPhysics = textBoxTrivia.GetComponent<Rigidbody2D>();
        TextBoxPhysics.gravityScale = 0;

        //  changeMeToInt = textBoxTrivia.name;
        //  BookingsInt = stringToint(bookings.InnerXml);
        //  ActiveCards.P1cardAttributes[5] = BookingsInt;

        // Provide Text position and size using RectTransform.
        rectTransform = Appearances.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(152, -97, 0);
        rectTransform.sizeDelta = new Vector2(136, 154);


        //  ActiveCards.P1cardAttributes[0] = AppearancesInt;
        ///  ActiveCards.P1cardAttributes[1] = GoalsInt;
        //  ActiveCards.P1cardAttributes[2] = AssistsInt;
        //   ActiveCards.P1cardAttributes[3] = TeamsInt;
        //  ActiveCards.P1cardAttributes[4] = PremsInt;
        //   ActiveCards.P1cardAttributes[5] = BookingsInt;

        // controller.ActivePlayer = 2;

        //    playerCardClass.playerCard p1Card = new playerCardClass.playerCard(SelectedCardId, textBox.name, AppearancesInt, GoalsInt, AssistsInt, TeamsInt, PremsInt, BookingsInt);


       // findPlaceInDeck();
       // playerInfoBar.plac



    }



    // Update is called once per frame
    void Update()
    {
        //   float timer = 10;
        //   timer -= Time.deltaTime;


        if (attributesBoxColour == 1)
        {
            Background.color = hoverColour;
            attributesBoxColour = 0; //reset event so not always returning ==1
        //    Debug.Log("boxColour =" + attributesBoxColour);

        }
        else if (attributesBoxColour == 2)
        {
            Background.color = transparent;
            attributesBoxColour = 0;  //reset event so not always returning ==2   
        //    Debug.Log("boxColour =" + attributesBoxColour);
        }
        else if (attributesBoxColour == 3)
        {
            Background.color = clickedColour;
            //  timer -= Time.deltaTime;
            //      textBoxAppsColour = 4;  //reset event so not always returning ==2  
            attributesBoxColour = 4;

         //   Debug.Log("boxColour =" + attributesBoxColour);

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
