using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject[] goalBlocks;

    public Enemy enemy;
    public Transform ball;
    public Transform player;
    public Arrow arrow;

    //[HideInInspector]
    public bool isLaunched = false;
    //[HideInInspector]
    public bool isPaused = false;

    public int level = 1;
    public float enemySpeedIncrease;

    public static GameManager instance;

    Vector3 ballStartPosition;
    Vector3 playerStartPosition;

    private void Awake()
    {
        instance = this;

        ballStartPosition = ball.position;
        playerStartPosition = player.position;
    }
    public void ResetBall()
    {
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.position = ballStartPosition;

        isLaunched = false;
    }

    public void ResetPlayer()
    {
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
        enemy.AddSpeed(enemySpeedIncrease);
        level++;

        foreach (var item in goalBlocks)
        {
            item.SetActive(true);
        }

        UIController.instance.UpdateLevelText(level);
    }

    GameManager() { }
}