﻿using UnityEngine;
using System.Collections;

public class hazard : MonoBehaviour {
	bool isGrabbed = false, isFlying = false, walk =false;
	float walkVel;
	Vector2 startPoint;
	public float speed=1.0f, gravity=1.0f;
	public Transform player1;

	void Start () {
		walk = false;
		startPoint = transform.position;
		ResetPosition();
		rigidbody2D.gravityScale = 0;

	}


	void ResetPosition(){
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.gravityScale = 0;
		walk = false;
		isGrabbed = false;
		isFlying = false;
		this.transform.position = startPoint;
	}

	void FixedUpdate(){
		if (walk) {
		
			if(walkVel>0){
				transform.localScale = new Vector3(-30,30,30);
				rigidbody2D.velocity = new Vector2 (speed,rigidbody2D.velocity.y-gravity);
			}
			else{
				transform.localScale = new Vector3(30,30,30);
				rigidbody2D.velocity = new Vector2 (-speed,rigidbody2D.velocity.y-gravity);
			}
		}

		if(isGrabbed){ //moves the skeleton along with the mouse
			Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			worldPosition.z = 0;
			this.transform.position = worldPosition;
		}
		if(isFlying)
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x,rigidbody2D.velocity.y-gravity);

		if (rigidbody2D.position.y < -50) {
			ResetPosition ();
		}
	}
	
	void OnMouseDown(){
		isGrabbed = true;
		isFlying = false;
		walk = false;
		this.collider2D.enabled = false;
	}
	
	void OnMouseUp(){

		if(isGrabbed){
			if(Vector2.Distance(player1.position, this.transform.position)<5){
				this.transform.position = player1.position + new Vector3(5, 0, 0);
			}

			isGrabbed = false;
			isFlying = true;
			this.collider2D.enabled = true;
			walkVel = (player1.position.x)-this.transform.position.x;
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll){

		if (coll.gameObject.name != "Player1") {
			walk = true;
		}
			
	}
}

