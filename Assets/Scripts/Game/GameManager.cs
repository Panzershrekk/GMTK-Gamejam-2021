using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool GameStarted = false;
    public CharacterBehaviour CharacterBehaviour;
    public BoatBehaviour BoatBehaviour;
    public GameUIManager GameUIManager;

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
