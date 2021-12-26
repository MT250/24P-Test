using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ball"))
        {
            gameObject.SetActive(false);
            GameManager.instance.GoalHit();
        }
    }
}
