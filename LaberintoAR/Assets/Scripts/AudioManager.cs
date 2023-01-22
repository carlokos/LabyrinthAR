using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource key, goal;

    public void keySound()
    {
        key.Play();
    }

    public void goalSound()
    {
        goal.Play();
    }
}
