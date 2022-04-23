using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class MainMenu : MonoBehaviour
{
	public HighScore highScore;
	public TextMeshProUGUI highScoreValue;
	public GameObject highScoreMenu;

	string fpath;

    public void StartGame()
	{
		//  fpath = Application.persistentDataPath+"/score.txt";

		//  StreamReader sr = File.OpenText(fpath);

		// SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		SceneManager.LoadScene("Game");

	}
	
	public void QuitGame()
	{
		Application.Quit();
	}

	public void backtomenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

	public void OpenHighScore()
	{
		Debug.Log("open");
		SceneManager.LoadScene("HighScore");
		// highScoreMenu.SetActive(true);
		// highScoreValue.text = highScore.highScore.ToString();
	}

	public void CloseHighScore()
	{
		Debug.Log("close");
		highScoreMenu.SetActive(false);
	}

	public void ResetHighScore()
	{
		highScore.highScore = 0;
		highScoreValue.text = highScore.highScore.ToString();
	}

}
