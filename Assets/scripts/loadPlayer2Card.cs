using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine.UI;
using UnityEngine;
using System;

public class loadPlayer2Card : MonoBehaviour
{

    public TextAsset xmlRawFile;
    public Text playerName2;
    public Text Appearances;
    public Image Background;
    string changeMeToInt;
    int IntValue;

    public static string PlayerName;

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
    public Color32 clickedColour = new Color32(145, 255, 164, 255);


    Rigidbody2D textBox2Physics;

  //  public GameObject card02;



    public float gravityScale;

    int SelectedCardId = controller.p2ActiveCard;
    public static string SelectCardId;



    // Use this for initialization
    void Start()
    {

        //controller.ActivePlayer = 2;
        //    Debug.Log(SelectedCardId);

        // Sprite sprite;
        RectTransform rectTransform;
        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        XmlDocument doc = new XmlDocument();
        doc.Load("Assets/CardsData.xml");
        XmlNode root = doc.DocumentElement;

        // Add the namespace.  
        XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
        nsmgr.AddNamespace("bk", "urn:newcards-schema");

        SelectCardId = SelectedCardId.ToString();

        // Select and display the first node in which the author's   
        // last name is Kingsolver.  
        XmlNode node = root.SelectSingleNode(
            "descendant::bk:player[bk:id='" + SelectCardId + "']", nsmgr);
        XmlNode id = node.FirstChild;
        XmlNode name = id.NextSibling;
        XmlNode apps = name.NextSibling;
        XmlNode goals = apps.NextSibling;
        XmlNode assists = goals.NextSibling;
        XmlNode teams = assists.NextSibling;
        XmlNode prems = teams.NextSibling;
        XmlNode bookings = prems.NextSibling;

        GameObject card = new GameObject();
        card.name = "P2ParentCard";


      //  card.transform.parent = controller.playerInstance02.transform;
        GameObject card02 = (GameObject)Instantiate(card);
        card02.name = "P2Card";
        card02.transform.parent = controller.P2mainCard.transform;


        // Create the Image GameObject
        GameObject ImageBox = new GameObject();
        ImageBox.name = "P2ImageBoxParent";
        ImageBox.transform.parent = card.transform;
        // Instantiate(ImageBox);
        GameObject ImageP2 = (GameObject)Instantiate(ImageBox);

        ImageP2.name = "ImageP2";
        ImageP2.transform.parent = card02.transform;
 


        //********************************//
        // Create the Background Image GameObject
        GameObject ImageBackground = new GameObject();
        ImageBackground.name = "ImageBackgroundP2Parent";
        ImageBackground.transform.parent = card.transform;
        // Instantiate(ImageBox);
        GameObject ImageBackgroundP2 = (GameObject)Instantiate(ImageBackground);

        ImageBackgroundP2.name = "ImageBackgroundP2";
        ImageBackgroundP2.transform.parent = card02.transform;
       

        GameObject attributesBox = new GameObject();
        attributesBox.name = "AttributesBoxParent";
        attributesBox.transform.parent = ImageBackgroundP2.transform;


        //**PLAYER NAME**//
        // Create the Text GameObject.
        GameObject textBox2 = new GameObject();
        textBox2.name = "player2CardName";
        textBox2.transform.parent = card02.transform;

        PlayerName = name.InnerXml;

        //**APPEARANCES**//


        //Create Text Background Image
        GameObject textBoxAppsImage = (GameObject)Instantiate(attributesBox);
        textBoxAppsImage.name = "AppearancesTextImage";
        textBoxAppsImage.transform.parent = ImageP2.transform;
      


        // Create the Text GameObject.
        GameObject textBoxTitle = (GameObject)Instantiate(attributesBox);
        //  GameObject textBoxApps = new GameObject();
        textBoxTitle.name = "TitleText";
        textBoxTitle.transform.parent = ImageBackgroundP2.transform;
       

      


        // Create the Text GameObject.
        GameObject textBox2Apps = new GameObject();
        textBox2Apps.name = "AppearancesText";
        textBox2Apps.transform.parent = ImageBackgroundP2.transform;
        textBox2Apps.AddComponent<Text>();


        // Set Text component properties.
        Appearances = textBox2Apps.GetComponent<Text>();
        Appearances.font = arial;
        Appearances.text = "Appearances: " + apps.InnerXml;
        Appearances.fontSize = 20;
        Appearances.alignment = TextAnchor.MiddleCenter;
        Appearances.color = Color.black;

        changeMeToInt = textBox2Apps.name;
        AppearancesInt = stringToint(apps.InnerXml);
        ActiveCards.P2cardAttributes[0] = AppearancesInt;
      //  Debug.Log("woo2" + ActiveCards.P2cardAttributes[0]);

    

        //**GOALS**//
        // Create the Text GameObject.
        GameObject textBox2Goals = new GameObject();
        textBox2Goals.name = "GoalsText";
        textBox2Goals.transform.parent = ImageBackgroundP2.transform;
        textBox2Goals.AddComponent<Text>();
        textBox2Goals.AddComponent<BoxCollider2D>();
        textBox2Goals.AddComponent<Rigidbody2D>();

        // Set Text component properties.
        Appearances = textBox2Goals.GetComponent<Text>();
        Appearances.font = arial;
        Appearances.text = "Goals: " + goals.InnerXml;
        Appearances.fontSize = 20;
        Appearances.alignment = TextAnchor.MiddleCenter;
        Appearances.color = Color.black;

        changeMeToInt = textBox2Goals.name;
        GoalsInt = stringToint(goals.InnerXml);
        ActiveCards.P2cardAttributes[1] = GoalsInt;

        textBox2Physics = textBox2Goals.GetComponent<Rigidbody2D>();
        textBox2Physics.gravityScale = 0;

        // Provide Text position and size using RectTransform.
        rectTransform = Appearances.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -100, 0);
        rectTransform.sizeDelta = new Vector2(200, 22);

        //**ASSISTS**//
        // Create the Text GameObject.
        GameObject textBox2Assists = new GameObject();
        textBox2Assists.name = "AssistsText";
        textBox2Assists.transform.parent = ImageBackgroundP2.transform;
        textBox2Assists.AddComponent<Text>();

        // Set Text component properties.
        Appearances = textBox2Assists.GetComponent<Text>();
        Appearances.font = arial;
        Appearances.text = "Assists: " + assists.InnerXml;
        Appearances.fontSize = 20;
        Appearances.alignment = TextAnchor.MiddleCenter;
        Appearances.color = Color.black;

        changeMeToInt = textBox2Assists.name;
        AssistsInt = stringToint(assists.InnerXml);
        ActiveCards.P2cardAttributes[2] = AssistsInt;

        textBox2Physics = textBox2Goals.GetComponent<Rigidbody2D>();
        textBox2Physics.gravityScale = 0;


        // Provide Text position and size using RectTransform.
        rectTransform = Appearances.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -130, 0);
        rectTransform.sizeDelta = new Vector2(200, 22);

        //**TEAMS**//
        // Create the Text GameObject.
        GameObject textBox2Teams = new GameObject();
        textBox2Teams.name = "TeamsText";
        textBox2Teams.transform.parent = ImageBackgroundP2.transform;
        textBox2Teams.AddComponent<Text>();

        // Set Text component properties.
        Appearances = textBox2Teams.GetComponent<Text>();
        Appearances.font = arial;
        Appearances.text = "Teams: " + teams.InnerXml;
        Appearances.fontSize = 20;
        Appearances.alignment = TextAnchor.MiddleCenter;
        Appearances.color = Color.black;

        changeMeToInt = textBox2Teams.name;
        TeamsInt = stringToint(teams.InnerXml);
        ActiveCards.P2cardAttributes[3] = TeamsInt;

        // Provide Text position and size using RectTransform.
        rectTransform = Appearances.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -160, 0);
        rectTransform.sizeDelta = new Vector2(200, 22);

        //**PREMS**//
        // Create the Text GameObject.
        GameObject textBox2Prems = new GameObject();
        textBox2Prems.name = "PremsText";
        textBox2Prems.transform.parent = ImageBackgroundP2.transform;
        textBox2Prems.AddComponent<Text>();

        // Set Text component properties.
        Appearances = textBox2Prems.GetComponent<Text>();
        Appearances.font = arial;
        Appearances.text = "Premier Leagues: " + prems.InnerXml;
        Appearances.fontSize = 20;
        Appearances.alignment = TextAnchor.MiddleCenter;
        Appearances.color = Color.black;

        changeMeToInt = textBox2Prems.name;
        PremsInt = stringToint(prems.InnerXml);
        ActiveCards.P2cardAttributes[4] = PremsInt;

        // Provide Text position and size using RectTransform.
        rectTransform = Appearances.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -190, 0);
        rectTransform.sizeDelta = new Vector2(200, 22);

        //**BOOKINGS**//
        // Create the Text GameObject.
        GameObject textBox2Bookings = new GameObject();
        textBox2Bookings.name = "BookingsText";
        textBox2Bookings.transform.parent = ImageBackgroundP2.transform;
        textBox2Bookings.AddComponent<Text>();

        // Set Text component properties.
        Appearances = textBox2Bookings.GetComponent<Text>();
        Appearances.font = arial;
        Appearances.text = "Bookings: " + bookings.InnerXml;
        Appearances.fontSize = 20;
        Appearances.alignment = TextAnchor.MiddleCenter;
        Appearances.color = Color.black;

        changeMeToInt = textBox2Bookings.name;
        BookingsInt = stringToint(bookings.InnerXml);
        ActiveCards.P2cardAttributes[5] = BookingsInt;

        // Provide Text position and size using RectTransform.
        rectTransform = Appearances.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -220, 0);
        rectTransform.sizeDelta = new Vector2(200, 22);


///  controller.ActivePlayer = 0;
        //  playerCardClass.playerCard p1Card = new playerCardClass.playerCard(SelectedCardId, textBox2.name, AppearancesInt, GoalsInt, AssistsInt, TeamsInt, PremsInt, BookingsInt);
    }


    // Update is called once per frame
    void Update()
    {

        /*
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

    */
    }

    int stringToint(string changeMeToInt)
    {
        // Convert Text number into String
        int.TryParse(changeMeToInt, out IntValue);
 
        return IntValue;
    }

    public void assignToActiveCard()
    {
        Debug.Log("Clicked");
        //   ActiveCards.P1cardAttributes[0] = AppearancesInt;

    }
}
