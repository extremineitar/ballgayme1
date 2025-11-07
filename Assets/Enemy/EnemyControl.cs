using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    Vector2 moveDir = Vector2.zero;

   public  float moveSpeed = 5f;

    public Rigidbody2D rb;

    RandomSpawn spawner;


    public void Start()
    {
        moveDir = Random.insideUnitCircle.normalized * moveSpeed;
        rb =GetComponent<Rigidbody2D>();
        rb.linearVelocity = moveDir;
        spawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<RandomSpawn>();
        spawner.poweraquired += Shrink;
        spawner.powerout += Grow;
        if (spawner.small)
        {
            transform.localScale *= 0.5f;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().Dead();
        }
    }
    public void Grow()
    {
        transform.localScale = Vector3.one;
    }

    public void Shrink()
    {
        transform.localScale = Vector3.one * 0.5f;
    }
}

