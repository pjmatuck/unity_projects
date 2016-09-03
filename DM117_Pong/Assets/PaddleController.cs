using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {

	private float moveVertical;

	public int paddleSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		moveVertical = Input.GetAxis ("Vertical");

		transform.Translate (0, moveVertical * paddleSpeed * Time.deltaTime, 0);
	
	}
}
