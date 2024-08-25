using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float ballSpeed = 80f;
    private Rigidbody2D rb;
    private bool initialLaunch;
    private bool right;
    private bool left;
    
    // Start is called before the first frame update
    void Start()
    {
        //PlayerOneScore.instance.IncrementScore("Player1Score");
        //PlayerOneScore.instance.IncrementScore("Player2Score");
        //PlayerOneScore.instance.IncrementScore("Player2Score");
        initialLaunch = true;
        right = false;
        left = false;
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }


    private void LaunchBall()
    {
        transform.position = Vector3.zero;
        float randomAngle = Random.Range(-45f, 45f);
        Vector2 direction = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));

        if (Random.value > 0.5f && initialLaunch)
        {
            direction.x = -direction.x;
        }

        if (left && !right) { 
            direction.x = -direction.x;
        }

        initialLaunch = false;
        rb.velocity = direction * ballSpeed;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RightBorder"))
        {
            right = true;
            left = false;
            PlayerOneScore.instance.IncrementScore("Player1Score");
            LaunchBall();
        }
        if (collision.gameObject.CompareTag("LeftBorder"))
        {
            left = true;
            right = false;
            PlayerOneScore.instance.IncrementScore("Player2Score");
            LaunchBall();
        }

        rb.velocity = rb.velocity.normalized * ballSpeed;
    }

}
