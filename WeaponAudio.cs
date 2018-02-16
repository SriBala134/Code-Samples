using UnityEngine;
[RequireComponent(typeof(Weapon))]
[RequireComponent(typeof(WeaponAmmo))]
[RequireComponent(typeof(AudioSource))]
public class WeaponAudio : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Played when the weapon fires")]
    private AudioClip _firedClip;

    [SerializeField]
    [Tooltip("Played when the trigger is pulled but no ammo is available.")]
    private AudioClip _NoAmmoFiredClip;

    [SerializeField]
    [Tooltip("Played when the weapon is reloading.")]
    private AudioClip _reloadClip;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        GetComponent<Weapon>().OnWeaponFired += PlayFiredClip;
        GetComponent<Weapon>().OnNoAmmoFired += PlayNoAmmoFiredClip;
        GetComponent<WeaponAmmo>().OnReloadStarted += PlayReloadClip;
    }

    private void PlayFiredClip()
    {
        _audioSource.PlayOneShot(_firedClip);
    }
    private void PlayNoAmmoFiredClip()
    {
        _audioSource.PlayOneShot(_NoAmmoFiredClip);
    }
    private void PlayReloadClip()
    {
        _audioSource.PlayOneShot(_reloadClip);
    }
}
