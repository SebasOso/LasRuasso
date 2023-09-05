using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPunch : MonoBehaviour
{
    [SerializeField] private ParticleSystem superPunch;
    
    public void PlayPunch()
    {
        superPunch.Play();
    }
}
