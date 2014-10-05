﻿using UnityEngine;
using System.Collections;

public class hazard : MonoBehaviour {
	bool isGrabbed = false;
	bool isFlying = false;
	bool walk;
	float walkVel;
	Vector2 startPoint;
	public int speed;
	public int gravity;
	public Transform player1;
	
	void Start () {
		<<<<<<< HEAD
			startPoint = new Vector3(55, 2,1);
		offset = player1.transform.position-startPoint;
		=======
			>>>>>>> origin/master
				walk = false;
		startPoint = transform.position;
		ResetPosition();
		<<<<<<< HEAD
			=======
				
				>>>>>>> origin/master
	}
	
	
	void ResetPosition(){
		this.transform.position = startPoint;
		rigidbody2D.velocity = Vector2.zero;
		walk = false;
		//this.rigidbody2D.gravityScale = 0;
		isGrabbed = false;
		isFlying = false;
		<<<<<<< HEAD
			
			transform.position = player1.transform.position- offset;
		transform.localScale = new Vector3(25,25,0);
		=======
			>>>>>>> origin/master
	}
	
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.R)){
			this.isGrabbed = false;
			this.isFlying = false;
			this.rigidbody2D.velocity = Vector2.zero;
			ResetPosition();
		}
	}
	
	void FixedUpdate(){
		if (!walk && !Physics2D.Raycast(transform.position, (0,-1), rigidbody2D.velocity.y +5 )) {
			isFlying=false;
		}
		
		if (walk) {
			<<<<<<< HEAD
				=======
					
					>>>>>>> origin/master
		if(walkVel>0){
				transform.localScale = new Vector3(-30,30,30);
			}else{
				transform.localScale = new Vector3(30,30,30);
			}
			rigidbody2D.velocity = new Vector2 (speed*walkVel,rigidbody2D.velocity.y);
			
			
			
		}
		
		if(isGrabbed){
			Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			worldPosition.z = 0;
			//Debug.Log ("World Position: " + worldPosition.ToString());
			this.transform.position = worldPosition;
		}
		<<<<<<< HEAD
		if (isFlying) {
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, rigidbody2D.velocity.y - gravity);
			transform.localScale = new Vector3(35,35,0);
		}
		
		
		if (rigidbody2D.position.y < -500) {
			ResetPosition ();
		}
		
		=======
			if(isFlying)
				rigidbody2D.velocity = new Vector2 (speed*walkVel,-gravity);
		
		>>>>>>> origin/master
			
			//if(!isFlying){
			//	this.rigidbody2D.gravityScale = 0;
			//} else {
			//	this.rigidbody2D.gravityScale = gravity;
			
			//}
			
			
	}
	
	void OnMouseDown(){
		isGrabbed = true;
		isFlying = false;
		this.collider2D.enabled = false;
		rigidbody2D.velocity = Vector2.zero;
		walk = false;
	}
	
	void OnMouseUp(){
		if(isGrabbed){
			if(Vector2.Distance(player1.position, this.transform.position)<5){
				this.transform.position = player1.position + new Vector3(5, 0, 0);
			}
			
			isGrabbed = false;
			isFlying = true;
			rigidbody2D.velocity = new Vector2(0,0);
			this.collider2D.enabled = true;
			walkVel = (player1.position.x)-this.transform.position.x;
			walkVel /= Mathf.Abs(walkVel);
			
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll){
		
		if (coll.gameObject.name != "Player1") {
			walk = true;
			isFlying=false;
		}
		
	}
}

