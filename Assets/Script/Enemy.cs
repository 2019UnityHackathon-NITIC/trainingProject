using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour{
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private int _hp;
    private Move _move;
    private List<int> direction = new List<int>{ 1 };
    void Start(){
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        _move = new Move(_moveSpeed, 0, rb);
    }
    void Update(){
        _move.move(direction);
    }
    void OnTriggerEnter(Collider collider){
        if (collider.gameObject.tag == "Bullet"){
            _hp--;
            if (_hp == 0) Death();
        }
    }
    void Death(){
        Parameters.killCount += 1;
        Destroy(gameObject);
    }
}