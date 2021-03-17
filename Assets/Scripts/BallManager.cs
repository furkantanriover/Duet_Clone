using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallManager : MonoBehaviour
{
    ParticleSystem explosionFx;
    int ballIndex;

    // Start is called before the first frame update
    void Start()
    {
        explosionFx = transform.GetChild(0).GetComponent<ParticleSystem>();
        ballIndex = transform.position.x > 0 ? 0 : 1;// eğer topun x pozisyonu sıfırdan büyük ise o mor top(index 0)
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
            Splatters.Instance.AddSplatter(other.transform, other.contacts[0].point, ballIndex);
            PlayerMovement.Instance.Restart();
        }
    }
}
