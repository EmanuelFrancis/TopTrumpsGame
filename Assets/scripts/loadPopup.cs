using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadPopup : MonoBehaviour {

    public GameObject popup;
    public static GameObject textBoxChooseAtt;
    public Text textBoxChooseAttText;
    public static Font arial;
    public static Rigidbody2D TextBoxPhysics;
    RectTransform rectTransform;
    public Color32 winColour = new Color32(3, 252, 40, 255);
    bool draw = false;

    // Use this for initialization
    void Start () {
        Debug.Log("loadPopupScript started");

        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        StartCoroutine(waitforKwyDown());


        //   popup = new GameObject(); /* Creates a parent humanPlayer GO */
        //    popup.name = "PopupGO";  /* Names the parent humanPlayer GO */
        ////    popup.AddComponent<Canvas>();
        //    popup.AddComponent<CanvasScaler>();
        //    popup.AddComponent<GraphicRaycaster>();

        /*
                GameObject SelectAtt = new GameObject(); /* Creates a parent humanPlayer GO *//*
        SelectAtt.name = "SelectAttParent";
            SelectAtt.transform.SetParent(controller.GameBG.transform);

            SelectAtt.AddComponent<Canvas>();
            SelectAtt.AddComponent<CanvasScaler>();
            SelectAtt.AddComponent<GraphicRaycaster>();

       Canvas canvas1 = GameObject.Find("ImageP1").GetComponent<Canvas>();
        canvas1.renderMode = RenderMode.ScreenSpaceOverlay;

*/


        textBoxChooseAtt = new GameObject();
            textBoxChooseAtt.name = "textBoxChooseAtt";
            Debug.Log("popup Created");
            textBoxChooseAtt.transform.SetParent(controller.GameBG.transform);
            textBoxChooseAtt.AddComponent<Image>();
            textBoxChooseAtt.AddComponent<Rigidbody2D>();

        textBoxChooseAtt.AddComponent<Canvas>();
        textBoxChooseAtt.AddComponent<CanvasScaler>();
        textBoxChooseAtt.AddComponent<GraphicRaycaster>();

        Canvas canvas1 = GameObject.Find("ImageP1").GetComponent<Canvas>();
        canvas1.renderMode = RenderMode.ScreenSpaceOverlay;

        Image Background = textBoxChooseAtt.GetComponent<Image>();
            Background.color = winColour;

            TextBoxPhysics = textBoxChooseAtt.GetComponent<Rigidbody2D>();
            TextBoxPhysics.gravityScale = 0;

            rectTransform = textBoxChooseAtt.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, 365, 10);
            rectTransform.sizeDelta = new Vector2(500, 200);


            GameObject WinTextGO = new GameObject();
            WinTextGO.name = "ChooseTextGO";
            WinTextGO.transform.SetParent(textBoxChooseAtt.transform);
            WinTextGO.AddComponent<Text>();
            WinTextGO.AddComponent<Canvas>();

        textBoxChooseAttText = WinTextGO.GetComponent<Text>();
            if (draw == true)
            {
                textBoxChooseAttText.text = "DRAW";
            }
            else
            {
                textBoxChooseAttText.text = "Please select your attribute, press y to continue...";
            }
            textBoxChooseAttText.font = arial;
           // textBoxChooseAttText.text = "Please select your attribute";
            textBoxChooseAttText.fontSize = 30;
            textBoxChooseAttText.color = Color.black;
            textBoxChooseAttText.alignment = TextAnchor.MiddleCenter;

            rectTransform = textBoxChooseAttText.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, 0, 0);
            rectTransform.sizeDelta = new Vector2(420, 100);

        waitforKwyDown();
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator waitforKwyDown()
    {
        //while (!Input.GetKeyDown("y"))
            while (!Input.GetMouseButtonDown(0))
            {
            //     Debug.Log("null");

            yield return null;


        }

        //   controller newRound = FindObjectOfType<controller>();
        // newRound.game();
        //  controller.roundBegin();
        Destroy(GameObject.Find("SelectAttParent"));
        Destroy(GameObject.Find("textBoxChooseAtt"));
        Destroy(GameObject.Find("ChooseTextGO"));
        Debug.Log("playersReady3");


    }


}
