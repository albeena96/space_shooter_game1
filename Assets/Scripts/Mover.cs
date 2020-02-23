using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public float speed ;
	Rigidbody rg;
	void Start()
	{
		rg = GetComponent<Rigidbody> ();
	}
	void FixedUpdate(){
		rg.velocity = transform.forward * speed ;

	}
}
