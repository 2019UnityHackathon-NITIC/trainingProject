using UnityEngine;
namespace Script
{
    class Timer : MonoBehaviour
    {
        static public float RemainingTime;
        [SerializeField] static private float initialTime;
        void Start()
        {
            Timer.RemainingTime = Timer.initialTime;
            Parameters.RemaindTime = Timer.RemainingTime;
        }
        void Update()
        {
            float minusTime = Time.deltaTime;
            Timer.RemainingTime -= minusTime;
            Parameters.RemaindTime = Timer.RemainingTime;
        }
        static public void Reset()
        {
            RemainingTime = initialTime;
        }
    }
}