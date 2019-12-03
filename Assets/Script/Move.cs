using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D _controller;
    private Vector2 vector;
    private int moveSpeed;
    public Move(int speed)
    {
        _controller = GetComponent<Rigidbody2D>();
        moveSpeed = speed;
    }
    public void move(List<int> directions) 
    // direction is 0:front, 1:back
    {
        int front = directions.IndexOf(0);
        int back = directions.IndexOf(1);
        if (front != back && (front == -1 || back == -1)){
            if(front == -1){
                vector.x -= moveSpeed;
            }else{
                vector.x += moveSpeed;
            }
        }else{
            _controller.velocity = new Vector2(0, _controller.velocity.y);
        }
        _controller.AddForce(vector);
    }
}
