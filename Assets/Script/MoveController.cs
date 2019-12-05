using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class MoveController : MonoBehaviour
    {
        private Rigidbody2D _controller;
        private Vector2 _vector;
        private float _moveSpeed;
        private Vector2 _jumpSpeed;
        public MoveController(float speed, float jump, Rigidbody2D rb)
        {
            _controller = rb;
            _moveSpeed = speed;
            _jumpSpeed = new Vector2(0, jump);
        }
        public void move(List<int> directions) 
            // direction is 0:front, 1:back
        {
            int front = directions.IndexOf(0);
            int back = directions.IndexOf(1);
            if (front != back && (front == -1 || back == -1)){
                if(front == -1) _vector.x -= _moveSpeed;
                else _vector.x += _moveSpeed;
            }else _controller.velocity = new Vector2(0, _controller.velocity.y);
            _controller.AddForce(_vector);
        }

        public void Jump(bool flag){
            if (flag){
                _controller.AddForce(_jumpSpeed);
            }
        } 
    }
}
