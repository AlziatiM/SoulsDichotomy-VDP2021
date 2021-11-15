using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : PickUp
{
    
    public override void ApplyPlayer()
    {
        player.GetComponent<PlayerVelocity>().wallJump = new Vector2(15,15);
        player.GetComponent<PlayerVelocity>().wallJumpClimb = new Vector2(5,15);
        player.GetComponent<PlayerVelocity>().wallLeapOff = new Vector2(15,5);

    }
    public override void ApplySoul()
    {
        throw new System.NotImplementedException();
    }
    public override void RemovePlayer()
    {
        player.GetComponent<PlayerVelocity>().wallJump = new Vector2(0,0);
        player.GetComponent<PlayerVelocity>().wallJumpClimb = new Vector2(0,0);
        player.GetComponent<PlayerVelocity>().wallLeapOff = new Vector2(0,0);
    }
    public override void RemoveSoul()
    {
        throw new System.NotImplementedException();
    }
}