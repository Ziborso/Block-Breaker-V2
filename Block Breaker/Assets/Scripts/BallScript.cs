using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D> ();

        rb.AddForce (Vector2.up * 500);
    }

    // Update is called once per frame
    void Update()
    {
        if (!inPlay)
        {
            transform.position = paddle.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bottom"))
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
