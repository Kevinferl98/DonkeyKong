using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public AudioSource walk;
    [SerializeField] AudioSource background;
    [SerializeField] AudioSource jump;
    [SerializeField] AudioSource death;
    [SerializeField] AudioSource intro;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public static AudioManager Instance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayWalk()
    {
        walk.Play();    
    }

    public void StopWalk()
    {
        walk.Stop();
    }

    public void PlayJump()
    {
        jump.Play();
    }

    public void PlayDeath()
    {
        death.Play();  
    }

    public void PlayIntro()
    {
        intro.Play();
    }

    public void PlayBackground()
    {
        background.Play();
    }
}
