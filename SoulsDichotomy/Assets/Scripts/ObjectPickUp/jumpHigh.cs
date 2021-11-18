using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHigh : PickUp
{
    [Header("Wall jump attributes")]
    [SerializeField] private float maxJumpHeight;
    [SerializeField] private float minJumpHeight;
    
    private float maxJumpHeightToRestore;
    private float minJumpHeightToRestore;
    public override void ApplyPlayer()
    {
        PlayerVelocity pv = player.GetComponent<PlayerVelocity>();

        maxJumpHeightToRestore = pv.MaxJumpHeight;
        pv.MaxJumpHeight = maxJumpHeight;
        
        minJumpHeightToRestore = pv.MinJumpHeight;
        pv.MinJumpHeight = minJumpHeight;

    }
    public override void ApplySoul()
    {
        throw new System.NotImplementedException();
    }
    public override void RemovePlayer()
    {
        player.GetComponent<PlayerVelocity>().MaxJumpHeight = maxJumpHeightToRestore;
        player.GetComponent<PlayerVelocity>().MinJumpHeight = minJumpHeightToRestore;
    }
    public override void RemoveSoul()
    {
        throw new System.NotImplementedException();
    }
}
