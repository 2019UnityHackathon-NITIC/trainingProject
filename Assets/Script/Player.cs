using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    private Move move;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpSpeed;
    private bool isGround;
    [SerializeField] private float _jumpFlag = 1.5f;
    [SerializeField] private GameObject spawnPoint;
    private Rigidbody2D rb;
    static public bool _attackDirectionFlag; // true : front, false, back
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject swapDirectionBullet;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        move = new Move(_moveSpeed, _jumpFlag, rb);
        _attackDirectionFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(rb.velocity.y) > _jumpFlag) isGround = false;
        else isGround = true;
        List<int> direction = new List<int> { };
        if (Input.GetKey(KeyCode.D)) direction.Add(0);
        if (Input.GetKey(KeyCode.A)) direction.Add(1);
        move.move(direction);
        if (Input.GetKey(KeyCode.Space)) move.jump(isGround);
        if (direction.IndexOf(1) != -1 && direction.IndexOf(0) == -1) _attackDirectionFlag = false;
        else if(direction.IndexOf(0) != -1 && direction.IndexOf(1) == -1) _attackDirectionFlag = true;
        if (Input.GetKey(KeyCode.J)) Shoot();
    }

    void Death(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Shoot(){
        Vector3 shooter = gun.transform.position;
        if (_attackDirectionFlag) Instantiate(bullet, shooter, Quaternion.identity);
        else Instantiate(swapDirectionBullet, shooter, Quaternion.identity);
    }
}
