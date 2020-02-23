 using UnityEngine;
using System.Collections;
[System.Serializable]
public class Boundary {
	public float xMin , xMax , zMin ,zMax;
}
public class PlayerController : MonoBehaviour {
	public float speed; 
	public float tilt;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn; //shotSpawn.transform.position //GameObject
	public float fireRate; 
	private float nextFire;
    AudioSource audio;
        
	Rigidbody rg;
	void Start()
    {
		rg = GetComponent<Rigidbody> ();
        audio = GetComponent<AudioSource>();
    }
	void Update ()
    {
		if (Input.GetButton("Fire1") && Time.time>nextFire)
        {
			nextFire = Time.time+ fireRate ; 
				Instantiate (shot, shotSpawn.position , shotSpawn.rotation) ;
            audio.Play();
        }


    }
    void FixedUpdate() {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rg.velocity = move * speed;
        rg.position = new Vector3(
            Mathf.Clamp(rg.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rg.position.z, boundary.zMin, boundary.zMax)
            );
        rg.rotation = Quaternion.Euler(0.0f, 0.0f, rg.velocity.x * -tilt);}}
