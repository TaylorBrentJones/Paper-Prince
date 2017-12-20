using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb;
	private Animator anim;
	private bool attacking;
	public float attackTime;
	private float attackTimeCounter;

	public Collider2D weapon;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!attacking) {
			Vector2 movement_vector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

			if (movement_vector != Vector2.zero) {
				anim.SetBool ("iswalking", true);
				anim.SetFloat ("Input_x", movement_vector.x);
				anim.SetFloat ("Input_y", movement_vector.y);
			} else {
				anim.SetBool ("iswalking", false);
			}	
		
	
			speed = 1f;

			if (Input.GetKey (KeyCode.LeftShift)) {
				speed = 2f;
			}
			
			rb.MovePosition (rb.position + movement_vector * Time.deltaTime * speed);
		}
		if (Input.GetButtonDown ("Attack")) {
			weapon.enabled = true;
			attackTimeCounter = attackTime;
			attacking = true;
			rb.velocity = Vector2.zero;
			anim.SetBool ("isattacking", true);
		}
		if(attackTimeCounter > 0)
		{
			weapon.enabled = true;
			attackTimeCounter -= Time.deltaTime;
		}
		if(attackTimeCounter <= 0)
		{
			weapon.enabled = false;
			attacking = false;
			anim.SetBool ("isattacking", false);
		}
	}
}
