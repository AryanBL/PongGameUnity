using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPaddle : MonoBehaviour
{
    [SerializeField] private float speed = 80f;
    private bool StopUp;
    private bool StopDown;
    // Start is called before the first frame update
    void Start()
    {
        StopUp = false;
        StopDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vector2 = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W) && !StopUp)
        {
            vector2.y += 0.5f;
        }

        if (Input.GetKey(KeyCode.S) && !StopDown)
        {
            vector2.y -= 0.5f;
        }

        vector2 = vector2.normalized;
        Vector3 movement = new Vector3(vector2.x, vector2.y, 0);
        transform.position += movement * Time.deltaTime * speed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TopBorder"))
        {
            StopUp = true;
        }

        if (collision.gameObject.CompareTag("BottomBorder"))
        {
            StopDown = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TopBorder"))
        {
            StopUp = false;
        }

        if (collision.gameObject.CompareTag("BottomBorder"))
        {
            StopDown = false;
        }
    }

}
