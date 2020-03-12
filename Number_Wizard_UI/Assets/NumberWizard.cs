using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour {

	int guess;
	[SerializeField] int max;
	[SerializeField] int min;
	[SerializeField] TextMeshProUGUI guessText;
 

	

	// Use this for initialization
	void Start () 
	{ 
		StartGame();
		Debug.Log(guess);
	}
	
	void StartGame()
	{
		NextGuess();
	}


	public void OnPressHigher()
	{
		if(min == 1000 || guess == 1000)
		{
			min = guess;
		} else min = guess + 1;
		NextGuess();
	}

	public void OnPressLower()
	{
		max = guess - 1;
		NextGuess();
	}
	void NextGuess()
	{
		guess = Random.Range(min, max + 1);
		Debug.Log("LOL, maybe that's your number? " + guess); //Debuging
		guessText.text = guess.ToString();
	}

}
