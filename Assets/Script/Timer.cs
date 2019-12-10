using UnityEngine;

namespace Script
{
    class Timer : MonoBehaviour
    {
        [SerializeField] private float initialTime;
        void Start()
        {
            if(Parameters.initialTime == -1f){
                Parameters.initialTime = initialTime;
            }
            Parameters.RemaindTime = Parameters.initialTime;
        }
        void Update()
        {
            Parameters.RemaindTime -= Time.deltaTime;
            Debug.Log(Parameters.RemaindTime);
        }
        public void Reset()
        {
            Parameters.RemaindTime = Parameters.initialTime;
        }
    }
}
