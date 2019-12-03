using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Move move;
    [SerializeField] private int _moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        move = new Move(_moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        List<int> direction = new List<int> { };
        if (Input.GetKey(KeyCode.D)) direction.Add(0);
        if (Input.GetKey(KeyCode.A)) direction.Add(1);
        move.move(direction);
    }
}
