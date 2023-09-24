using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallrunBar : MonoBehaviour
{
    public float wallrunTime;
    float maxWallrunTime;

    public Slider wallrunBar;
    public float dValue;

    void Start()
    {
        maxWallrunTime = wallrunTime;
    }

    void Update()
    {
        
    }

    private void DecreaseTime(){
        if(wallrunTime != 0){
            wallrunTime -= dValue * Time.deltaTime;
        }
    }
    private void IncraeseTime(){
        wallrunTime += dValue * Time.deltaTime;
    }
}
