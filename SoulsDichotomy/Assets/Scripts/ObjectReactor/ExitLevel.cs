using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour, IReact
{
    public void React()
    {
        LevelManager.instance.SetCurrentAsDone();
        LevelManager.instance.NextLevel();
    }
}
