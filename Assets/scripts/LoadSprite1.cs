using UnityEngine.UI;
using UnityEngine;

public class LoadSprite1 : MonoBehaviour
{

    Sprite sprite1;
    public static Canvas canvas1;
    // Use this for initialization
    void Start()
    {
        playerHands.sprite.Add(Resources.Load<Sprite>("test_" + loadPlayer1Card.SelectCardId));// = Resources.Load<Sprite>("test_" + SelectCardId);

     //   Debug.Log("test_" + loadPlayer1Card.SelectCardId);


        GameObject sprite01 = new GameObject();
        sprite01.name = "P1SpriteParent";
    //    sprite01.transform.parent = controller.playerInstance01.transform;
        GameObject image = (GameObject)Instantiate(sprite01);
        image.name = "P1imageSpriteInstance";
        image = GameObject.Find("ImageP1");
      //  image.transform.parent = sprite01.transform;

        image.GetComponent<Image>().sprite = playerHands.sprite[playerHands.sprite.Count - 1];

  
        canvas1 = GameObject.Find("ImageP1").GetComponent<Canvas>();
        canvas1.renderMode = RenderMode.ScreenSpaceOverlay;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
