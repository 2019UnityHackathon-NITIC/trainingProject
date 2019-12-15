using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Script
{
    public class UIController : MonoBehaviour{
        [SerializeField] private Text remaindLives;
        [SerializeField] private Text timer;
        [SerializeField] private Text killCounter;
        private Hashtable cache;
        void Start(){
            cache = new Hashtable();
            if(remaindLives != null){
                remaindLives.text = "Lives : "+Parameters.Lives.ToString();
                cache["Lives"] = Parameters.Lives;
            }
            if(timer != null){
                timer.text = "Time : " + Parameters.RemaindTime.ToString();
                cache["Time"] = (int)Parameters.RemaindTime + 1;
            }
            if(killCounter != null){
                killCounter.text = "Kill : " + Parameters.KillCount.ToString();
                cache["Kill"] = Parameters.KillCount;
            }
        }
        void Update(){
            if (remaindLives != null && (int)cache["Lives"] != Parameters.Lives) {
                cache["Lives"] = Parameters.Lives;
                remaindLives.text = "Lives : " + ((int)cache["Lives"]).ToString();
            }
            if (timer != null && (int)cache["Lives"] != (int)Parameters.Lives + 1){
                cache["time"] = (int)Parameters.RemaindTime + 1;
                timer.text = "Time : " + ((int)cache["time"]).ToString();
            }
            if (killCounter != null && (int)cache["Kill"] != Parameters.KillCount){
                cache["kill"] = Parameters.KillCount;
                killCounter.text = "kill : " + ((int)cache["kill"]).ToString();
            }
        }
    }
}
