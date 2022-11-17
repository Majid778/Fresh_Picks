using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelControl : MonoBehaviour
{
	public Button level02Button, level03Button, level04Button, level05Button;
	public TextMeshProUGUI theText1, theText2, theText3, theText4, theText5;
	int levelPassed;
	int score1 = 1;
	int score2 = 2;
	int score3 = 3;
	int score4 = 4;
	int score5 = 5;

	// Use this for initialization
	void Start()
	{
		//PlayerPrefs.SetInt("LevelPassed", 0);
		levelPassed = PlayerPrefs.GetInt("LevelPassed");
		level02Button.interactable = false;
		level03Button.interactable = false;
		level04Button.interactable = false;
		level05Button.interactable = false;
		theText1.text = PlayerPrefs.GetInt(score1.ToString()).ToString() + "/5";
		theText2.text = PlayerPrefs.GetInt(score2.ToString()).ToString() + "/5";
		theText3.text = PlayerPrefs.GetInt(score3.ToString()).ToString() + "/5";
		theText4.text = PlayerPrefs.GetInt(score4.ToString()).ToString() + "/5";
		theText5.text = PlayerPrefs.GetInt(score5.ToString()).ToString() + "/5";
		switch (levelPassed)
		{
			case 0:
				break;
			case 1:
				level02Button.interactable = true;
				break;
			case 2:
				level02Button.interactable = true;
				level03Button.interactable = true;
				break;
			case 3:
				level02Button.interactable = true;
				level03Button.interactable = true;
				level04Button.interactable = true;
				break;
			case 4:
				level02Button.interactable = true;
				level03Button.interactable = true;
				level04Button.interactable = true;
				level05Button.interactable = true;
				break;
			default:
				level02Button.interactable = true;
				level03Button.interactable = true;
				level04Button.interactable = true;
				level05Button.interactable = true;
				break;
		}
	}

	public void levelToLoad(int level)
	{
		SceneManager.LoadScene(level);
	}

	public void resetPlayerPrefs()
	{
		level02Button.interactable = false;
		level03Button.interactable = false;
		level04Button.interactable = false;
		level05Button.interactable = false;
		PlayerPrefs.DeleteAll();
	}
}
