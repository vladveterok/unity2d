using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour {

	int max;
	int min;		
	int guess;

	// Use this for initialization
	void Start () 
	{ 
		StartGame();
		
	}
	
	void StartGame()
	{
		max = 1000;
		min = 1;
		guess = 500;

		Debug.Log("Welcome my tiny friend to my number wizard game");
		Debug.Log("Please, be free to  pick a number, but remember the rules, my little friend:");
		Debug.Log("The highest number you can pic is: " + max);
		Debug.Log("The lowest number you can pic is: " + min);
		Debug.Log("Already came up with a number? Good, good."); 
		Debug.Log("Tell me if your number is higher or lower than " + guess);
		Debug.Log("Push Up = your number is higher, Push Down = your number is lower, Push Enter = correct");

		max = max + 1;
	}

	// Update is called once per frame
	void Update () 
	{
		
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			min = guess;
			NextGuess();
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			max = guess;
			NextGuess();
		}
		else if (Input.GetKeyDown(KeyCode.Return))
		{
			Debug.Log("Fuck yeah, I knew it!!1 Fuck off you go and call the next one!");
			StartGame();
		}

	}

	void NextGuess()
	{
		guess = (max + min) / 2;
		Debug.Log("LOL, maybe that's your number? " + guess);
	}

}
