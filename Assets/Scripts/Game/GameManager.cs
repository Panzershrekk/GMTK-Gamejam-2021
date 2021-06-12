using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CharacterBehaviour CharacterBehaviour;
    public BoatBehaviour BoatBehaviour;
    public GameUIManager GameUIManager;

    public void RefreshUI()
    {
        GameUIManager.UpdateUI();
    }
}
