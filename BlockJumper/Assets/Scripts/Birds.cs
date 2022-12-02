using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birds : MonoBehaviour
{

    private float min_X = -7.5f, max_X = 7.5f, min_Y, max_Y;

    bool facingRight = true;
    private float move_Speed = 4f;
    private float vert_move_speed = .25f;
    // Update is called once per frame
    void Update()
    {
         MoveBird();
    }
    void MoveBird()
    {
            Vector3 temp = transform.position;

            temp.x += move_Speed * Time.deltaTime;
            if (temp.x > max_X)
            {
                if (facingRight)
                {
                    flip();
                }
                move_Speed *= -1f;
            }
            else if (temp.x < min_X)
            {
                if (!facingRight)
                {
                    flip();
                }
                move_Speed *= -1f;
            }

        transform.position = temp;
    }
    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}

