using UnityEngine.UI;
using UnityEngine;

public class LoadBackground : MonoBehaviour
{


    public static int playerIDInt;


    Sprite sprite0;
 //   Sprite sprite000;
    //public static Canvas canvas0;
    public static Canvas canvas4;
 //   public static Canvas canvas5;
    // Use this for initialization
    void Start()
    {
        playerHands.sprite.Add(Resources.Load<Sprite>("CardDesignFront"));// = Resources.Load<Sprite>("test_" + SelectCardId);
    //    playerHands.sprite.Add(Resources.Load<Sprite>("CardDesignFront"));// = Resources.Load<Sprite>("test_" + SelectCardId);
        //   Debug.Log("test_" + loadPlayer1Card.SelectCardId);

/*
        GameObject sprite00 = new GameObject();
        sprite00.name = "P"+controller.ActivePlayer+"SpriteBG";
        //    sprite01.transform.parent = controller.playerInstance01.transform;
        GameObject image = (GameObject)Instantiate(sprite00);
        image.name = "P"+controller.ActivePlayer+"imageBGSpriteInstance";
        image = GameObject.Find("ImageBackgroundP"+controller.ActivePlayer);
        //  image.transform.parent = sprite01.transform;

        image.GetComponent<Image>().sprite = playerHands.sprite[playerHands.sprite.Count - 1];
        */

       // if(controller.ActivePlayer == 1)
     //   {
            GameObject sprite00 = new GameObject();
            sprite00.name = "P" + playerIDInt + "SpriteBG";
            //    sprite01.transform.parent = controller.playerInstance01.transform;
            GameObject image = (GameObject)Instantiate(sprite00);
            image.name = "P" + playerIDInt + "imageBGSpriteInstance";
            image = GameObject.Find("ImageBackgroundP" + playerIDInt);
        //  image.transform.parent = sprite01.transform;
   //     Debug.Log("Load BG p1 active player = " + playerIDInt);
        image.GetComponent<Image>().sprite = playerHands.sprite[playerHands.sprite.Count - 1];

            canvas4 = GameObject.Find("ImageBackgroundP" + playerIDInt).GetComponent<Canvas>();
            canvas4.renderMode = RenderMode.ScreenSpaceOverlay;

        if(playerIDInt == 1)
        {
            playerIDInt = 2;
        }

  //          Debug.Log("Load BG p1 active player = " + controller.ActivePlayer);
            //   }
            //   else if (controller.ActivePlayer == 2)
            //   {
            /*
                   GameObject sprite000 = new GameObject();
                   sprite000.name = "P2SpriteBG";
                   //    sprite01.transform.parent = controller.playerInstance01.transform;
                   GameObject image2 = (GameObject)Instantiate(sprite000);
                   image2.name = "P2imageBGSpriteInstance";
                   image2 = GameObject.Find("ImageBackgroundP2");
                   //  image.transform.parent = sprite01.transform;

                   image2.GetComponent<Image>().sprite = playerHands.sprite[playerHands.sprite.Count - 1];

                   canvas5 = GameObject.Find("ImageBackgroundP2").GetComponent<Canvas>();
                   canvas5.renderMode = RenderMode.ScreenSpaceOverlay;
                   Debug.Log("Load BG p2 active player = " + controller.ActivePlayer); */
    //   }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
