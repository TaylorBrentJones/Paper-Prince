using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Slider healthBar;
	public Text HPText;
	public PlayerHealthManager playerHealth;

	private PlayerStats thePS;
	public Text levelText;

	// Use this for initialization
	void Start () {
		thePS = GetComponent<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.maxValue = playerHealth.playerMaxHealth;
		healthBar.value = playerHealth.playerCurrentHealth;
		HPText.text = "HP: " + healthBar.value + " / " + healthBar.maxValue;
		levelText.text = "Lvl: " + thePS.currentLevel;
	}
}
