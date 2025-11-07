using UnityEngine;

public class Enemyball2 : EnemyControl
{
    GameObject Player;


    private new void Start()
    {
        base.Start();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.CompareTag("Floor"))
        {
            rb.linearVelocity = (Player.transform.position - transform.position).normalized * moveSpeed;
        }
    }
}
