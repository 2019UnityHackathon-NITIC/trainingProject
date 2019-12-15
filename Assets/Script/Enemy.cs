using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script
{
    public class Enemy: MonoBehaviour{
        [FormerlySerializedAs("_moveSpeed")] [SerializeField] private float moveSpeed = 1f;
        [SerializeField] private float maxSpeed = 1f;
        [FormerlySerializedAs("_hp")] [SerializeField] private int hp;
        private MoveController _moveController;
        private readonly List<int> _direction = new List<int>{ 1 };
        private bool _moveReverse = false;
        void Start(){
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            _moveController = new MoveController(moveSpeed, 0, rb, maxSpeed);
        }
        void Update(){
            if (_moveReverse) _direction [0] = 0;
            else _direction[0] = 1;
            _moveController.Move(_direction);
        }
        void OnTriggerEnter2D(Collider2D collider){
            if (collider.gameObject.CompareTag("Bullet")){
                hp--;
                if (hp < 0) Death();
            }
        }
        void OnCollisionEnter2D(Collision2D other){
            if (other.gameObject.CompareTag("Wall")){
                _moveReverse = true;
            }
        }
        void Death(){
            Parameters.KillCount += 1;
            Destroy(gameObject);
        }
    }
}
