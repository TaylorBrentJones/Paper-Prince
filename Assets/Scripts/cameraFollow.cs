using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

	public Transform player;

	private Camera mycam;

	// Use this for initialization
	void Start () {
	
		mycam = GetComponent<Camera> ();

	}

	// Update is called once per frame
	void Update () {
	
		mycam.orthographicSize = (Screen.height / 100f) / 2f;

		if (player) {

			transform.position = Vector3.Lerp (transform.position, player.position, 0.1f) + new Vector3 (0, 0, -1);

		}
	
	}
}
