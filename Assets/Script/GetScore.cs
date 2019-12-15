using UnityEngine;
using UnityEngine.UI;

namespace Script{
    class GetScore : MonoBehaviour{
        private Text textBox;
        void Start()
        {
            textBox = gameObject.GetComponent<Text>();
            if (textBox != null){
                textBox.text = "SCORE\n_____\nRemaining Time: " + ((int)Parameters.RemaindTime).ToString() + 
                " * 5\nKillCount : " + ((int)Parameters.KillCount).ToString() +
                " * 100\nRemaining Lives : " + ((int)Parameters.Lives).ToString() +
                " * 100\n__________\nTotal : " + ((int)Parameters.RemaindTime * 5 + (int)Parameters.KillCount * 100 + (int)Parameters.Lives * 100).ToString();
            }
        }
    }
}
