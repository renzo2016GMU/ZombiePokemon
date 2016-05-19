using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public static int score;        // The player's score.
    Text text;                      // Reference to the Text component.

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();

        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Score: " + score;
	}
}
