using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BallBehavior : MonoBehaviour {

	public int ballSpeed;

	private Vector2 startMovement;
	private Rigidbody2D rgbd2D;

	public Text playerOneScoreTxt, playerTwoScoreTxt;
	private int playerOneScore, playerTwoScore;

	// Use this for initialization
	void Start () {
	
		rgbd2D = GetComponent<Rigidbody2D> ();
		StartCoroutine(StartGame ());
		//StartGame ();
	}
		
	IEnumerator StartGame(){

		//restart values of position and velocity
		transform.position = new Vector2 (0, 0);
		rgbd2D.velocity = Vector2.zero;

		//launch ball
		yield return new WaitForSeconds (1.5f);
		startMovement = new Vector2 (Random.Range(-1f,1f), Random.Range(-1f,1f));
		rgbd2D.AddForce (startMovement * ballSpeed, ForceMode2D.Impulse);
		
	}

	void OnCollisionEnter2D(Collision2D collider){
		if (collider.gameObject.tag == "Player") {
			rgbd2D.velocity *= 1.1f;
			Debug.Log (rgbd2D.velocity);
		}

		if (collider.gameObject.tag == "Wall Points") {
			if (transform.position.x > 0) {
				playerOneScore++;
				playerOneScoreTxt.text = playerOneScore.ToString ();
				StartCoroutine(StartGame ());
			} else {
				playerTwoScore++;
				playerTwoScoreTxt.text = playerTwoScore.ToString ();
				StartCoroutine(StartGame ());
			}
		}
	}
}
