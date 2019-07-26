using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    public static PlayerSprite Instance;
    private void Awake() => Instance = this;
    private Animator animator;

    [SerializeField]
    private GameObject JumpParticleEffect = null;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {

    }

    public void ActivateJumpAnimation()
    {
        animator.SetTrigger("jump");
        Instantiate(JumpParticleEffect, new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z), JumpParticleEffect.transform.rotation);
    }
}
