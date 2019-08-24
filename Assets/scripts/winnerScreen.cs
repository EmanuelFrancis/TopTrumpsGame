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
        rectTransform.localPosition = new Vector3(319, 473, 10);
        rectTransform.sizeDelta = new Vector2(500, 300);


        GameObject WinTextGO = new GameObject();
        WinTextGO.name = "HUMANWinTextGO";
        WinTextGO.transform.SetParent(textBoxWin.transform);
        WinTextGO.AddComponent<Text>();
        WinTextGO.AddComponent<Canvas>();

        WinText = WinTextGO.GetComponent<Text>();

       // controller.P1mainCard.AddComponent<compare>();

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
    
}
	
	// Update is called once per frame
	void Update () {
		
	}
}
