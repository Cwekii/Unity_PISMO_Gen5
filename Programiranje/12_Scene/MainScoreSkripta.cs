using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScoreSkripta : MonoBehaviour
{
    public string imeSceneKojaJeAktivna;
	public string imeSceneKojaJeAktivna2;
	public float bzvz;
	
	void Start()
	{
		imeSceneKojaJeAktivna = SceneManager.GetActiveScene().name;
		DontDestroyOnLoad(this.gameObject);
	}
	
	void Update()
	{
		bzvz += Time.deltaTime;
		imeSceneKojaJeAktivna2 = SceneManager.GetActiveScene().name;
	}
}
