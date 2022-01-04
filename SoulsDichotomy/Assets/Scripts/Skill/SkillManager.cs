using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private PlayerInput player;
    [SerializeField] private SoulController soul;
    
    [SerializeField] private Skill[] skillTree;

    public static SkillManager instance;

    private Skill skillToUnlock;
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
        foreach(Skill s in skillTree)
        {
            s.SetIsUnlock(false);
        }
    }

    public void NextLevelToLoad(int levelToLoad)
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
        skillToUnlock = s;
        StartCoroutine("WaitSkillMenu");
    }

    private IEnumerator WaitSkillMenu()
    {
        yield return new WaitUntil(()=>SkillMenu.instance != null);
        SkillMenu.instance.UnlockSkill(skillToUnlock.name);
        skillToUnlock = null;
    }

    internal bool AmIReady()
    {
        return player != null && soul != null;
    }

}
