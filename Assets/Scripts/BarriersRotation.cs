using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BarriersRotation : MonoBehaviour
{
    [SerializeField] float rotationDuration;
    // Start is called before the first frame update
    void Start()
    {
        transform
            .DORotate(new Vector3(0f, 0f, 1f), rotationDuration)
            .SetLoops(-1,LoopType.Incremental);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
