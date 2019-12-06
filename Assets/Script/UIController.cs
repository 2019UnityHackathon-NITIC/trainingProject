using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

namespace Script
{
    public class UIController : MonoBehaviour{
        private Text remaindLives;
        private int oldLives;
        void Start(){
            remaindLives = GetComponent<Text>();
            if(remaindLives != null){
                remaindLives.text = "Lives : "+Parameters.Lives.ToString();
                oldLives = Parameters.Lives;
            }
        }
        void Update(){
            if (remaindLives != null && oldLives != Parameters.Lives) {
                remaindLives.text = "Lives : " + Parameters.Lives.ToString();
                oldLives = Parameters.Lives;
            }
        }
    }
}