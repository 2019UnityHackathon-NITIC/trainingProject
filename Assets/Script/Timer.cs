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
            Parameters.RemaindTime = Timer.remaindTime;
        }
        void Update()
        {
            float minusTime = Time.deltaTime;
            Timer.remaindTime -= minusTime;
            Parameters.RemaindTime = Timer.remaindTime;
        }
        static public void Reset()
        {
            remaindTime = initialTime;
        }
    }
}