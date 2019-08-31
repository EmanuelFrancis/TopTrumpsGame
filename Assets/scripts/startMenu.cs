using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startMenu : MonoBehaviour {

    public static Image Background;
 //   public static GameObject Button;

    public static Rigidbody2D TextBoxPhysics;

    public static RectTransform rectTransform;

    public float gravityScale;

    public Color32 MenuBGcolour = new Color32(0, 0, 0, 255);
    public Color32 GameEnvcolour = new Color32(52, 125, 235, 255);

    public Font arial;


    // Use this for initialization
    void Start () {

        /* Create a Font object */
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        StartCoroutine(waitforyDown());

        //START MENU//
        GameObject MenuBG = new GameObject();
        MenuBG.name = "MenuBG";
        MenuBG.AddComponent<Image>(); ;
        MenuBG.AddComponent<Canvas>(); ;
        MenuBG.AddComponent<CanvasScaler>(); ;
        MenuBG.AddComponent<GraphicRaycaster>();

        Background = MenuBG.GetComponent<Image>();
        Background.color = MenuBGcolour;

        rectTransform = MenuBG.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 700);
        rectTransform.sizeDelta = new Vector2(640, 960);



 
            GameObject MenuTextParent = new GameObject();
            MenuTextParent.name = "MenuTextParent";
            MenuTextParent.AddComponent<Text>();
            MenuTextParent.AddComponent<Canvas>();   /**/
            MenuTextParent.AddComponent<CanvasScaler>();
            MenuTextParent.AddComponent<GraphicRaycaster>();
            MenuTextParent.AddComponent<BoxCollider2D>();
            MenuTextParent.AddComponent<Rigidbody2D>();


            TextBoxPhysics = MenuTextParent.GetComponent<Rigidbody2D>();
            TextBoxPhysics.gravityScale = 0;

            GameObject Menu = (GameObject)Instantiate(MenuTextParent);
        Menu.name = "Menu";
        Menu.transform.SetParent(MenuTextParent.transform);
        Menu.AddComponent<Text>();

           Text MenuText = Menu.GetComponent<Text>();
            MenuText.text = "Press n To Begin";
            MenuText.fontStyle = FontStyle.Bold;
            MenuText.font = arial;
            MenuText.fontSize = 70;
            MenuText.alignment = TextAnchor.MiddleCenter;
            MenuText.color = Color.white;

            Canvas canvas1 = MenuTextParent.GetComponent<Canvas>();
            canvas1.renderMode = RenderMode.ScreenSpaceOverlay;


            // Provide Text position and size using RectTransform.
            rectTransform = MenuText.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, 0, 10);
            rectTransform.sizeDelta = new Vector2(500, 300);

        






    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Destroy(GameObject.Find("MenuBG"));
            Destroy(GameObject.Find("Menu"));
            Destroy(GameObject.Find("StartMenu"));
            Destroy(GameObject.Find("MenuTextParent"));
            createGameEnv();
            startGame();

        }
    }

    void createGameEnv()
    {
        //GAME BACKGROUND//
        GameObject GameEnv = new GameObject();
        GameEnv.name = "Game Environment";
        GameEnv.AddComponent<Image>(); ;
        GameEnv.AddComponent<Canvas>(); ;
        GameEnv.AddComponent<CanvasScaler>(); ;
        GameEnv.AddComponent<GraphicRaycaster>();

        Background = GameEnv.GetComponent<Image>();
        Background.color = GameEnvcolour;

        rectTransform = GameEnv.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 700);
        rectTransform.sizeDelta = new Vector2(640, 960);


        //PLAYER 1 MENU//

      // waitforyDown();


    }

    void startGame()
    {
        GameObject controller = new GameObject();
        controller.name = "controller";
        controller.AddComponent<controller>();
        controller.AddComponent<humanPlayerClass>();
    }

    IEnumerator waitforyDown()
    {
        while (!Input.GetMouseButtonDown(0))
        {
            //     Debug.Log("null");

            yield return null;


        }

       yield return null;


    }
}
