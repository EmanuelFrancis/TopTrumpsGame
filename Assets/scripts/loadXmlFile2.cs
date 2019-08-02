using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine.UI;
using UnityEngine;
using System;


public class loadXmlFile2 : MonoBehaviour
{

    public TextAsset xmlRawFile;
    public Text playerName;
    public Text Appearances;



    // Use this for initialization
    void Start()
    {

        XmlDocument doc = new XmlDocument();
        doc.Load("Assets/CardsData.xml");
        string xmlcontents = doc.InnerXml;
        string data = xmlcontents;

        parseXmlFile(data);
    }


    void parseXmlFile(string xmlData)
    {
        RectTransform rectTransform;
        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        // string totVal = "";
        XmlDocument xmlDoc = new XmlDocument();
        // xmlDoc.Load("CardsData");


        xmlDoc.Load(new StringReader(xmlData));
        // string xmlcontents = xmlDoc.InnerXml;

        string xmlPathPattern = "//playercards/player";
        XmlNodeList myNodeList = xmlDoc.SelectNodes(xmlPathPattern);
        foreach (XmlNode node in myNodeList)
        {
            XmlNode id = node.FirstChild;
            XmlNode name = id.NextSibling;
            XmlNode apps = name.NextSibling;
            XmlNode goals = apps.NextSibling;
            XmlNode assists = goals.NextSibling;
            XmlNode teams = assists.NextSibling;
            XmlNode prems = teams.NextSibling;
            XmlNode bookings = prems.NextSibling;


            // Create the Card GameObject
            GameObject card02 = new GameObject();
            card02.name = "Player2Card";
            card02.AddComponent<Canvas>();
            card02.AddComponent<CanvasScaler>();
            card02.AddComponent<GraphicRaycaster>();

            rectTransform = card02.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(874, 266, 0);
            rectTransform.sizeDelta = new Vector2(948, 533);

            // Create the Image GameObject
            GameObject Image_player2 = new GameObject();
            Image_player2.name = "Image_player2";
            Image_player2.transform.parent = card02.transform;
            Image_player2.AddComponent<Image>(); ;
            Image_player2.AddComponent<GraphicRaycaster>();
            Image_player2.AddComponent<LoadSprite2>();

            Canvas canvas;
            canvas = GameObject.Find("Image_player2").GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            // Provide Image position and size using RectTransform.
            rectTransform = Image_player2.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(239, 5, 0);
            rectTransform.sizeDelta = new Vector2(350, 490);




            //**PLAYER NAME**//
            // Create the Text GameObject.
            GameObject textBox = new GameObject();
            textBox.name = "PlayerNameText";
            textBox.transform.parent = card02.transform;
            textBox.AddComponent<Text>();
            textBox.AddComponent<Canvas>();

            // Set Text component properties.
            playerName = textBox.GetComponent<Text>();
            playerName.font = arial;
            playerName.text = name.InnerXml;
            playerName.fontSize = 40;
            playerName.alignment = TextAnchor.MiddleCenter;

            // Provide Text position and size using RectTransform.             
            rectTransform = playerName.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(239, 215, 0);
            rectTransform.sizeDelta = new Vector2(350, 50);


            //**APPEARANCES**//
            // Create the Text GameObject.
            GameObject textBoxApps = new GameObject();
            textBoxApps.transform.parent = canvas.transform;
            textBoxApps.AddComponent<Text>();

            // Set Text component properties.
            Appearances = textBoxApps.GetComponent<Text>();
            Appearances.font = arial;
            Appearances.text = "Appearances: " + apps.InnerXml;
            Appearances.fontSize = 20;
            Appearances.alignment = TextAnchor.MiddleCenter;
            Appearances.color = Color.black;

            // Provide Text position and size using RectTransform.
            rectTransform = Appearances.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, -70, 0);
            rectTransform.sizeDelta = new Vector2(600, 200);

            //**GOALS**//
            // Create the Text GameObject.
            GameObject textBoxGoals = new GameObject();
            textBoxGoals.transform.parent = canvas.transform;
            textBoxGoals.AddComponent<Text>();

            // Set Text component properties.
            Appearances = textBoxGoals.GetComponent<Text>();
            Appearances.font = arial;
            Appearances.text = "Goals: " + goals.InnerXml;
            Appearances.fontSize = 20;
            Appearances.alignment = TextAnchor.MiddleCenter;
            Appearances.color = Color.black;

            // Provide Text position and size using RectTransform.
            rectTransform = Appearances.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, -90, 0);
            rectTransform.sizeDelta = new Vector2(600, 200);

            //**ASSISTS**//
            // Create the Text GameObject.
            GameObject textBoxAssists = new GameObject();
            textBoxAssists.transform.parent = canvas.transform;
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
            rectTransform.localPosition = new Vector3(0, -110, 0);
            rectTransform.sizeDelta = new Vector2(600, 200);

            //**TEAMS**//
            // Create the Text GameObject.
            GameObject textBoxTeams = new GameObject();
            textBoxTeams.transform.parent = canvas.transform;
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
            rectTransform.localPosition = new Vector3(0, -130, 0);
            rectTransform.sizeDelta = new Vector2(600, 200);

            //**PREMS**//
            // Create the Text GameObject.
            GameObject textBoxPrems = new GameObject();
            textBoxPrems.transform.parent = canvas.transform;
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
            rectTransform.localPosition = new Vector3(0, -150, 0);
            rectTransform.sizeDelta = new Vector2(600, 200);

            //**BOOKINGS**//
            // Create the Text GameObject.
            GameObject textBoxBookings = new GameObject();
            textBoxBookings.transform.parent = canvas.transform;
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
            rectTransform.localPosition = new Vector3(0, -170, 0);
            rectTransform.sizeDelta = new Vector2(600, 200);

        }
    }
}
