using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOver : MonoBehaviour {

    public GameObject gameOverScreen;

    public static GameObject textBoxGameOver;
    public Text textBoxGameOverText;
    public static Font arial;
    public static Rigidbody2D TextBoxPhysics;
    RectTransform rectTransform;
    public Color32 winColour = new Color32(3, 252, 40, 255);


    // Use this for initialization
    void Start () {
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        StartCoroutine(waitforKwyDown());

        textBoxGameOver = new GameObject();
        textBoxGameOver.name = "textBoxGameOver";
    //    Debug.Log("popup Created");
        textBoxGameOver.transform.SetParent(controller.GameBG.transform);
        textBoxGameOver.AddComponent<Image>();
        textBoxGameOver.AddComponent<Rigidbody2D>();

        textBoxGameOver.AddComponent<Canvas>();
        textBoxGameOver.AddComponent<CanvasScaler>();
        textBoxGameOver.AddComponent<GraphicRaycaster>();

        Canvas canvas1 = GameObject.Find("ImageP1").GetComponent<Canvas>();
        canvas1.renderMode = RenderMode.ScreenSpaceOverlay;

        Image Background = textBoxGameOver.GetComponent<Image>();
        Background.color = winColour;

        TextBoxPhysics = textBoxGameOver.GetComponent<Rigidbody2D>();
        TextBoxPhysics.gravityScale = 0;

        rectTransform = textBoxGameOver.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 10);
        rectTransform.sizeDelta = new Vector2(500, 300);


        GameObject WinTextGO = new GameObject();
        WinTextGO.name = "GameOverTextGO";
        WinTextGO.transform.SetParent(textBoxGameOver.transform);
        WinTextGO.AddComponent<Text>();
        WinTextGO.AddComponent<Canvas>();

        textBoxGameOverText = WinTextGO.GetComponent<Text>();

        
            textBoxGameOverText.text = "GAME OVER";
        
        textBoxGameOverText.font = arial;
        // textBoxGameOverText.text = "Please select your attribute";
        textBoxGameOverText.fontSize = 30;
        textBoxGameOverText.color = Color.black;
        textBoxGameOverText.alignment = TextAnchor.MiddleCenter;

        rectTransform = textBoxGameOverText.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 0);
        rectTransform.sizeDelta = new Vector2(420, 100);

        waitforKwyDown();


    }

    // Update is called once per frame
    void Update()
    {

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
    //    Destroy(GameObject.Find("SelectAttParent"));
        Destroy(GameObject.Find("textBoxGameOver"));
        Destroy(GameObject.Find("GameOverTextGO"));
   //     Debug.Log("playersReady3");


    }
}
