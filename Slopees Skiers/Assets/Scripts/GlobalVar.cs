using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character
{
    Red,
    Orange,
    Yellow,
    Green,
    Blue,
    Purple

}

public class GlobalVar : MonoBehaviour
{
    public static GlobalVar Instance { get; private set; }

    public Character selectedCharacter;
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
