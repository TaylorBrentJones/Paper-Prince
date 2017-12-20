using UnityEngine;
using System.Collections;

public class SlimeController : MonoBehaviour {

	public float moveSpeed;
	private Rigidbody2D myRigidbody;
	private bool moving;
	public float timeBetweenMove;
	public float timeToMove;
	private Vector3 moveDirection;
	private float timeBetweenMoveCounter;
	private float timeToMoveCounter;
	public float waitToReload;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
//		timeBetweenMoveCounter = timeBetweenMove;
//		timeToMoveCounter = timeToMove;

		timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeToMove * 1.25f);
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) 
		{
			timeToMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = moveDirection;
			if(timeToMoveCounter < 0f)
			{
				moving = false;
				//timeBetweenMoveCounter = timeBetweenMove;
				timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
			}

		} else {
			timeBetweenMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = Vector2.zero;

			if(timeBetweenMoveCounter < 0f)
			{
				moving = true;
				//timeToMoveCounter = timeToMove;
				timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeToMove * 1.25f);
				moveDirection = new Vector3 (Random.Range (-1f, 1f) * moveSpeed, Random.Range (-1f, 1f) * moveSpeed, 0f);
			}
		}

	}

}
