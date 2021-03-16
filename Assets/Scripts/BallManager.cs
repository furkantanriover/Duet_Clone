using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallManager : MonoBehaviour
{
    ParticleSystem explosionFx;

    // Start is called before the first frame update
    void Start()
    {
        explosionFx = transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Barriers"))
        {
            GameeManager.Instance.isGameover = true;
            explosionFx.Play();
            PlayerMovement.Instance.Restart();
        }
    }
}
