using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectibleAction : MonoBehaviour
{
	AudioSource audioo;
	Collider2D c;
	SpriteRenderer s;
	void Start(){
		audioo = GetComponent<AudioSource>();
		c = GetComponent<Collider2D>();
		s = GetComponent<SpriteRenderer>();
	}
	void OnCollisionEnter2D(Collision2D obj_item){
		audioo.Play();
		c.enabled = false;
		s.enabled = false;
		/*
		if(obj_item.gameObject.tag == "Player"){
			
			Destroy(this.gameObject);
		}
		*/
	}
}
