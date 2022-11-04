using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeaponScript : MonoBehaviour
{
    public float damage;
    public float attackLength;
    [SerializeField] private GameObject brazos;
    private Animator anim;
    private AnimationClip animClip;
    [SerializeField] private string clipName;
    [SerializeField] private string idleClipName;
    public string boolName;
    public string idleBool;
    public float timeToAttack;
    public Sprite inventoryImage;
    public string changeBool;
    
    void Start()
    {
        anim = brazos.GetComponent<Animator>();
        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            if (clip.name == clipName)
            {
                animClip = clip;
                attackLength = animClip.length;
            }
        }
    }
}
