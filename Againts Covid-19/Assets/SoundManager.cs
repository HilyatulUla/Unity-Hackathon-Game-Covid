using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip musicongame, playerHitSound, cleanSound, jumpSound, enemyDeathSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        //musicongame = Resources.Load<AudioClip>("music");
        playerHitSound = Resources.Load<AudioClip>("playerHit");
        cleanSound = Resources.Load<AudioClip>("clean");
        jumpSound = Resources.Load<AudioClip>("jump");
        enemyDeathSound = Resources.Load<AudioClip>("enemyDeath");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound  (string clip)
    {
        //audioSrc.PlayOneShot(musicongame);
        switch (clip)
        {
            case "clean":
                audioSrc.PlayOneShot(cleanSound);
                break;
            case "playerHit":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "enemyDeath":
                audioSrc.PlayOneShot(enemyDeathSound);
                break;
        }
    }
}
