using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
	public void LoadSceneinGame()
	{
		SceneManager.LoadScene("seleccionCarro");
	}
	public void LoadSceneinGame1()
	{
		SceneManager.LoadScene("SampleScene");
	}
	public void LoadSceneinGame2()
	{
		SceneManager.LoadScene("seleccionMapa");
	}
	public void BackSceneinGame1()
	{
		SceneManager.LoadScene("Interfaz");
	}
	public void BackSceneinGame2()
	{
		SceneManager.LoadScene("seleccionCarro");
	}
}	
