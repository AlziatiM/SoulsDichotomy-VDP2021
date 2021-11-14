using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Skill : ScriptableObject
{
    [SerializeField] protected bool isUnlock;
    [SerializeField] protected int levelUnlock;
    [SerializeField] protected bool affectPlayer;
    [SerializeField] protected bool affectSoul;
    public virtual void AttachSkill(PlayerInput player, SoulController soul)
    {

    }

    public bool IsUnlock()
    {
        return isUnlock;
    }

    public int GetLeveUnlock()
    {
        return levelUnlock;
    }
}
