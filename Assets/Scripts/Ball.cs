using UnityEngine;

public class Ball : MonoBehaviour
{

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            GameManager.instance.ResetBall();
        }
    }

    private void FixedUpdate()
    {
        if (_rb.velocity.magnitude <= 0f) GameManager.instance.ResetBall();
    }

    private void OnBecameInvisible()
    {
        GameManager.instance.ResetBall();
    }

}
