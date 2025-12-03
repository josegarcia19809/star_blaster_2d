using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting SFX")]
    [SerializeField] private AudioClip shootingClip;

    [SerializeField] [Range(0, 1)] private float shootingVolume = 1f;

    [Header("Damage SFX")]
    [SerializeField] private AudioClip damageClip;

    [SerializeField] [Range(0, 1)] private float damageVolume = 1f;

    static AudioManager instance;

    public static AudioManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        ManageSingleton();
    }

    public void PlayShootingSFX()
    {
        PlayAudioClip(shootingClip, shootingVolume);
    }

    void ManageSingleton()
    {
        // int instanceCount = FindObjectsByType<AudioManager>(FindObjectsSortMode.None).Length;
        // if (instanceCount > 1)
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayDamageSFX()
    {
        PlayAudioClip(damageClip, damageVolume);
    }

    void PlayAudioClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
    }
}