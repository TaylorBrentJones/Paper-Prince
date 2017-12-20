using UnityEngine;
using System.Collections;

public class HurtEnemy : MonoBehaviour {

	public int damageToGive;
	private int currentDamage;
	public GameObject damageBurst;
	public GameObject damageNumber;

	private PlayerStats thePS;

	// Use this for initialization
	void Start () {
		thePS = FindObjectOfType<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if(other.gameObject.tag == "Slime")
		{
			currentDamage = damageToGive + thePS.currentAttack;

			//Destroy (other.gameObject);
			other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDamage);
			Instantiate (damageBurst, other.transform.position, other.transform.rotation);
			var clone = (GameObject) Instantiate (damageNumber, other.transform.position, Quaternion.Euler (Vector3.zero));
			clone.GetComponent<FloatingNumbers> ().damageNumber = currentDamage;

		}
	}
}
