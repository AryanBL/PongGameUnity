using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [Header("----------AudioSource------------")]
    [SerializeField] private AudioSource BackGroundSource;
    [SerializeField] private AudioSource SFXSource;
    [Header("----------AudioClip------------")]
    public AudioClip BackGroundMusic;
    public AudioClip CollisionMusic;
    public AudioClip ScoreMusic;

    // Start is called before the first frame update
    void Start()
    {
        BackGroundSource.clip = BackGroundMusic;
        BackGroundSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }


}
