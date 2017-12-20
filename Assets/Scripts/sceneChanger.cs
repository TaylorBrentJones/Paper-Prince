using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class sceneChanger : MonoBehaviour {

	public void MainGame(){ 
		SceneManager.LoadScene ("Paper Prince");
	}
	public void Inventory(){ 
		SceneManager.LoadScene ("Inventory", LoadSceneMode.Additive);
	}
	public void MainMenu(){ 
		SceneManager.LoadScene ("Menu");
	}
}
