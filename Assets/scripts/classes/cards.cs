using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cards : MonoBehaviour {

    public class card
    {
        public int cardId;
        public string cardName;
        public int appearances;
        public int goals;
        public int assists;
        public int teams;
        public int premsWon;
        public int bookings;


        public card(int id, string name, int apps, int gls, int ass, int tms, int prems, int bkngs)
        {
            cardId = id;
            cardName = name;
            appearances = apps;
            goals = gls;
            assists = ass;
            teams = tms;
            premsWon = prems;
            bookings = bkngs;
        }
    }



    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
