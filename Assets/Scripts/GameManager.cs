using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject[] goalBlocks;

    public Transform enemy;
    public Transform ball;
    public Transform player;
    public Transform arrow;

    public bool isLaunched = false;
    public bool isPaused = false;
    public int level = 1;

    public static GameManager instance;

    Vector3 ballStartPosition;
    Vector3 playerStartPosition;

    private void Awake()
    {
        instance = this;

        ball = GameObject.Find("Ball").transform;
        enemy = GameObject.Find("Enemy").transform;
        player = GameObject.Find("Player").transform;

        ballStartPosition = ball.position;
        playerStartPosition = player.position;

        Debug.Log(playerStartPosition);
    }
    public void ResetBall()
    {
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.position = ballStartPosition;

        isLaunched = false;

        Debug.Log("Ball reseted.");
    }

    public void ResetPlayer()
    {

        Debug.Log("Player reseted" + playerStartPosition);
        player.position = playerStartPosition;
    }


    public void GoalHit() //  TODO: Something better...
    {
        ResetBall();

        // Checks amount of active goal blocks
        int activeBlocks = 0;
        foreach (var item in goalBlocks)
        {
            if (item.activeInHierarchy == true) activeBlocks++;
        }

        if (activeBlocks == 0) IncreaseLevel();
    }

    private void IncreaseLevel()
    {
        enemy.GetComponent<Enemy>().AddSpeed(.5f);
        level++;

        foreach (var item in goalBlocks)
        {
            item.SetActive(true);
        }

        UIController.instance.UpdateLevelText(level);
    }

    GameManager() { }
}