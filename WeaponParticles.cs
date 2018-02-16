using UnityEngine;
[RequireComponent(typeof(Weapon))]
public class WeaponParticles : MonoBehaviour
{
    [SerializeField]
    private GameObject _muzzleFlashParticlePrefab;
    [SerializeField]
    private Transform _muzzleFlashTransform;

    void Start()
    {
        GetComponent<Weapon>().OnWeaponFired += SpawnMuzzleFlash;
    }

    private void SpawnMuzzleFlash() //change to pooling system later
    {
        var particle = Instantiate(_muzzleFlashParticlePrefab, _muzzleFlashTransform.position, _muzzleFlashTransform.rotation);
        Destroy(particle, 1f);
    }
}