using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public int currentLevel;

	public int currentEXP;

	public int[] toLevelUp;

	public int[] HPLevels;
	public int[] attackLevels;
	public int[] defenceLevels;

	public int currentHP;
	public int currentAttack;
	public int currentDefence;

	private PlayerHealthManager thePlayerHealth;

	// Use this for initialization
	void Start () {
		currentHP = HPLevels [1];
		currentAttack = attackLevels [1];
		currentDefence = defenceLevels [1];

		thePlayerHealth = FindObjectOfType<PlayerHealthManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(currentEXP >= toLevelUp[currentLevel])
		{
			//currentLevel++;

			LevelUp ();
		}
	}

	public void AddExperience (int experienceToAdd)
	{
		currentEXP += experienceToAdd;
	}

	public void LevelUp ()
	{
		currentLevel++;
		currentHP = HPLevels [currentLevel];

		thePlayerHealth.playerMaxHealth = currentHP;
		thePlayerHealth.playerCurrentHealth = currentHP;

		currentAttack = attackLevels [currentLevel];
		currentDefence = defenceLevels [currentLevel];
	}
}
