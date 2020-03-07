using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{

    public ParticleSystem blood;
    public Image healthImage;
    public Animator anim;

    private Vestige ourVestige;
    private Character other;

    private float healthFloat;
    private float newHealth;

    public void Initialize(bool isLeft, Vestige v, Character other)
    {
        ourVestige = v;
        anim.SetBool("isLeft", isLeft);
        this.other = other;
    }

    public void SetNewHealth(float f)
    {
        newHealth = f;
        Debug.Log("new health is " + f);
    }

    public void Attack()
    {
        anim.SetTrigger("attack");
    }

    void TakeHit()
    {
        other.Bleed();
    }

    public void Bleed()
    {
        blood.Emit(20);
        healthImage.fillAmount = newHealth;
        healthFloat = newHealth;
    }
}
