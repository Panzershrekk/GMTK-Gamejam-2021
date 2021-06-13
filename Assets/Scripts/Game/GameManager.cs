using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool GameStarted = false;
    public CharacterBehaviour CharacterBehaviour;
    public BoatBehaviour BoatBehaviour;
    public GameUIManager GameUIManager;

    [HideInInspector]
    public bool PlayerInControl = true;
    public float OutOfControllTime;
    private float _nextControll;

    void Update()
    {
        if (PlayerInControl == false)
        {
            if (Time.time > _nextControll)
            {
                PlayerInControl = true;
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

    public void FinishGame()
    {
        GameStarted = false;
    }
}
