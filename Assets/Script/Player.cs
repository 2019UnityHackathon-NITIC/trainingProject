using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Script
{
    public class Player : MonoBehaviour
    {
        private MoveController _moveController;
        static private Vector2 spawnTrancelate;
        private Rigidbody2D _rb;
        private bool _isGround;
        private bool _canShoot = true;
        private static bool _attackDirectionFlag; // true : front, false, back
        private string _state;
        private float timeFromLastShot = 0;
        [FormerlySerializedAs("_jumpSpeed")] [SerializeField] private float jumpSpeed;
        [FormerlySerializedAs("_moveSpeed")] [SerializeField] private float moveSpeed;
        [FormerlySerializedAs("_jumpFlag")] [SerializeField] private float jumpFlag = 1.5f;
        [SerializeField] private float maxSpeed = 2f;
        [SerializeField] private float shotDelay = 0.1f;
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
            if (spawnPoint != null) Player.spawnTrancelate = spawnPoint.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if(!_canShoot){
                timeFromLastShot += Time.deltaTime;
                if (timeFromLastShot > shotDelay) {
                    _canShoot = true;
                    timeFromLastShot = 0;
                }
            }
            if (Mathf.Abs(_rb.velocity.y) > jumpFlag) _isGround = false;
            else _isGround = true;
            List<int> direction = new List<int> { };
            if (Input.GetKey(KeyCode.D)) direction.Add(0);
            if (Input.GetKey(KeyCode.A)) direction.Add(1);
            DecideState(direction);
            _moveController.Move(direction);
            if (Input.GetKey(KeyCode.Space)) _moveController.Jump(_isGround);
            if (direction.IndexOf(1) != -1 && direction.IndexOf(0) == -1) _attackDirectionFlag = false;
            else if(direction.IndexOf(0) != -1 && direction.IndexOf(1) == -1) _attackDirectionFlag = true;
            if (Input.GetKey(KeyCode.J) && _canShoot) Shoot();
            if (Parameters.RemaindTime < 0) Death();
        }

        void OnTriggerEnter2D(Collider2D collider){
            Debug.Log(collider.gameObject.tag);
            if(collider.gameObject.CompareTag("DeathZone")){
                Death();
            }
        }
        void Death(){
            Parameters.Lives -= 1;
            if (Parameters.Lives == 0) {
                Parameters.Reset();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                Destroy(this.gameObject);
                GameObject obj = (GameObject)Resources.Load("Prefab/Player");
                Instantiate(obj, spawnTrancelate, Quaternion.identity);
                Timer.Reset();
            }
        }

        void Shoot(){
            Vector3 shooter = gun.transform.position;
            if (_attackDirectionFlag) Instantiate(bullet, shooter, Quaternion.identity);
            else Instantiate(swapDirectionBullet, shooter, Quaternion.identity);
            _canShoot = false;
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
