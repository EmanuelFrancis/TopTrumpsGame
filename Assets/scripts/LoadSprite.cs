using UnityEngine.UI;
using UnityEngine;

public class LoadSprite : MonoBehaviour {

    public static int playerIDInt2;
    public static int CardIDInt;
    string CardIdString = CardIDInt.ToString(); //converts current card id to a string


    Sprite sprite000;
    public static Canvas canvas000;
    Sprite sprite0;
    public static Canvas canvas0;
    Sprite sprite1;
    public static Canvas canvas1;
    public static Canvas canvas2;
    // Use this for initialization
    void Start()
    {

        playerHands.sprite.Add(Resources.Load<Sprite>("test_" + CardIdString));// = Resources.Load<Sprite>("test_" + SelectCardId);

        //   Debug.Log("test_" + loadPlayer1Card.SelectCardId);





    //    if (controller.ActivePlayer == 1)
   //     {

 


            GameObject sprite01 = new GameObject();
            sprite01.name = "P"+ playerIDInt2 + "SpriteParent";
            //    sprite01.transform.parent = controller.playerInstance01.transform;
            GameObject image = (GameObject)Instantiate(sprite01);
            image.name = "P"+ playerIDInt2 + "imageSpriteInstance";
            image = GameObject.Find("ImageP"+ playerIDInt2);
        //  image.transform.parent = sprite01.transform;

        image.GetComponent<Image>().sprite = playerHands.sprite[playerHands.sprite.Count - 1];


            canvas1 = GameObject.Find("ImageP"+ playerIDInt2).GetComponent<Canvas>();
            canvas1.renderMode = RenderMode.ScreenSpaceOverlay;

        if (playerIDInt2 == 1)
        {
            playerIDInt2 = 2;
        }
        //  }
        //  else
        //  {


        
/*

            GameObject sprite02 = new GameObject();
            sprite02.name = "P2SpriteParent";
            //    sprite01.transform.parent = controller.playerInstance01.transform;
            GameObject image2 = (GameObject)Instantiate(sprite02);
            image2.name = "P2imageSpriteInstance";
            image2 = GameObject.Find("ImageP2");
            //  image.transform.parent = sprite01.transform;

  //          image2.GetComponent<Image>().sprite = playerHands.sprite[playerHands.sprite.Count - 1];
            image2.GetComponent<Image>().sprite = playerHands.sprite[0];


            canvas2 = GameObject.Find("ImageP2").GetComponent<Canvas>();
            canvas2.renderMode = RenderMode.ScreenSpaceOverlay;  */
        //  }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
