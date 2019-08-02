using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	// Use this for initialization
	void Start () {

       // StartCoroutine (BlinkTimer ());

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator BlinkTimer()
    {
        yield return new WaitForSeconds(3);

        loadPlayer1Card.attributesBoxColour = 3;

        StartCoroutine(BlinkTimer2());
           
    }

    IEnumerator BlinkTimer2()
    {
        yield return new WaitForSeconds(3);

        loadPlayer1Card.attributesBoxColour = 0;

        StartCoroutine(BlinkTimer());

    }


}
