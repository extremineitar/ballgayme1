using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float movespeed = 4f;
    PlayerInput IP;
    InputAction mAction;
    RandomSpawn randomspawn;
    bool dead = false;
    Animator animator;
    
   
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        IP =GetComponent<PlayerInput>();
        mAction = IP.actions.FindAction("Move");
        randomspawn = GameObject.FindGameObjectWithTag("GameController").GetComponent<RandomSpawn>();
    }

    
    void FixedUpdate()
    {
        if (dead)
        {
            return;
        }
        Vector2 walkDir = mAction.ReadValue<Vector2>();
        rb.linearVelocity = walkDir * movespeed;
        if (rb.linearVelocity.magnitude > 0) 
        {
            animator.SetBool("Walking",true);
          
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }

    public void Dead()
    {
        dead = true;
        if (PlayerPrefs.GetInt("highscore", 0) <= ScoreManager.sessionScore)
        {
            PlayerPrefs.SetInt("highscore",ScoreManager.sessionScore);
        }
            ScoreManager.sessionScore = -1;
        SceneManager.LoadScene("Scene 3");
        StartCoroutine(dieDelay());

    }

    IEnumerator dieDelay()
    {
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(0.15f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}