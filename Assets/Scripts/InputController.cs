using UnityEngine;

public class InputController : MonoBehaviour
{
    private void Update()
    {
        #region Mouse input
        if (!GameManager.instance.isLaunched)
        {
            if (Input.GetMouseButton(0))
            {
                SetPlayerPositionFromInput(GameManager.instance.player);
            }
            if (Input.GetMouseButtonUp(0))
            {
                LaunchBall();
                GameManager.instance.ResetPlayer();

                var arrow = GameManager.instance.arrow;
                arrow.gameObject.SetActive(false);
            }
        }
        #endregion
        #region Mobile input from touches
        /*
        if (Input.touchCount > 0 && !GameManager.instance.isLaunched
        {
            Debug.Log(Input.touchCount);

            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touch = SetPlayerPositionFromInput(touch, player); // VS2022 Refactoring lmao;
            }

            if (touch.phase != TouchPhase.Moved)
            {
                touch = SetPlayerPositionFromInput(touch, player); //TODO: Edit to proper funcs
            }

            if (touch.phase != TouchPhase.Ended)
            {
                LaunchBall(player, ball);
            }
        }
        */
        #endregion
    }

    private static void LaunchBall()
    {
        var player = GameManager.instance.player;
        var ball = GameManager.instance.ball;
        float distance = Vector3.Distance(ball.position, player.position);

        ball.GetComponent<Rigidbody>().AddForce((player.position - ball.position) * distance, ForceMode.VelocityChange);

        GameManager.instance.isLaunched = true;
        GameManager.instance.ResetPlayer();
    }

    private static void SetPlayerPositionFromInput(Transform player)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 pos = new Vector3(hit.point.x,
                                        hit.point.y + .5f,
                                        hit.point.z);

            player.position = pos;

            DrawArrowOnField();
        }

    }
    private static Touch SetPlayerPositionFromInput(Touch touch, Transform player)
    {
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 pos = new Vector3(hit.point.x,
                                        hit.point.y + .5f,
                                        hit.point.z);

            player.position = pos;
            DrawArrowOnField();
        }
        return touch;
    }

    static void DrawArrowOnField()
    {
        var arrow = GameManager.instance.arrow;

        if (!arrow.gameObject.activeInHierarchy) 
            arrow.gameObject.SetActive(true);
        arrow.GetComponent<Arrow>().DrawArrow();
    }
}
