using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character
{
    Powder,
    Sky,
    Sunny,
    Freeze,
    Boots,
    Heart

}

public enum Difficulty
{
    Beginner,
    Intermediate,
    Expert
}

public class GlobalVar : MonoBehaviour
{
    public static GlobalVar Instance { get; private set; }

    public Character selectedCharacter;
    public Difficulty selectedDifficulty;
    public float volumeLevel = 1.0f; // Default volume level (max)
    private void Awake()
    {
        // Enforce the Singleton pattern to prevent duplicate managers
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Keeps this object alive across scenes
    }
}
