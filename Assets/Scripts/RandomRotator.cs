using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {
	Rigidbody rg;

	public float tumble;
	void Start()
	{
		rg = GetComponent<Rigidbody> ();
        rg.angularVelocity = Random.insideUnitSphere * tumble;
		//all the code in start not in fixedupdate
	}




}
