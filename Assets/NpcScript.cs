using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcScript : MonoBehaviour
{
 public Animator animator;
    public void CloseToNpc()
    {
        animator.SetBool("IsOpen", true);
    }
    
    public void NotCloseToNpc()
    {
        animator.SetBool("IsOpen", false);
    }
    
    
    
    
}
