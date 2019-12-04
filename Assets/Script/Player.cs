using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    private Move move;
    private Rigidbody2D rb;
    private bool isGround;
    static private bool _attackDirectionFlag; // true : front, false, back
    private string state;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpFlag = 1.5f;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject swapDirectionBullet;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        move = new Move(_moveSpeed, _jumpFlag, rb);
        _attackDirectionFlag = true;
        state = "Stop";
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(rb.velocity.y) > _jumpFlag) isGround = false;
        else isGround = true;
        List<int> direction = new List<int> { };
        if (Input.GetKey(KeyCode.D)) direction.Add(0);
        if (Input.GetKey(KeyCode.A)) direction.Add(1);
        DecideState(direction);
        move.move(direction);
        if (Input.GetKey(KeyCode.Space)) move.jump(isGround);
        if (direction.IndexOf(1) != -1 && direction.IndexOf(0) == -1) _attackDirectionFlag = false;
        else if(direction.IndexOf(0) != -1 && direction.IndexOf(1) == -1) _attackDirectionFlag = true;
        if (Input.GetKey(KeyCode.J)) Shoot();
        
    }

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Enemy" || collider.gameObject.tag == "DeathZone"){
            Death();
        }
    }
    void Death(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Shoot(){
        Vector3 shooter = gun.transform.position;
        if (_attackDirectionFlag) Instantiate(bullet, shooter, Quaternion.identity);
        else Instantiate(swapDirectionBullet, shooter, Quaternion.identity);
    }
    void DecideState(List<int> d){
        if(isGround){
            if(d.IndexOf(0) == d.IndexOf(1) || (d.IndexOf(0) != -1 && d.IndexOf(1) != -1)) state = "Stop";
            else state = "Walk";
        }else{
            if (rb.velocity.y > 0) state = "Rase";
            else state = "Fall";
        }
    }
}
