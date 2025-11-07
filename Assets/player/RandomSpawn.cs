using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RandomSpawn : MonoBehaviour
{
    public GameObject enemyball;

    public GameObject pointball;

    public GameObject player;

    public GameObject powerup;


    public GameObject enemyball2;

    public float sceneChangeTimer = 30.0f;

    public string nextScene;

    public float powerupInterval = 10f;

    public float poweruptimer = 10f;

    public bool small = false;



    


    Vector2 topCorner = new Vector2(7.8f, 4.2f);

    Vector2 bottomCorner = new Vector2(-7.8f, -4.2f);

   public delegate void PowerAcquired();
    public delegate void PowerOut();

    public PowerAcquired poweraquired;
    public PowerOut powerout;


    void Start()
    {
       
        ScoreManager.SwitchScene();
        spawnenemyrandom();
        spawnpointball();
    }
    public void Update()
    {
        Debug.Log(poweruptimer);
        poweruptimer -= Time.deltaTime;
        if (poweruptimer < 0)
        {
            
            poweruptimer = powerupInterval;
            GameObject newPower = Instantiate(powerup);
            newPower.transform.position = GetValidPos();
        }
        sceneChangeTimer -= Time.deltaTime;
        if (sceneChangeTimer < 0)
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    
    public void PowerCountdown()
    {
        StartCoroutine(TimeoutTimer());
    }

    IEnumerator TimeoutTimer()
    {
        yield return new WaitForSeconds(9.9f);
        small = false;
        powerout();
        
    }

   public void spawnenemyrandom()
    {

        GameObject new_enemy = Instantiate(Random.Range(0,100) > 50 ? enemyball : enemyball2);
        new_enemy.transform.position = GetValidPos();
    }

   public void spawnpointball()
    {
        ScoreManager.sessionScore += 1;
        ScoreManager.text.text = ScoreManager.sessionScore.ToString();
        GameObject point_ball = Instantiate(pointball);
        point_ball.transform.position = GetValidPos();


    }
    Vector2 GetValidPos()
    {
        Vector2 possiblePosition = new Vector2(Random.Range(topCorner.x, bottomCorner.x), Random.Range(topCorner.y, bottomCorner.y));
        while (Vector2.Distance(possiblePosition, player.transform.position) < 1.2f) ;
        return possiblePosition;
    }
}
