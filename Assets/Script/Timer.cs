using UnityEngine;
namespace Script
{
    class Timer : MonoBehaviour
    {
        static public float remaindTime;
        [SerializeField] static private float initialTime;
        void Start()
        {
            Timer.remaindTime = Timer.initialTime;
        }
        void Updata()
        {
            float minusTime = Time.deltaTime;
            Timer.remaindTime -= minusTime;
        }
        static public void Reset()
        {
            remaindTime = initialTime;
        }
    }
}