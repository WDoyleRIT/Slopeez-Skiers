using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    // Implementing Singleton pattern for AudioManager
    public static AudioManager Instance { get; private set; }
    // Audio Source component of audio manager
    [SerializeField] private AudioSource sfxSource;

    // Sound effects go here
    public AudioClip coinSFX;

    private void Awake()
    {
        // Enforce Singleton pattern and persist across scenes
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set volume to global volume level if needed
        if (sfxSource.volume != GlobalVar.Instance.volumeLevel)
        {
            sfxSource.volume = GlobalVar.Instance.volumeLevel;
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        // Check if the clip is null to avoid errors
        if (clip == null)
        {
            Debug.LogWarning("AudioManager: Attempted to play a null AudioClip.");
            return;
        }
        
        // Set volume to global volume level if needed
        if(sfxSource.volume != GlobalVar.Instance.volumeLevel)
        {
            sfxSource.volume = GlobalVar.Instance.volumeLevel;
        }

        // Play the Sound Effect
        sfxSource.PlayOneShot(clip);
    }
}
