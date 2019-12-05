using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script
{
    public class Enemy: MonoBehaviour{
        [FormerlySerializedAs("_moveSpeed")] [SerializeField] private float moveSpeed = 1f;
        [FormerlySerializedAs("_hp")] [SerializeField] private int hp;
        private MoveController _moveController;
        private readonly List<int> _direction = new List<int>{ 1 };
        void Start(){
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            _moveController = new MoveController(moveSpeed, 0, rb);
        }
        void Update(){
            _moveController.move(_direction);
        }
        void OnTriggerEnter(Collider collider){
            if (collider.gameObject.CompareTag("Bullet")){
                hp--;
                if (hp == 0) Death();
            }
        }
        void Death(){
            Parameters.KillCount += 1;
            Destroy(gameObject);
        }
    }
}