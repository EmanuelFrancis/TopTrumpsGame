using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine.UI;
using UnityEngine;
using System;

public class CreateCard : MonoBehaviour
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

    public Vector3 P1CardPos = new Vector3(474, 266, 0);
    public Vector3 P1ImagePos = new Vector3(-239, 75, 0);

    //** Public value that gets changed by scripts hoverEvent & FindSelectedAttribute to set the attribute box background colour **//
    public static int attributesBoxColour = 0;

    public int activeCardSwitch;

    //** Create attribute box state colours **//
    public Color32 hoverColour = new Color32(255, 222, 130, 255);
    public Color32 transparent = new Color32(0, 0, 0, 0);
    public Color32 clickedColour = new Color32(145, 255, 164, 255);

    //** Declare Rigidbody2d for images **//
    Rigidbody2D TextBoxPhysics;

    //** Hold Gravity Value **//
    public float gravityScale;

    //** Receives and holds the current p1 card id **/
    int SelectedCardId = controller.ActiveCard;



    //*** Declare a string version of current p1 id *//
    public static string SelectCardId;



    // Use this for initialization
    void Start()
    {

        Debug.Log("ActivePlayer4 = " + controller.ActivePlayer);

        Debug.Log("ActiveCard = " + controller.ActiveCard);

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
        GameObject cardParent = new GameObject();
        cardParent.name = "PlAyEr" + controller.ActivePlayer +"ParentCard";



        if (controller.ActivePlayer == 1)
        {
            GameObject cardInstance = (GameObject)Instantiate(cardParent);   /**/
            cardInstance.transform.parent = cardParent.transform;   /**/
            cardInstance.name = name.InnerXml;   /**/
            cardInstance.transform.parent = cardInstance.transform;   /**/
            cardInstance.AddComponent<Canvas>();   /**/
            cardInstance.AddComponent<CanvasScaler>();   /**/
            cardInstance.AddComponent<GraphicRaycaster>();   /**/


            rectTransform = cardInstance.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(474, 266, 0);
            rectTransform.sizeDelta = new Vector2(948, 533);


            //********************************//
            // Create the Image GameObject
            GameObject ImageBox = new GameObject();
            ImageBox.name = "P1ImageBoxParent";
            ImageBox.transform.parent = cardInstance.transform;
            // Instantiate(ImageBox);
            GameObject ImageInstance = (GameObject)Instantiate(ImageBox);

            ImageInstance.name = "ImageP1";
            ImageInstance.transform.parent = cardInstance.transform;
            ImageInstance.AddComponent<Image>(); ;
            ImageInstance.AddComponent<GraphicRaycaster>();
            ImageInstance.AddComponent<LoadSprite>();

            // Provide Image position and size using RectTransform.
            rectTransform = ImageInstance.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(-239, 75, 0);
            rectTransform.sizeDelta = new Vector2(350, 223);

            //********************************//
            // Create the Background Image GameObject
            GameObject ImageBackground = new GameObject();
            ImageBackground.name = "ImageBackgroundP1Parent";
            ImageBackground.transform.parent = cardInstance.transform;
            // Instantiate(ImageBox);
            GameObject ImageBackgroundInstance = (GameObject)Instantiate(ImageBackground);

            ImageBackgroundInstance.name = "ImageBackgroundP1";
            ImageBackgroundInstance.transform.parent = cardInstance.transform;
            ImageBackgroundInstance.AddComponent<Image>(); ;
            ImageBackgroundInstance.AddComponent<GraphicRaycaster>();
            ImageBackgroundInstance.AddComponent<LoadBackground>();

            // Provide Image position and size using RectTransform.
            rectTransform = ImageBackgroundInstance.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(-239, 5, 0);
            rectTransform.sizeDelta = new Vector2(350, 490);



            GameObject attributesBox = new GameObject();
            attributesBox.name = "AttributesBoxParent";
            attributesBox.transform.parent = ImageBackgroundInstance.transform;


            //**PLAYER NAME**//
            // Create the Text GameObject.
            // GameObject textBox = (GameObject)Instantiate(attributesBox);
            GameObject textBox = new GameObject();
            textBox.name = "Player1CardName";
            textBox.transform.parent = cardInstance.transform;
            textBox.AddComponent<Text>();
            textBox.AddComponent<Canvas>();

            // Set Text component properties.
            playerName = textBox.GetComponent<Text>();
            playerName.font = arial;
            playerName.text = name.InnerXml;
            playerName.fontSize = 40;
            playerName.color = Color.black;
            playerName.alignment = TextAnchor.MiddleCenter;

            // Provide Text position and size using RectTransform.             
            rectTransform = playerName.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(-239, 215, 0);
            rectTransform.sizeDelta = new Vector2(350, 50);


            //**APPEARANCES**//

            //Create Text Background Image
            GameObject textBoxAppsImage = (GameObject)Instantiate(attributesBox);
            textBoxAppsImage.name = "AppearancesTextImage";
            textBoxAppsImage.transform.parent = ImageInstance.transform;
            textBoxAppsImage.AddComponent<Image>();
            textBoxAppsImage.AddComponent<Canvas>();
            textBoxAppsImage.AddComponent<CanvasScaler>();
            textBoxAppsImage.AddComponent<GraphicRaycaster>();

            rectTransform = textBoxAppsImage.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, -70, 0);
            rectTransform.sizeDelta = new Vector2(200, 22);

            Background = textBoxAppsImage.GetComponent<Image>();
            Background.color = transparent;


            // Create the Text GameObject.
            GameObject textBoxTitle = (GameObject)Instantiate(attributesBox);
            //  GameObject textBoxApps = new GameObject();
            textBoxTitle.name = "TitleText";
            textBoxTitle.transform.parent = ImageBackgroundInstance.transform;
            textBoxTitle.AddComponent<Text>();
            textBoxTitle.AddComponent<BoxCollider2D>();
            textBoxTitle.AddComponent<Rigidbody2D>();
            textBoxTitle.AddComponent<HoverEvent>();
            //  textBoxApps.AddComponent<attributeClicked>(); //Registers as soon as clicked
            textBoxTitle.AddComponent<FindSelectedAttribute>();  //Registers when clicked off like button

            // Set Text component properties.
            Appearances = textBoxTitle.GetComponent<Text>();
            Appearances.font = arial;
            Appearances.fontStyle = FontStyle.BoldAndItalic;
            // Appearances.fontStyle = FontStyle.Italic;
            Appearances.text = "Pick Your Stat";
            Appearances.fontSize = 20;
            Appearances.alignment = TextAnchor.MiddleCenter;
            Appearances.color = Color.black;

            TextBoxPhysics = textBoxTitle.GetComponent<Rigidbody2D>();
            TextBoxPhysics.gravityScale = 0;

            // Provide Text position and size using RectTransform.
            rectTransform = Appearances.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(-89, -47, 0);
            rectTransform.sizeDelta = new Vector2(200, 22);


            // Create the Text GameObject.
            GameObject textBoxApps = (GameObject)Instantiate(attributesBox);
            //  GameObject textBoxApps = new GameObject();
            textBoxApps.name = "AppearancesText";
            textBoxApps.transform.parent = ImageBackgroundInstance.transform;
            textBoxApps.AddComponent<Text>();
            textBoxApps.AddComponent<BoxCollider2D>();
            textBoxApps.AddComponent<Rigidbody2D>();
            textBoxApps.AddComponent<HoverEvent>();
            //  textBoxApps.AddComponent<attributeClicked>(); //Registers as soon as clicked
            textBoxApps.AddComponent<FindSelectedAttribute>();  //Registers when clicked off like button

            // Set Text component properties.
            Appearances = textBoxApps.GetComponent<Text>();
            Appearances.font = arial;
            Appearances.text = "Appearances: " + apps.InnerXml;
            Appearances.fontSize = 20;
            Appearances.alignment = TextAnchor.MiddleCenter;
            Appearances.color = Color.black;

            changeMeToInt = textBoxApps.name;
            AppearancesInt = stringToint(apps.InnerXml);



            TextBoxPhysics = textBoxApps.GetComponent<Rigidbody2D>();
            TextBoxPhysics.gravityScale = 0;

            // Provide Text position and size using RectTransform.
            rectTransform = Appearances.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, -70, 0);
            rectTransform.sizeDelta = new Vector2(200, 22);

            //**Button required for FindSelectedAttribute.cs**//
            //  Button textBoxButton;
            textBoxApps.AddComponent<Button>();
            //     textBoxButton = textBoxApps.GetComponent<Button>();
            //      textBoxButton.onClick.AddListener(assignToActiveCard);  

            //**GOALS**//
            // Create the Text GameObject.
            GameObject textBoxGoals = new GameObject();
            textBoxGoals.name = "GoalsText";
            textBoxGoals.transform.parent = ImageBackgroundInstance.transform;
            textBoxGoals.AddComponent<Text>();
            textBoxGoals.AddComponent<BoxCollider2D>();
            textBoxGoals.AddComponent<Rigidbody2D>();

            // Set Text component properties.
            Appearances = textBoxGoals.GetComponent<Text>();
            Appearances.font = arial;
            Appearances.text = "Goals: " + goals.InnerXml;
            Appearances.fontSize = 20;
            Appearances.alignment = TextAnchor.MiddleCenter;
            Appearances.color = Color.black;

            changeMeToInt = textBoxGoals.name;
            GoalsInt = stringToint(goals.InnerXml);


            TextBoxPhysics = textBoxGoals.GetComponent<Rigidbody2D>();
            TextBoxPhysics.gravityScale = 0;

            // Provide Text position and size using RectTransform.
            rectTransform = Appearances.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, -100, 0);
            rectTransform.sizeDelta = new Vector2(200, 22);

            //**ASSISTS**//
            // Create the Text GameObject.
            GameObject textBoxAssists = new GameObject();
            textBoxAssists.name = "AssistsText";
            textBoxAssists.transform.parent = ImageBackgroundInstance.transform;
            textBoxAssists.AddComponent<Text>();

            // Set Text component properties.
            Appearances = textBoxAssists.GetComponent<Text>();
            Appearances.font = arial;
            Appearances.text = "Assists: " + assists.InnerXml;
            Appearances.fontSize = 20;
            Appearances.alignment = TextAnchor.MiddleCenter;
            Appearances.color = Color.black;

            // Provide Text position and size using RectTransform.
            rectTransform = Appearances.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, -130, 0);
            rectTransform.sizeDelta = new Vector2(200, 22);

            //**TEAMS**//
            // Create the Text GameObject.
            GameObject textBoxTeams = new GameObject();
            textBoxTeams.name = "TeamsText";
            textBoxTeams.transform.parent = ImageBackgroundInstance.transform;
            textBoxTeams.AddComponent<Text>();

            // Set Text component properties.
            Appearances = textBoxTeams.GetComponent<Text>();
            Appearances.font = arial;
            Appearances.text = "Teams: " + teams.InnerXml;
            Appearances.fontSize = 20;
            Appearances.alignment = TextAnchor.MiddleCenter;
            Appearances.color = Color.black;

            // Provide Text position and size using RectTransform.
            rectTransform = Appearances.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, -160, 0);
            rectTransform.sizeDelta = new Vector2(200, 22);

            //**PREMS**//
            // Create the Text GameObject.
            GameObject textBoxPrems = new GameObject();
            textBoxPrems.name = "PremsText";
            textBoxPrems.transform.parent = ImageBackgroundInstance.transform;
            textBoxPrems.AddComponent<Text>();

            // Set Text component properties.
            Appearances = textBoxPrems.GetComponent<Text>();
            Appearances.font = arial;
            Appearances.text = "Premier Leagues: " + prems.InnerXml;
            Appearances.fontSize = 20;
            Appearances.alignment = TextAnchor.MiddleCenter;
            Appearances.color = Color.black;

            // Provide Text position and size using RectTransform.
            rectTransform = Appearances.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, -190, 0);
            rectTransform.sizeDelta = new Vector2(200, 22);

            //**BOOKINGS**//
            // Create the Text GameObject.
            GameObject textBoxBookings = new GameObject();
            textBoxBookings.name = "BookingsText";
            textBoxBookings.transform.parent = ImageBackgroundInstance.transform;
            textBoxBookings.AddComponent<Text>();

            // Set Text component properties.
            Appearances = textBoxBookings.GetComponent<Text>();
            Appearances.font = arial;
            Appearances.text = "Bookings: " + bookings.InnerXml;
            Appearances.fontSize = 20;
            Appearances.alignment = TextAnchor.MiddleCenter;
            Appearances.color = Color.black;

            // Provide Text position and size using RectTransform.
            rectTransform = Appearances.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, -220, 0);
            rectTransform.sizeDelta = new Vector2(200, 22);

            

        }
         if (controller.ActivePlayer == 1)
       {
            GameObject cardInstance2 = (GameObject)Instantiate(cardParent);   /**/
            cardInstance2.transform.parent = cardParent.transform;   /**/
            cardInstance2.name = name.InnerXml;   /**/
            cardInstance2.transform.parent = cardInstance2.transform;   /**/
            cardInstance2.AddComponent<Canvas>();   /**/
            cardInstance2.AddComponent<CanvasScaler>();   /**/
            cardInstance2.AddComponent<GraphicRaycaster>();   /**/


            rectTransform = cardInstance2.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(474, 266, 0);
            rectTransform.sizeDelta = new Vector2(948, 533);


            //********************************//
            // Create the Image GameObject
            GameObject ImageBox2 = new GameObject();
            ImageBox2.name = "P2ImageBoxParent";
            ImageBox2.transform.parent = cardInstance2.transform;
            // Instantiate(ImageBox);
            GameObject ImageInstance2 = (GameObject)Instantiate(ImageBox2);

            ImageInstance2.name = "ImageP2";
            ImageInstance2.transform.parent = cardInstance2.transform;
            ImageInstance2.AddComponent<Image>(); ;
            ImageInstance2.AddComponent<GraphicRaycaster>();
            ImageInstance2.AddComponent<LoadSprite>();

            // Provide Image position and size using RectTransform.
            rectTransform = ImageInstance2.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(239, 5, 0);
            rectTransform.sizeDelta = new Vector2(350, 223);

            //********************************//
            // Create the Background Image GameObject
            GameObject ImageBackground2 = new GameObject();
            ImageBackground2.name = "ImageBackgroundP2Parent";
            ImageBackground2.transform.parent = cardInstance2.transform;
            // Instantiate(ImageBox);
            GameObject ImageBackgroundInstance2 = (GameObject)Instantiate(ImageBackground2);

            ImageBackgroundInstance2.name = "ImageBackgroundP2";
            ImageBackgroundInstance2.transform.parent = cardInstance2.transform;
            ImageBackgroundInstance2.AddComponent<Image>(); ;
            ImageBackgroundInstance2.AddComponent<GraphicRaycaster>();
            ImageBackgroundInstance2.AddComponent<LoadBackground>();

            // Provide Image position and size using RectTransform.
            rectTransform = ImageBackgroundInstance2.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(239, 5, 0);
            rectTransform.sizeDelta = new Vector2(350, 490);



            GameObject attributesBox2 = new GameObject();
            attributesBox2.name = "AttributesBoxParent";
            attributesBox2.transform.parent = ImageBackgroundInstance2.transform;


            //**PLAYER NAME**//
            // Create the Text GameObject.
            // GameObject textBox = (GameObject)Instantiate(attributesBox);
            GameObject textBox = new GameObject();
            textBox.name = "Player2CardName";
            textBox.transform.parent = cardInstance2.transform;
            textBox.AddComponent<Text>();
            textBox.AddComponent<Canvas>();

            // Set Text component properties.
            playerName = textBox.GetComponent<Text>();
            playerName.font = arial;
            playerName.text = name.InnerXml;
            playerName.fontSize = 40;
            playerName.color = Color.black;
            playerName.alignment = TextAnchor.MiddleCenter;

            // Provide Text position and size using RectTransform.             
            rectTransform = playerName.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(239, 215, 0);
            rectTransform.sizeDelta = new Vector2(350, 50);


            //**APPEARANCES**//

            //Create Text Background Image
            GameObject textBoxAppsImage = (GameObject)Instantiate(attributesBox2);
            textBoxAppsImage.name = "AppearancesTextImage";
            textBoxAppsImage.transform.parent = ImageInstance2.transform;
            textBoxAppsImage.AddComponent<Image>();
            textBoxAppsImage.AddComponent<Canvas>();
            textBoxAppsImage.AddComponent<CanvasScaler>();
            textBoxAppsImage.AddComponent<GraphicRaycaster>();

            rectTransform = textBoxAppsImage.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, -70, 0);
            rectTransform.sizeDelta = new Vector2(200, 22);

            Background = textBoxAppsImage.GetComponent<Image>();
            Background.color = transparent;


            // Create the Text GameObject.
            GameObject textBoxTitle = (GameObject)Instantiate(attributesBox2);
            //  GameObject textBoxApps = new GameObject();
            textBoxTitle.name = "TitleText";
            textBoxTitle.transform.parent = ImageBackgroundInstance2.transform;
            textBoxTitle.AddComponent<Text>();
            textBoxTitle.AddComponent<BoxCollider2D>();
            textBoxTitle.AddComponent<Rigidbody2D>();
            textBoxTitle.AddComponent<HoverEvent>();
            //  textBoxApps.AddComponent<attributeClicked>(); //Registers as soon as clicked
            textBoxTitle.AddComponent<FindSelectedAttribute>();  //Registers when clicked off like button

            // Set Text component properties.
            Appearances = textBoxTitle.GetComponent<Text>();
            Appearances.font = arial;
            Appearances.fontStyle = FontStyle.BoldAndItalic;
            // Appearances.fontStyle = FontStyle.Italic;
            Appearances.text = "Pick Your Stat";
            Appearances.fontSize = 20;
            Appearances.alignment = TextAnchor.MiddleCenter;
            Appearances.color = Color.black;

            TextBoxPhysics = textBoxTitle.GetComponent<Rigidbody2D>();
            TextBoxPhysics.gravityScale = 0;

            // Provide Text position and size using RectTransform.
            rectTransform = Appearances.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(-89, -47, 0);
            rectTransform.sizeDelta = new Vector2(200, 22);


            // Create the Text GameObject.
            GameObject textBoxApps = (GameObject)Instantiate(attributesBox2);
            //  GameObject textBoxApps = new GameObject();
            textBoxApps.name = "AppearancesText";
            textBoxApps.transform.parent = ImageBackgroundInstance2.transform;
            textBoxApps.AddComponent<Text>();
            textBoxApps.AddComponent<BoxCollider2D>();
            textBoxApps.AddComponent<Rigidbody2D>();
            textBoxApps.AddComponent<HoverEvent>();
            //  textBoxApps.AddComponent<attributeClicked>(); //Registers as soon as clicked
            textBoxApps.AddComponent<FindSelectedAttribute>();  //Registers when clicked off like button

            // Set Text component properties.
            Appearances = textBoxApps.GetComponent<Text>();
            Appearances.font = arial;
            Appearances.text = "Appearances: " + apps.InnerXml;
            Appearances.fontSize = 20;
            Appearances.alignment = TextAnchor.MiddleCenter;
            Appearances.color = Color.black;

            changeMeToInt = textBoxApps.name;
            AppearancesInt = stringToint(apps.InnerXml);



            TextBoxPhysics = textBoxApps.GetComponent<Rigidbody2D>();
            TextBoxPhysics.gravityScale = 0;

            // Provide Text position and size using RectTransform.
            rectTransform = Appearances.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, -70, 0);
            rectTransform.sizeDelta = new Vector2(200, 22);

            //**Button required for FindSelectedAttribute.cs**//
            //  Button textBoxButton;
            textBoxApps.AddComponent<Button>();
            //     textBoxButton = textBoxApps.GetComponent<Button>();
            //      textBoxButton.onClick.AddListener(assignToActiveCard);  

            //**GOALS**//
            // Create the Text GameObject.
            GameObject textBoxGoals = new GameObject();
            textBoxGoals.name = "GoalsText";
            textBoxGoals.transform.parent = ImageBackgroundInstance2.transform;
            textBoxGoals.AddComponent<Text>();
            textBoxGoals.AddComponent<BoxCollider2D>();
            textBoxGoals.AddComponent<Rigidbody2D>();

            // Set Text component properties.
            Appearances = textBoxGoals.GetComponent<Text>();
            Appearances.font = arial;
            Appearances.text = "Goals: " + goals.InnerXml;
            Appearances.fontSize = 20;
            Appearances.alignment = TextAnchor.MiddleCenter;
            Appearances.color = Color.black;

            changeMeToInt = textBoxGoals.name;
            GoalsInt = stringToint(goals.InnerXml);


            TextBoxPhysics = textBoxGoals.GetComponent<Rigidbody2D>();
            TextBoxPhysics.gravityScale = 0;

            // Provide Text position and size using RectTransform.
            rectTransform = Appearances.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, -100, 0);
            rectTransform.sizeDelta = new Vector2(200, 22);

            //**ASSISTS**//
            // Create the Text GameObject.
            GameObject textBoxAssists = new GameObject();
            textBoxAssists.name = "AssistsText";
            textBoxAssists.transform.parent = ImageBackgroundInstance2.transform;
            textBoxAssists.AddComponent<Text>();

            // Set Text component properties.
            Appearances = textBoxAssists.GetComponent<Text>();
            Appearances.font = arial;
            Appearances.text = "Assists: " + assists.InnerXml;
            Appearances.fontSize = 20;
            Appearances.alignment = TextAnchor.MiddleCenter;
            Appearances.color = Color.black;

            // Provide Text position and size using RectTransform.
            rectTransform = Appearances.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, -130, 0);
            rectTransform.sizeDelta = new Vector2(200, 22);

            //**TEAMS**//
            // Create the Text GameObject.
            GameObject textBoxTeams = new GameObject();
            textBoxTeams.name = "TeamsText";
            textBoxTeams.transform.parent = ImageBackgroundInstance2.transform;
            textBoxTeams.AddComponent<Text>();

            // Set Text component properties.
            Appearances = textBoxTeams.GetComponent<Text>();
            Appearances.font = arial;
            Appearances.text = "Teams: " + teams.InnerXml;
            Appearances.fontSize = 20;
            Appearances.alignment = TextAnchor.MiddleCenter;
            Appearances.color = Color.black;

            // Provide Text position and size using RectTransform.
            rectTransform = Appearances.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, -160, 0);
            rectTransform.sizeDelta = new Vector2(200, 22);

            //**PREMS**//
            // Create the Text GameObject.
            GameObject textBoxPrems = new GameObject();
            textBoxPrems.name = "PremsText";
            textBoxPrems.transform.parent = ImageBackgroundInstance2.transform;
            textBoxPrems.AddComponent<Text>();

            // Set Text component properties.
            Appearances = textBoxPrems.GetComponent<Text>();
            Appearances.font = arial;
            Appearances.text = "Premier Leagues: " + prems.InnerXml;
            Appearances.fontSize = 20;
            Appearances.alignment = TextAnchor.MiddleCenter;
            Appearances.color = Color.black;

            // Provide Text position and size using RectTransform.
            rectTransform = Appearances.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, -190, 0);
            rectTransform.sizeDelta = new Vector2(200, 22);

            //**BOOKINGS**//
            // Create the Text GameObject.
            GameObject textBoxBookings = new GameObject();
            textBoxBookings.name = "BookingsText";
            textBoxBookings.transform.parent = ImageBackgroundInstance2.transform;
            textBoxBookings.AddComponent<Text>();

            // Set Text component properties.
            Appearances = textBoxBookings.GetComponent<Text>();
            Appearances.font = arial;
            Appearances.text = "Bookings: " + bookings.InnerXml;
            Appearances.fontSize = 20;
            Appearances.alignment = TextAnchor.MiddleCenter;
            Appearances.color = Color.black;

            // Provide Text position and size using RectTransform.
            rectTransform = Appearances.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, -220, 0);
            rectTransform.sizeDelta = new Vector2(200, 22);

      
        }


      


        if (controller.ActivePlayer == 1)
        {
            activeCardSwitch = 1;
            ActiveCards.P1cardAttributes[0] = AppearancesInt;
            ActiveCards.P1cardAttributes[1] = GoalsInt;
            ActiveCards.P1cardAttributes[2] = AssistsInt;
            ActiveCards.P1cardAttributes[3] = TeamsInt;
            ActiveCards.P1cardAttributes[4] = PremsInt;
            ActiveCards.P1cardAttributes[5] = BookingsInt;
        }
        else
        {
            ActiveCards.P2cardAttributes[0] = AppearancesInt;
            ActiveCards.P2cardAttributes[1] = GoalsInt;
            ActiveCards.P2cardAttributes[2] = AssistsInt;
            ActiveCards.P2cardAttributes[3] = TeamsInt;
            ActiveCards.P2cardAttributes[4] = PremsInt;
            ActiveCards.P2cardAttributes[5] = BookingsInt;
        }

        Debug.Log("ActivePlayer6 = " + controller.ActivePlayer);



        Debug.Log("ActivePlayer8 = " + controller.ActivePlayer);
        //  playerCardClass.playerCard p1Card = new playerCardClass.playerCard(SelectedCardId, textBox.name, AppearancesInt, GoalsInt, AssistsInt, TeamsInt, PremsInt, BookingsInt);

    }



    // Update is called once per frame
    void Update()
    {

      //  if (activeCardSwitch == 1)
      //  {
      //      controller.ActivePlayer = 2;
          //  Debug.Log("ActivePlayer7 = " + controller.ActivePlayer);
     //   }
     //   else
    //    {
         //   controller.ActivePlayer = 1;
    //    }


        if (attributesBoxColour == 1)
        {
            Background.color = hoverColour;
            attributesBoxColour = 0; //reset event so not always returning ==1

        }
        else if (attributesBoxColour == 2)
        {
            Background.color = transparent;
            attributesBoxColour = 0;  //reset event so not always returning ==2                                                
        }
        else if (attributesBoxColour == 3)
        {
            Background.color = clickedColour;
            attributesBoxColour = 4;  //reset event so not always returning ==2      

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
