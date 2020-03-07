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

    private float healthFloat;
    private float newHealth;

    public void Initialize(bool isLeft, Vestige v)
    {
        ourVestige = v;
        anim.SetBool("isLeft", isLeft);
    }

    public void SetNewHealth(float f)
    {
        newHealth = f;
    }

    void TakeHit()
    {
        blood.Emit(20);
        healthImage.fillAmount = newHealth;
        healthFloat = newHealth;
    }
}
