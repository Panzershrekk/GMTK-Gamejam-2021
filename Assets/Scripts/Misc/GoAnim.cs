using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoAnim : MonoBehaviour
{
    public GameManager gameManager;

    public void AnimationFinished()
    {
        gameManager.StartGame();
    }
}
