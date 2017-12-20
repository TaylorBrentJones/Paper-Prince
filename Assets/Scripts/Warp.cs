using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Warp : MonoBehaviour {

	public Transform warpTarget;

	IEnumerator OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.tag == "Player") {
			screenFader sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<screenFader> ();

			yield return StartCoroutine (sf.FadeToBlack ());

			other.gameObject.transform.position = warpTarget.position;
			Camera.main.transform.position = warpTarget.position;

			yield return StartCoroutine (sf.FadeToClear ());
		}
	}
}
