using UnityEngine;
using System.Collections;

public class MenuControlleur : MonoBehaviour {

	public void StartGame()
	{
		PlayerPrefs.SetInt ("Lvl", 0);
		PlayerPrefs.Save ();
		Application.LoadLevel("ProtoA");
	}

	public void StartGameMed()
	{
		PlayerPrefs.SetInt ("Lvl", 1);
		PlayerPrefs.Save ();
		Application.LoadLevel("ProtoA");
	}

	public void StartGameHard()
	{
		PlayerPrefs.SetInt ("Lvl", 2);
		PlayerPrefs.Save ();
		Application.LoadLevel("ProtoA");
	}

	public void StartGameExp()
	{		
		PlayerPrefs.SetInt ("Lvl", 3);
		PlayerPrefs.Save ();
		Application.LoadLevel("ProtoA");
	}

	public void SelectDifficulty()
	{
		Application.LoadLevel("SelectDifficulty");
	}

	public void BackToTheMenu()
	{
		Application.LoadLevel("Menu");
	}

	public void CustomDrum()
	{
		Application.LoadLevel("CustomizeAudioButtonsSlots");
	}


	public void SelectChar()
	{
		Application.LoadLevel("SelectCharac");
	}

	public void ExitGame()
	{
		Application.Quit ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
