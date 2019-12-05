using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Script
{
    public class Player : MonoBehaviour
    {
        private MoveController _moveController;
        private Rigidbody2D _rb;
        private bool _isGround;
        private static bool _attackDirectionFlag; // true : front, false, back
        private string _state;
        [FormerlySerializedAs("_jumpSpeed")] [SerializeField] private float jumpSpeed;
        [FormerlySerializedAs("_moveSpeed")] [SerializeField] private float moveSpeed;
        [FormerlySerializedAs("_jumpFlag")] [SerializeField] private float jumpFlag = 1.5f;
        [SerializeField] private float maxSpeed = 2f;
        [SerializeField] private GameObject spawnPoint;
        [SerializeField] private GameObject gun;
        [SerializeField] private GameObject bullet;
        [SerializeField] private GameObject swapDirectionBullet;
        // Start is called before the first frame update
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _moveController = new MoveController(moveSpeed, jumpSpeed, _rb, maxSpeed);
            _attackDirectionFlag = true;
            _state = "Stop";
        }

        // Update is called once per frame
        void Update()
        {
            if (Mathf.Abs(_rb.velocity.y) > jumpFlag) _isGround = false;
            else _isGround = true;
            List<int> direction = new List<int> { };
            if (Input.GetKey(KeyCode.D)) direction.Add(0);
            if (Input.GetKey(KeyCode.A)) direction.Add(1);
            DecideState(direction);
            _moveController.move(direction);
            if (Input.GetKey(KeyCode.Space)) _moveController.Jump(_isGround);
            if (direction.IndexOf(1) != -1 && direction.IndexOf(0) == -1) _attackDirectionFlag = false;
            else if(direction.IndexOf(0) != -1 && direction.IndexOf(1) == -1) _attackDirectionFlag = true;
            if (Input.GetKey(KeyCode.J)) Shoot();
            if (Parameters.RemaindTime < 0) Death();
        }

        void OnTriggerEnter(Collider collider){
            if(collider.gameObject.CompareTag("Enemy") || collider.gameObject.CompareTag("DeathZone")){
                Death();
            }
        }
        void Death(){
            Parameters.Lives -= 1;
            if (Parameters.Lives == 0)SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Destroy(this.gameObject);
            Instantiate(this.gameObject, spawnPoint.transform.position, Quaternion.identity);
            Timer.Reset();
        }

        void Shoot(){
            Vector3 shooter = gun.transform.position;
            if (_attackDirectionFlag) Instantiate(bullet, shooter, Quaternion.identity);
            else Instantiate(swapDirectionBullet, shooter, Quaternion.identity);
        }
        void DecideState(List<int> d){
            if(_isGround){
                if(d.IndexOf(0) == d.IndexOf(1) || (d.IndexOf(0) != -1 && d.IndexOf(1) != -1)) _state = "Stop";
                else _state = "Walk";
            }else{
                if (_rb.velocity.y > 0) _state = "Rise";
                else _state = "Fall";
            }
        }
    }
}
