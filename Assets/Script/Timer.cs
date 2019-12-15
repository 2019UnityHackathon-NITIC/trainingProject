using UnityEngine;

namespace Script
{
    class Timer : MonoBehaviour
    {
        [SerializeField] private float initialTime;
        private bool _stopFlag = false;
        void Start()
        {
            if(Parameters.initialTime == -1f){
                Parameters.initialTime = initialTime;
            }
            Parameters.RemaindTime = Parameters.initialTime;
        }
        void Update()
        {
            if (!_stopFlag) Parameters.RemaindTime -= Time.deltaTime;
        }
        public void Reset()
        {
            Parameters.RemaindTime = Parameters.initialTime;
        }
        public void Stop(){
            _stopFlag = true;
        }
    }
}
