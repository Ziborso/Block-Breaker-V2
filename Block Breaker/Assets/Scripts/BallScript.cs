using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float BallSpeed;
    public Transform explosion;
    public GameManager gm;
    public int numberOfBricks;
    public Transform powerup;

    void Start()
    {
        // Movement of the ball
        rb = GetComponent<Rigidbody2D> ();

        
    }

    void Update()
    {
        // Ball on paddle when start
        if (!inPlay)
        {
            transform.position = paddle.position;
        }

        // Launch the ball
        if (Input.GetMouseButtonDown(0) && !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * BallSpeed);
        }
    }

    // Touch colider
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bottom"))
        {
            
            rb.velocity = Vector2.zero;
            inPlay = false;
            gm.UpdateLives(-1);
        }
    }

    // Hit in brick
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag ("Brick"))
        {
            Brick_script brickScript = other.gameObject.GetComponent<Brick_script>();
            if (brickScript.hitsToBreake > 1)
            {
                brickScript.BreakBrick();
            }
            else
            {
                int randChance = Random.Range(1, 101);
                if (randChance < 50)
                {
                    Instantiate(powerup, other.transform.position, other.transform.rotation);
                }

                Transform newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
                Destroy(newExplosion.gameObject, 2.5f);

                gm.UpdateScore(brickScript.points);
                gm.UpdateNumberOfBricks();

                Destroy(other.gameObject);
            }
        }
            
    }
} 
