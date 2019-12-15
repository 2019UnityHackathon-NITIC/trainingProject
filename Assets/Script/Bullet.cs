using UnityEngine;

namespace Script{
    class Bullet : MonoBehaviour{
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _deadTimer = 10f;
        
        private float _timeCounter = 0f;
        void Update(){
            Vector2 _bulletMover = new Vector2(transform.position.x + _speed * Time.deltaTime, transform.position.y);
            transform.position = _bulletMover;
            _timeCounter += Time.deltaTime;
            if (_timeCounter > _deadTimer) Destroy(gameObject);
        }
        void OnTriggerEnter2D(Collider2D other){
            if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Block")) Destroy(gameObject);
            print(other.gameObject.name);
        }
    }
}
