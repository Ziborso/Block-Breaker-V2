using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSccript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float screenWidthInUnits = 16f;

    public float speed;
    public float rightScreenEdge;
    public float leftScreenEdge;
    public GameManager gm;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate (Vector2.right * horizontal * Time.deltaTime * speed);
        if (transform.position.x < leftScreenEdge)
        {
            transform.position = new Vector2(leftScreenEdge, transform.position.y);
        }
        if (transform.position.x > rightScreenEdge)
        {
            transform.position = new Vector2(rightScreenEdge, transform.position.y);
        }

        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 PaddlePos = new Vector2(mousePosInUnits, transform.position.y);
        transform.position = PaddlePos;
        
        if (transform.position.x < leftScreenEdge)
        {
            transform.position = new Vector2(leftScreenEdge, transform.position.y);
        }
        if (transform.position.x > rightScreenEdge)
        {
            transform.position = new Vector2(rightScreenEdge, transform.position.y);
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ExtraLife"))
        {
            gm.UpdateLives(1);
            Destroy(other.gameObject);

        }
    }
}
