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
                s.AttachSkill(player, soul);
            }
        }
    }

    public void LoadLevelFromScratch(int levelToLoad)
    {
        foreach (Skill s in skillTree)
        {
            if (s.GetLeveUnlock() <= levelToLoad)
            {
                s.AttachSkill(player, soul);
            }
        }
    }

    public void SetUpCharacters(PlayerInput pi, SoulController sc)
    {
        player = pi;
        soul = sc;
    }
}
