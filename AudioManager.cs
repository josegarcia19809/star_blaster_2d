using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting SFX")] [SerializeField]
    private AudioClip shootingClip;

    [SerializeField] [Range(0, 1)] private float shootingVolume = 1f;

    [Header("Damage SFX")] [SerializeField]
    private AudioClip damageClip;

    [SerializeField] [Range(0, 1)] private float damageVolume = 1f;

    public void PlayShootingSFX()
    {
        PlayAudioClip(shootingClip, shootingVolume);
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