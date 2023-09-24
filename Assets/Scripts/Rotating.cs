using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotating : MonoBehaviour
{
    public float speed;
    private void Start() {
        transform.DORotate(new Vector3(0,360f,0),speed,RotateMode.Fast).SetLoops(-1,LoopType.Restart).SetRelative().SetEase(Ease.Linear);
    }
}
