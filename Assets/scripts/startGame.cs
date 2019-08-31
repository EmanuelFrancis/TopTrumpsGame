using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        controller.GameBG = new GameObject(); /* Creates a parent humanPlayer GO */
        controller.GameBG.name = "PlayerBarGO";  /* Names the parent humanPlayer GO */
        controller.GameBG.AddComponent<Canvas>();
        controller.GameBG.AddComponent<CanvasScaler>();
        controller.GameBG.AddComponent<GraphicRaycaster>();
        controller.GameBG.AddComponent<playerInfoBar>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
