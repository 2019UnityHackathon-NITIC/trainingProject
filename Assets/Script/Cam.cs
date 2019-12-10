using UnityEngine;
using UnityEngine.Serialization;

namespace Script {
    class Cam : MonoBehaviour{
        [SerializeField] private GameObject player;
        private Vector2 position;
        private float y;
        void Start(){
            y = this.gameObject.transform.position.y;
        }
        void Update(){
            Vector3 newPosition = new Vector3(player.transform.position.x, y, -10);
            this.gameObject.transform.position = newPosition;
        }
    }
}
