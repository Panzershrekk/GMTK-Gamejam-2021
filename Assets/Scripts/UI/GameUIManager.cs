using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public GameManager GameManager;
    public Image SharkLifeFill;
    public Image BoatLifeFill;

    public void UpdateUI()
    {
        SharkLifeFill.fillAmount = GameManager.CharacterBehaviour.currentHealth / GameManager.CharacterBehaviour.maxHitpoint;
        BoatLifeFill.fillAmount = GameManager.BoatBehaviour.currentHealth / GameManager.BoatBehaviour.maxHitpoint;
    }
}
