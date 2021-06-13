using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool GameStarted = false;
    public CharacterBehaviour CharacterBehaviour;
    public BoatBehaviour BoatBehaviour;
    public GameUIManager GameUIManager;

    public Animator endGameAnimator;
    [HideInInspector]
    public string endTime;
    [HideInInspector]
    public bool PlayerInControl = true;
    public float OutOfControllTime;
    private float _nextControll;

    private float _totalTime;
    void Update()
    {
        if (GameStarted == true)
        {
            _totalTime += Time.deltaTime;
            if (PlayerInControl == false)
            {
                if (Time.time > _nextControll)
                {
                    PlayerInControl = true;
                }
            }
        }
    }

    public void LoseControl()
    {
        PlayerInControl = false;
        _nextControll = Time.time + OutOfControllTime;
    }

    public void RefreshUI()
    {
        GameUIManager.UpdateUI();
    }

    public void StartGame()
    {
        GameStarted = true;
    }

    public void FinishGame(bool victory)
    {
        GameStarted = false;
        endGameAnimator.Play("EndScreenIn");
        var ts = TimeSpan.FromSeconds(_totalTime);
        endTime = string.Format("{0:00}:{1:00}", ts.TotalMinutes, ts.Seconds);
        GameUIManager.EndUI(victory);
    }
}
