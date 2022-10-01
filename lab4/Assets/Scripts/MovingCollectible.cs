using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingCollectible : MonoBehaviour
{
    [SerializeField] private Transform tweenEndPoint;
    private void Start() => transform.DOMove(tweenEndPoint.position, 6f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
}
