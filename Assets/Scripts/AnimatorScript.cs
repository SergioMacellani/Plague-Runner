using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    public Animator[] anim;

    public void Idle()
    {
        anim[0].SetLayerWeight(1, 0);
        anim[1].SetLayerWeight(1, 0);
        anim[2].SetLayerWeight(1, 0);
        anim[3].SetLayerWeight(1, 0);
    }
    public void Run()
    {
        anim[0].SetLayerWeight(1, 1);
        anim[1].SetLayerWeight(1, 1);
        anim[2].SetLayerWeight(1, 1);
        anim[3].SetLayerWeight(1, 1);
    }
    public void Jump()
    {
        anim[0].Play("Run.Jump 1", 1);
        anim[1].Play("Run.Jump 1", 1);
        anim[2].Play("Run.Jump 1", 1);
        anim[3].Play("Run.Jump 1", 1);
    }
    public void AJump()
    {
        anim[0].SetBool("Jump", false);
        anim[1].SetBool("Jump", false);
        anim[2].SetBool("Jump", false);
        anim[3].SetBool("Jump", false);
    }
    public void Attack()
    {
        anim[0].Play("Run.Attack", 1);
        anim[1].Play("Run.Attack", 1);
        anim[2].Play("Run.Attack", 1);
        anim[3].Play("Run.Attack", 1);
    }
    public void Die()
    {
        anim[0].SetBool("Die", true);
        anim[1].SetBool("Die", true);
        anim[2].SetBool("Die", true);
        anim[3].SetBool("Die", true);
    }

    public void TutoJump()
    {
        anim[0].SetLayerWeight(1, 1);
        anim[0].Play("Jump", 1);
    }
    public void TutoAttack()
    {
        anim[0].SetBool("Attack", true);
        anim[0].Play("Tutorial.Attack", 1);
    }
    public void TutoIdle()
    {
        anim[0].SetLayerWeight(1, 0);
    }
}
