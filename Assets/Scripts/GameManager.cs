using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject obstacle;
    public Transform spawnPoint;
    int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject Play;
    public GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        //GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObstacles()
    {
        while(true)
        {
            float waitTime = Random.Range(1f, 3f);    
            yield return new WaitForSeconds(waitTime);

            Instantiate (obstacle, spawnPoint.position, Quaternion.identity );
        }
    }
    void Scoreup()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameStart()
    {
        // Make sure this method is called only when the button is clicked
        player.SetActive(true);  // Activate player
        Play.SetActive(false);   // Deactivate Play button
        StartCoroutine(SpawnObstacles());  // Start spawning obstacles
        InvokeRepeating("Scoreup", 2f, 1f);  // Start updating score

    }
}
