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




    // Use this for initialization
    void Start () {

        GameObject MenuBG = new GameObject();
        MenuBG.name = "MenuBG";
       // MenuBG.transform.SetParent(Star)
        MenuBG.AddComponent<Image>(); ;
        MenuBG.AddComponent<Canvas>(); ;
        MenuBG.AddComponent<CanvasScaler>(); ;
        MenuBG.AddComponent<GraphicRaycaster>();

        Background = MenuBG.GetComponent<Image>();
        Background.color = MenuBGcolour;

        rectTransform = MenuBG.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 700);
        rectTransform.sizeDelta = new Vector2(640, 960);


        


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {

            Destroy(GameObject.Find("StartMenu"));
            startGame();

        }
    }

    void startGame()
    {
        GameObject controller = new GameObject();
        controller.name = "controller";
        controller.AddComponent<controller>();
        controller.AddComponent<humanPlayerClass>();
    }
}
