using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	private static int currentPlayer = 0;
	private static int maxPlayers = 4;
	private static int shots = 5;

	public static void Shoot() {
		shots--;
		if (shots <= 0) {
			Game.SetNextPlayer ();
			shots = 5;
		}
	}

	public static void SetNextPlayer() {
		currentPlayer = (currentPlayer + 1) % maxPlayers;

		for(int i = 0; i < maxPlayers; i++) {
			GameObject.Find("Camera " + (i+1)).camera.depth = (i == currentPlayer? 1:0);
			print ("asdf" + GameObject.Find("Camera " + (currentPlayer+1)).camera.depth);
		}
	}

	public static int GetCurrentPlayer() {
		return currentPlayer + 1;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI() {
		int[] playerScores = {0, 0, 0, 0};

		playerScores[0] = GameObject.FindGameObjectsWithTag("Player 1").Length;
		playerScores[1] = GameObject.FindGameObjectsWithTag("Player 2").Length;
		playerScores[2] = GameObject.FindGameObjectsWithTag("Player 3").Length;
		playerScores[3] = GameObject.FindGameObjectsWithTag("Player 4").Length;

		GUI.BeginGroup (new Rect (Screen.width - 200, 0, 200, 200));
		{
			GUI.Label(new Rect(0, 0, 200, 20), "Scores:");
			GUI.Label(new Rect(20, 20, 180, 20), "Player 1: " + playerScores[0]);
			GUI.Label(new Rect(20, 40, 180, 20), "Player 2: " + playerScores[1]);
			GUI.Label(new Rect(20, 60, 180, 20), "Player 3: " + playerScores[2]);
			GUI.Label(new Rect(20, 80, 180, 20), "Player 4: " + playerScores[3]);
		}
		GUI.EndGroup ();
	}
}
