using UnityEngine;

public class Powerup : MonoBehaviour
{
    RandomSpawn spawner;
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<RandomSpawn>();
    }

   public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            spawner.small = true;
            spawner.poweraquired();
            spawner.PowerCountdown();
            Destroy(gameObject);
        }
    }
}
