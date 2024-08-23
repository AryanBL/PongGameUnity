using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPaddle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 80f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vector2 = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vector2.y += 0.5f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            vector2.y -= 0.5f;
        }

        vector2 = vector2.normalized;
        Vector3 movement = new Vector3(vector2.x, vector2.y, 0);
        transform.position += movement * Time.deltaTime * speed;

    }
}
