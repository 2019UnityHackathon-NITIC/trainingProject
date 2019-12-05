using UnityEngine;
class Timer :MonoBehaviour{
    static private float remaindTime;
    [SerializeField] static private float initialTime;
    void Start(){
        Timer.remaindTime = Timer.initialTime;
    }
    void Updata(){
        float minusTime = Time.deltaTime;
        Timer.remaindTime -= minusTime;
    }
    static void Reset(){
        remaindTime = initialTime;
    }
}