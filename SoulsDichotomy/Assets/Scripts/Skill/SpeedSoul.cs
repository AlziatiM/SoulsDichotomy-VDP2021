using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SpeedSoul", menuName = "Skill/SpeedSoul", order = 1)]
public class SpeedSoul : Skill
{
    public int newMoveSpeed;
    public override void AttachSkill(PlayerInput player, SoulController soul)
    {
        if (affectSoul)
        {
            soul.movementSpeed = newMoveSpeed;
        }
    }
}
