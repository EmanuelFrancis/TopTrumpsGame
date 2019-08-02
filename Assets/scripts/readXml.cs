using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class readXml : MonoBehaviour {


    // Use this for initialization
    void Start () {

        // Load the document and set the root element.  
        XmlDocument doc = new XmlDocument();
        doc.Load("Assets/CardsData.xml");
        XmlNode root = doc.DocumentElement;

        // Add the namespace.  
        XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
        nsmgr.AddNamespace("bk", "urn:newcards-schema");

        // Select and display the first node in which the author's   
        // last name is Kingsolver.  
        XmlNode node = root.SelectSingleNode(
            "descendant::bk:player[bk:id='2']", nsmgr);
        XmlNode id = node.FirstChild;
        XmlNode name = id.NextSibling;
        XmlNode apps = name.NextSibling;
        XmlNode goals = apps.NextSibling;
        XmlNode assists = goals.NextSibling;
        XmlNode teams = assists.NextSibling;
        XmlNode prems = teams.NextSibling;
        XmlNode bookings = prems.NextSibling;
        Debug.Log(name.InnerXml);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
