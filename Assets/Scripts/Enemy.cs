using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed;

    Transform _ball;

    void Start()
    {
        _ball = GameObject.Find("Ball").transform;
    }

    void Update()
    {
        var ballPosX = _ball.position.x;
        Vector3 destination = new Vector3(ballPosX, transform.position.y, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, destination, _speed * Time.deltaTime);
    }

    public void AddSpeed(float _amount)
    {
        _speed += _amount;
    }
}
