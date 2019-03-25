using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour {

	public float distance, speedMove;
	private Vector2 target;

	void Start () {
		var playerPosition = GameObject.FindWithTag ("Player");
		target = new Vector2 (playerPosition.transform.position.x + distance, playerPosition.transform.position.y);
		distance = 8;
		speedMove = 10;
		
	}

	void Update(){
		transform.position = Vector2.MoveTowards (transform.position, target, speedMove * Time.deltaTime);
		if (transform.position == new Vector3(target.x, target.y, transform.position.z))
			Destroy(this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Death") {
			Destroy (this.gameObject);
		}
	}
		
}
