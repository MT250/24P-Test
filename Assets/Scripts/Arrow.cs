using UnityEngine;

public class Arrow : MonoBehaviour
{
    Transform _player;
    Transform _ball;

    private void OnEnable()
    {
        _player = GameManager.instance.player;
        _ball = GameManager.instance.ball;

        DrawArrow();
    }
    
    public void DrawArrow()
    {
        //Sets position of arrow between ball & player
        var midpoint = _player.position + (_ball.position - _player.position) / 2;
        transform.position = midpoint;

        Vector3 rotationTarget = _player.position;
        rotationTarget.y = 0f;
        rotationTarget.x -= _ball.position.x;
        rotationTarget.z -= _ball.position.z;

        //Changes rotation of arrow to point at player
        float angle = Mathf.Atan2(rotationTarget.z, rotationTarget.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(90, 0, angle)); 
        
        //Changes scale of arrow based on distance between ball & player
        float dis = Vector3.Distance(_ball.position, _player.position);
        Vector3 newScale = new Vector3(dis / 10, dis / 10, 1f); 

        transform.localScale = newScale;
    }
}
