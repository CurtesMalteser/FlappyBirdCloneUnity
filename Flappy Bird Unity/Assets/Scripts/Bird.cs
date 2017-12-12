using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	public float upForce = 200f; //Upward force of the "flap".
	private bool isDead = false; //Has the player collided with a wall?

	private Rigidbody2D rb2d; 
	private Animator anim;

	// Use this for initialization
	void Start () {

		//Get and store a reference to the Rigidbody2D attached to this GameObject.
		rb2d = GetComponent< Rigidbody2D > (); 
		anim = GetComponent< Animator > ();

	}
	
	// Update is called once per frame
	void Update () {
		//Don't allow control if the bird has died.
		if ( isDead == false ) 
		{
			
			//Look for input to trigger a "flap".
			if (Input.GetMouseButtonDown (0)) {
				
				//...tell the animator about it and then...



				rb2d.velocity = Vector2.zero;
				rb2d.AddForce (new Vector2 (0, upForce));
				anim.SetTrigger ("Flap");
			}

			}
		}

		
	void OnCollisionEnter2D () {

		rb2d.velocity = Vector2.zero;
		isDead = true;
		anim.SetTrigger ("Die");
		GameControl.instance.BirdDied ();

	}

}