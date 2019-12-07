using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Script
{
    public class UIController : MonoBehaviour{
        [SerializeField] private Text remaindLives;
        [SerializeField] private Text timer;
        private Hashtable cache;
        void Start(){
            cache = new Hashtable();
            if(remaindLives != null){
                remaindLives.text = "Lives : "+Parameters.Lives.ToString();
                cache["Lives"] = Parameters.Lives;
                cache["time"] = (int)Parameters.RemaindTime + 1;

                
            }
        }
        void Update(){
            if (remaindLives != null && (int)cache["Lives"] != Parameters.Lives) {
                remaindLives.text = "Lives : " + Parameters.Lives.ToString();
                cache["Lives"] = Parameters.Lives;
            }
            if (timer != null && (int)cache["Lives"] != (int)Parameters.Lives + 1){
                cache["time"] = (int)Parameters.RemaindTime + 1;
                timer.text = "Time : " + ((int)cache["time"]).ToString();
            }
        }
    }
}