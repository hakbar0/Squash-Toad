using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	
	public void LoadNextScene ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
		
	public void Replay ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}


	public void Quit ()
	{
		Application.Quit ();
	}

}
