﻿using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour {
	bool isAlive = true, win=false;
	void ResetPosition(){
		gameObject.SetActive(true);
		transform.position = startPoint;
		rigidbody2D.velocity = Vector2.zero;
	}

	void OnGUI() {
		if (!isAlive) {
			GUI.Box (new Rect (Screen.width/2 - 250, Screen.height/2 - 50, 500, 100), "Player 2 Wins!");

			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if(GUI.Button(new Rect(Screen.width/2 - 40,Screen.height/2 - 10,80,40), "(R)estart")) {
				Application.LoadLevel(Application.loadedLevel);
			}
			renderer.enabled = false;
		}
		if (win) {
			GUI.Box (new Rect (Screen.width/2 - 250, Screen.height/2 - 50, 500, 100), "Player 1 Wins!");
			
			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if(GUI.Button(new Rect(Screen.width/2 - 40,Screen.height/2 - 10,80,40), "(R)estart")) {
				Application.LoadLevel(Application.loadedLevel);
			}
			renderer.enabled = false;

		}
	}

	void screwUpControls(){
		
		controls=new string[]{"D","A","Shift","Space"};
	}
	
	void  resetControls(){
		controls=new string[]{"A","D","Space","Shift"};
	}
	
	public float gravity=1, jumpScale=1, speed=1,turboFactor=1f;
	private string[] controls=new string[]{"A","D","Space","Shift"};
	float startTime;
	bool shiftPressed=false;
	
	
	Vector2 startPoint;
	
	
	
	// Use this for initialization
	void Start () {
		
		startPoint = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float right = 0f, left = 0f, up = 0f, turbo = 1.0f, turboY = 1.0f, timeDif;
		
		if (Input.GetButton(controls[1])){ //if D is pressed
			right=1.0f;
			transform.localScale = new Vector3(-20,transform.localScale.y,transform.localScale.z);
		}
		
		if (Input.GetButton(controls[0])){//if A is pressed
			left=-1.0f;
			transform.localScale = new Vector3(20,transform.localScale.y,transform.localScale.z);
		}
		
		if ((Input.GetButton (controls[2]) && rigidbody2D.velocity.y == 0)){ //if space key is pressed
			up=6.0f;
		}
		
		if ((Input.GetButtonUp (controls[2]) && rigidbody2D.velocity.y != 0)){ //if space key is pressed{
			up=-2.0f;
		}
		
		if (Input.GetButton (controls[3])){ // if shift key is pressed
			
			if (shiftPressed==false){
				
				startTime=Time.realtimeSinceStartup;
				shiftPressed=true;
				
			}
			
			timeDif=Time.realtimeSinceStartup-startTime;
			
			if (timeDif<=0.2){
				turbo=turboFactor;
				turboY=0f;
			}
		}
		
		if (Input.GetButtonUp (controls[3])){ //if shift key is pressed
			
			
			shiftPressed=false;
		}
		
		if (this.transform.position.y<-30){
			isAlive = false;
			win = false;

		}
		
		if (Input.GetKeyDown (KeyCode.R)){
			ResetPosition();
			isAlive = true;
			renderer.enabled = true;
			win = false;
		}
		if (isAlive == false) {
			print ("Player 1 Died!");
			//Application.LoadLevel (Application.loadedLevel);
		}


		rigidbody2D.velocity = new Vector2 (right*speed*turbo + left * speed*turbo, turboY* (rigidbody2D.velocity.y - gravity  + up * jumpScale));
		
	}

	void OnCollisionEnter2D(Collision2D other){
		
		
		if (other.gameObject.tag == "enemy") {
			isAlive=false;

		}

		if (other.gameObject.tag == "controlfreak") {
			screwUpControls();
			print ("Control Freak Activated!");
			
		}

		if (other.gameObject.tag == "finish") {
			print ("Congradulations, Player 1 won!");
			win=true;
			}
		
	}
	
}