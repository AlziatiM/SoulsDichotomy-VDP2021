using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSkill : MonoBehaviour
{
    internal Sprite activeSprite;
    private string nameSkill;
    private string description;

    public void Show()
    {
        SkillMenu.instance.SetTitleSkill(nameSkill);
        SkillMenu.instance.SetDescriptionSkill(description);
    }

    public void SetName(string value)
    {
        nameSkill = value;
    }

    public void SetDescription(string value)
    {
        description = value;
    }

    internal void SetActiveSprite(Sprite imageActive)
    {
        activeSprite = imageActive;
    }
}
