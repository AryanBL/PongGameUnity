using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float ballSpeed = 80f;
    private Audio Audio;
    private Rigidbody2D rb;


    private void Awake()
    {
        Audio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio>();
    }


    // Start is called before the first frame update
    void Start()
    {
        //PlayerOneScore.instance.IncrementScore("Player1Score");
        //PlayerOneScore.instance.IncrementScore("Player2Score");
        //PlayerOneScore.instance.IncrementScore("Player2Score");
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }


    private void LaunchBall()
    {
        transform.position = Vector3.zero;
        float randomAngle = Random.Range(-45f, 45f);
        Vector2 direction = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));

        if (Random.value > 0.5f)
        {
            direction.x = -direction.x;
        }

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
            Audio.PlaySFX(Audio.ScoreMusic);
            PlayerOneScore.instance.IncrementScore("Player1Score");
            LaunchBall();
        }
        else if (collision.gameObject.CompareTag("LeftBorder"))
        {
            Audio.PlaySFX(Audio.ScoreMusic);
            PlayerOneScore.instance.IncrementScore("Player2Score");
            LaunchBall();
        }
        else
        {
            Audio.PlaySFX(Audio.CollisionMusic);
        }

        rb.velocity = rb.velocity.normalized * ballSpeed;
    }

}
