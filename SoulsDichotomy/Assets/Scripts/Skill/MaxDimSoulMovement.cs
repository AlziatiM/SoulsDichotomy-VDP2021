using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MaxDimSoulMovement", menuName = "Skill/MaxDimSoulMovement", order = 1)]
public class MaxDimSoulMovement : Skill
{
    [Header("Affect only player")]
    [SerializeField] private Vector3 newScale;
    public override void AttachSkill(PlayerInput player, SoulController soul)
    {
        if (affectPlayer)
        {
            player.SetScaleToSoulPanel(newScale);
        }
    }
}
