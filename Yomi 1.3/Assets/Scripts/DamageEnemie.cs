﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemie : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Projectile") {
			Destroy (col.gameObject);
			Destroy (this.gameObject);
		}
	}
}
