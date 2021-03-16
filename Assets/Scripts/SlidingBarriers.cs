using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Sliding : MonoBehaviour
{
    [SerializeField] float slideDistance;
    [SerializeField] float slideDuration;
    // Start is called before the first frame update
    void Start()
    {
        transform
            .DOLocalMoveX(slideDistance, slideDuration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutBack);
    }

    // Update is called once per frame
    void Update()
    {

    }
}