using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion ; 
	public GameObject playerExplosion;
    public int scoreValue;
    public GameController gameController;
    void Start()
   {

        Debug.Log("Enter");
     // gameController = GetComponent<GameController>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();

        }
        if (gameController == null)
        {
            Debug.Log("cannot find 'GameController' script");
        }

    }

    void OnTriggerEnter(Collider other)
	{
       
        if (other.gameObject.tag == "Boundary")
        {
            //"tag" to bolt match by astroid and must have the same name in the code and in unity inspector
            return;
        }

            Instantiate(explosion, transform.position, transform.rotation);

       
			
		if(other.gameObject.tag=="Play")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        else
        {
            gameController.AddScore(scoreValue);
        }


        Destroy(other.gameObject);
        Destroy(gameObject);

    }

}
