using System;
using UnityEngine;

[RequireComponent(typeof(WeaponAmmo))]
[RequireComponent(typeof(WeaponAudio))]
public class Weapon : MonoBehaviour
{
    private WeaponAmmo _weaponAmmo;
    private SteamVR_TrackedController _controller;

    public event Action OnWeaponFired = () => { };
    public event Action OnNoAmmoFired = () => { };
    public uint ControllerIndex { get { return _controller.controllerIndex; } }

    void Awake()
    {
        _weaponAmmo = transform.GetComponent<WeaponAmmo>();
        _controller = GetComponentInParent<SteamVR_TrackedController>();
        _controller.TriggerClicked += (sender, eventArgs) => TryFire();
        _controller.Gripped += (sender, eventArgs) => _weaponAmmo.Reload();
        _weaponAmmo.Reload();
    }

    private void TryFire()
    {
        if (CheckCanFire())
        {
            Fire();
        }
        else
        {
            OnNoAmmoFired();
        }
    }

    private bool CheckCanFire()
    {
        return _weaponAmmo.CheckHasAmmoInClip() && _weaponAmmo.IsReloading == false;
    }

    private void Fire()
    {
        _weaponAmmo.TakeAmmo();
        OnWeaponFired();
    }
}
