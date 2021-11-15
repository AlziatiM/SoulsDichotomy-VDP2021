using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : PickUp
{
    [Header("Wall jump attributes")]
    [SerializeField] private Vector2 wallJump;
    [SerializeField] private Vector2 wallJumpClimb;
    [SerializeField] private Vector2 wallLeapOff;

    private Vector2 wallJumpToRestore;
    private Vector2 wallJumpClimbToRestore;
    private Vector2 wallLeapOffToRestore;
    public override void ApplyPlayer()
    {
        PlayerVelocity pv = player.GetComponent<PlayerVelocity>();

        wallJumpToRestore = pv.WallJump;
        pv.WallJump = wallJump;
        
        wallJumpClimbToRestore = pv.WallJumpClimb;
        pv.WallJumpClimb = wallJumpClimb;
        
        wallLeapOffToRestore = pv.WallLeapOff;
        pv.WallLeapOff = wallLeapOff;

    }
    public override void ApplySoul()
    {
        throw new System.NotImplementedException();
    }
    public override void RemovePlayer()
    {
        player.GetComponent<PlayerVelocity>().WallJump = wallJumpToRestore;
        player.GetComponent<PlayerVelocity>().WallJumpClimb = wallJumpClimbToRestore;
        player.GetComponent<PlayerVelocity>().WallLeapOff = wallLeapOffToRestore;
    }
    public override void RemoveSoul()
    {
        throw new System.NotImplementedException();
    }
}