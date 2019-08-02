using UnityEngine.UI;
using UnityEngine;

public class LoadSprite2 : MonoBehaviour
{

    Sprite sprite3;
    public static Canvas canvas3;
    // Use this for initialization
    void Start()
    {
        playerHands.sprite.Add(Resources.Load<Sprite>("test_" + loadPlayer2Card.SelectCardId));// = Resources.Load<Sprite>("test_" + SelectCardId);

        //   Debug.Log("test_" + loadPlayer1Card.SelectCardId);


        GameObject sprite03 = new GameObject();
        sprite03.name = "P2SpriteParent";
        GameObject image2 = (GameObject)Instantiate(sprite03);
        image2.name = "P2imageSpriteInstance";
        image2 = GameObject.Find("ImageP2");

        image2.GetComponent<Image>().sprite = playerHands.sprite[playerHands.sprite.Count - 1];


        canvas3 = GameObject.Find("ImageP2").GetComponent<Canvas>();
        canvas3.renderMode = RenderMode.ScreenSpaceOverlay;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
