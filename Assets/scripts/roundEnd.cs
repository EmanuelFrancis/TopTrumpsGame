using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roundEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
 
        Debug.Log("round end");
        
        controller.game.AddComponent<winnerScreen>();
 
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void destroyObjects()
    {
        //   Destroy(GameObject.Find("update bars2"));
        //     Destroy(GameObject.Find("ChosenAttr"));
        //    Destroy(GameObject.Find("ChosenValue"));
        //     Destroy(GameObject.Find("Chosen2Attr"));
        //    Destroy(GameObject.Find("Chosen2Value"));
        //  Destroy(GameObject.Find("no cards in hand"));
        //   Destroy(GameObject.Find("placeInDeck"));
        //    Destroy(GameObject.Find("WinParent"));
        //    Destroy(GameObject.Find("WinBox"));
        Destroy(GameObject.Find("p1MainCard"));
        Destroy(GameObject.Find("p2MainCard"));

        Destroy(GameObject.Find("P1ParentCard"));
        Destroy(GameObject.Find("P2ParentCard"));

        //     Destroy(GameObject.Find("P2ParentCard"));
        Destroy(GameObject.Find("P1imageSpriteInstance"));
        Destroy(GameObject.Find("P1SpriteParent"));
        Destroy(GameObject.Find("P2imageSpriteInstance"));
        Destroy(GameObject.Find("P2SpriteParent"));
        //
        //    Destroy(GameObject.Find("P1imageBGSpriteInstance"));
        //     Destroy(GameObject.Find("P1SpriteBG"));
        //    Destroy(GameObject.Find("P2imageBGSpriteInstance"));
        //    Destroy(GameObject.Find("P2SpriteBG"));

        //     Destroy(GameObject.Find("p1MainCard"));
        //     Destroy(GameObject.Find("p2MainCard"));

        //    Destroy(GameObject.Find("winnerBGParent"));
        //    Destroy(GameObject.Find("textBoxWin"));
        //   Destroy(GameObject.Find("HUMANWinTextGO"));

        //  Destroy(GameObject.Find("P1Bar"));
        //  Destroy(GameObject.Find("P2Bar"));
        //   Destroy(GameObject.Find("PlayerBarParent"));
        //   Destroy(GameObject.Find("HUMANPLAYERNAME"));


    }
}
