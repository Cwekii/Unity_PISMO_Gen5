using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneName : MonoBehaviour
{
    public string imeScene;
	
	public void UcitajPoImenu()
	{
		SceneManager.LoadScene(imeScene);
	}
}
