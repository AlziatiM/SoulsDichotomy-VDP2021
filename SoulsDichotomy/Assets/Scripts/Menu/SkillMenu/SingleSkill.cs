using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SingleSkill : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private Skill mySkill;

    private void Start()
    {
        title.text = "Locked";
        description.text = "Unkown";
        icon.sprite = mySkill.imageNotActive;
        SetUp();
    }

    public string GetName()
    {
        return mySkill.nameS;
    }

    private void OnEnable()
    {
        SetUp();
    }

    private void SetUp()
    {
        if (mySkill.IsUnlock())
        {
            Unlock();
        }
    }

    public void Unlock()
    {
        title.text = mySkill.nameS;
        description.text = mySkill.description;
        icon.sprite = mySkill.imageActive;
    }

}
