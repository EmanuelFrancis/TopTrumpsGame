using UnityEngine.UI;
using UnityEngine;

public class LoadCardBottom : MonoBehaviour
{

    Sprite sprite2;
    public static Canvas canvas2;
    // Use this for initialization
    void Start()
    {
        playerHands.sprite.Add(Resources.Load<Sprite>("CardDesignBottom"));// = Resources.Load<Sprite>("test_" + SelectCardId);

        //   Debug.Log("test_" + loadPlayer1Card.SelectCardId);


        GameObject sprite02 = new GameObject();
        sprite02.name = "P1SpriteCardBottom";
        //    sprite01.transform.parent = controller.playerInstance01.transform;
        GameObject image = (GameObject)Instantiate(sprite02);
        image.name = "P1imageCardBottomInstance";
        image = GameObject.Find("ImageCardBottomP1");
        //  image.transform.parent = sprite01.transform;

        image.GetComponent<Image>().sprite = playerHands.sprite[playerHands.sprite.Count - 1];


        canvas2 = GameObject.Find("ImageCardBottomP1").GetComponent<Canvas>();
        canvas2.renderMode = RenderMode.ScreenSpaceOverlay;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
