using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Move move;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpSpeed;
    private bool isGround;
    [SerializeField] private float _jumpFlag = 1.5f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        move = new Move(_moveSpeed, _jumpFlag, rb);
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
    }
}
