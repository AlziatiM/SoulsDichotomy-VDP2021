using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private PlayerInput player;
    [SerializeField] private SoulController soul;
    
    [SerializeField] private Skill[] skillTree;

    public static SkillManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void NewLevelToLoad(int levelToLoad)
    {
        foreach (Skill s in skillTree)
        {
            if (s.GetLeveUnlock() == levelToLoad)
            {
                UnlockSkill(s);
            }
        }
    }

    public void LoadLevelFromScratch(int levelToLoad)
    {
        foreach (Skill s in skillTree)
        {
            if (s.GetLeveUnlock() <= levelToLoad)
            {
                UnlockSkill(s);
            }
        }
    }

    public void SetUpCharacters(PlayerInput pi, SoulController sc)
    {
        player = pi;
        soul = sc;
    }

    public Skill[] GetSkills()
    {
        return skillTree;
    }

    private void UnlockSkill(Skill s)
    {
        s.AttachSkill(player, soul);
        s.SetIsUnlock(true);
        SkillMenu.instance.UnlockSkill(s.name);
    }

}
