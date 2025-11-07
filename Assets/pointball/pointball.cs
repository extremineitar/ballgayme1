using UnityEngine;

public class pointball : MonoBehaviour
{
    RandomSpawn manager;
    public float moveSpeed = 4f;
    void Start()
    {
       Vector2 moveDir = Random.insideUnitCircle.normalized * moveSpeed;
       Rigidbody2D rb = GetComponent<Rigidbody2D>();
       rb.linearVelocity = moveDir;
       manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<RandomSpawn>();
    }

   
    private void OnTriggerEnter2D(Collider2D colission)
    {
        Debug.Log(colission.gameObject.name);
        if (colission.CompareTag("Player"))
        {
            manager.spawnpointball();
            manager.spawnenemyrandom();
            Destroy(gameObject);
        }
    }
}
