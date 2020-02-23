using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;

    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text reStartText ;
    public Text gameOverText ;

    private bool gameOver;
    private bool reStart;

    private int score;
    //Application app;
   
    void Start()
    {
        //app = GetComponent<Application>();
        gameOver = false;
        reStart = false;
        reStartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
       StartCoroutine (SpawnWavesn());
    }
    void Update()
    {
        if (reStart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);

            }
        }
    }
    IEnumerator SpawnWavesn()
    {
        yield return new WaitForSeconds(startWait);
        while (true )
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
             }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                reStartText.text = "press 'R' for Restart";
                reStart = true;
                break;
            }
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "score:" + score;
    }
     public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

}
