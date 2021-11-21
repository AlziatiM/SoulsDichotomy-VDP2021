using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillMenu : Menu
{
    public static SkillMenu instance;
    [SerializeField] private GameObject container;
    [SerializeField] private GameObject boxPrefab;
    [SerializeField] private TextMeshProUGUI titleSkill;
    [SerializeField] private TextMeshProUGUI descriptionSkill;

    
    private Dictionary<string, GameObject> skills;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        Close();
        skills = new Dictionary<string, GameObject>();
        titleSkill.text = "Click an unlock skill to read the effect";
    }

    private new void Start()
    {
        this.gameObject.transform.SetParent(MenuManager.instance.transform);
        CreateSkill();
    }

    private void CreateSkill()
    {
        foreach(Skill s in SkillManager.instance.GetSkills())
        {
            GameObject go = Instantiate(boxPrefab, container.transform.position, Quaternion.identity);
            Image img = go.GetComponent<Image>();
            Button btn = go.GetComponent<Button>();
            SingleSkill snSk = go.GetComponent<SingleSkill>();
            snSk.SetDescription(s.description);
            snSk.SetName(s.name);
            snSk.SetActiveSprite(s.imageActive);
            img.sprite = s.imageActive;
            btn.interactable = false;
            btn.onClick.AddListener(snSk.Show);
            go.transform.SetParent(container.transform);
            skills.Add(s.name, go);
        }
    }

    internal void SetDescriptionSkill(string description)
    {
        descriptionSkill.text = description;
    }

    internal void SetTitleSkill(string name)
    {
        titleSkill.text = name;
    }

    internal void UnlockSkill(string name)
    {
        skills[name].GetComponent<Image>().sprite = skills[name].GetComponent<SingleSkill>().activeSprite;
        skills[name].GetComponent<Button>().interactable = true;
    }

}
