using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour, IReact
{
    public void React()
    {
        AudioManager.instance.PlaySound("EndLevel");

        ScoreManager.instance.StopScore();
        LevelManager.instance.SetCurrentAsDone();
        LevelManager.instance.NextLevel();
    }
}
