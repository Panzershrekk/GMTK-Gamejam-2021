using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameUIManager : MonoBehaviour
{
    public GameManager GameManager;
    public Image SharkLifeFill;
    public Image BoatLifeFill;

    public GameObject WinUI;
    public GameObject LooseUI;
    public TextMeshProUGUI timerText;
    public void UpdateUI()
    {
        SharkLifeFill.fillAmount = GameManager.CharacterBehaviour.currentHealth / GameManager.CharacterBehaviour.maxHitpoint;
        BoatLifeFill.fillAmount = GameManager.BoatBehaviour.currentHealth / GameManager.BoatBehaviour.maxHitpoint;
    }

    public void EndUI(bool victory)
    {
        if (victory == true)
        {
            WinUI.SetActive(true);
            timerText.text = GameManager.endTime;
        }
        else
        {
            LooseUI.SetActive(true);
        }
    }
}
