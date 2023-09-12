using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SuperPunch : MonoBehaviour
{
    [SerializeField] private ParticleSystem charge;
    [SerializeField] private ParticleSystem NucleoVFX;
    [SerializeField] private VisualEffect finalLaser;
    public void PlayCharge()
    {
        charge.Play();
    }
    public void PlayLaser()
    {
        finalLaser.Play();
        NucleoVFX.Play();
    }
}