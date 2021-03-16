using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    Vector3 startPosition;

    #region Singleton class: PlayerMovement

    public static PlayerMovement Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    #endregion //singleton tasarım kalıbı ile nesneme global erişim noktası sağlıyorum
    [SerializeField] CircleCollider2D orangeBallCollider;
    [SerializeField] CircleCollider2D purpleBallCollider;
    [SerializeField] float speed;  // inspectordan görüp düzeltme yapabiliriz ama başka scriptlerden erişmeyiz
    [SerializeField] float rotationSpeed;

    Rigidbody2D rb;
    Camera cam;
    float touchPosX;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;

        MoveUp();
    }


    void Update()
    {
        if(!GameeManager.Instance.isGameover)
        {
            //Add mobile inputs
            if (Input.GetMouseButtonDown(0))
                 touchPosX = cam.ScreenToWorldPoint(Input.mousePosition).x;
            if (Input.GetMouseButton(0))
            {
                
                if (touchPosX > 0.01f)
                    RotateRight();
                else
                    RotateLeft();
            }
                else
                    rb.angularVelocity = 0f;

#if UNITY_EDİTOR
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                RotateLeft();
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                RotateRight();
            }

            //stop rotation when key is released
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                rb.angularVelocity = 0f;
            }
#endif
        }


    }
    
     void MoveUp()
    {
        rb.velocity = Vector2.up * speed;
    }

     void RotateLeft()
    {
        rb.angularVelocity = rotationSpeed;
    }

     void RotateRight()
    {
        rb.angularVelocity = -rotationSpeed;
    }

    public void Restart()
    {
        orangeBallCollider.enabled = false;
        purpleBallCollider.enabled = false;
        rb.angularVelocity = 0f;
        rb.velocity = Vector2.zero;

        //başlangıç pozisyonuna dönme
        transform
        .DORotate(Vector3.zero, 1f) //playerin standart konumu ve süresi
        .SetDelay(1f)//animasyon süresi
        .SetEase(Ease.InOutBack);//animasyon tipi

        transform
            .DOMove(startPosition, 1f)
            .SetDelay(1f)
            .SetEase(Ease.InOutFlash)
            .OnComplete(() =>
            {
                orangeBallCollider.enabled = true;
                purpleBallCollider.enabled = true;

                GameeManager.Instance.isGameover = false;

                MoveUp();
            });
    }


}
