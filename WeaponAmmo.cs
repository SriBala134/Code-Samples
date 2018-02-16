using System;
using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Weapon))]
public class WeaponAmmo : MonoBehaviour
{

    [SerializeField]
    private int _startingAmmo = 18; 
    [SerializeField]
    private int _clipSize = 6; //The amount of ammo the weapon can fire before needing to be reloaded
    [SerializeField]
    private float _reloadTime = 1f; // While reloading it can't be fired. = the animation time

    private int _remainingAmmoOutOfClip;
    private int _remainingAmmoInClip;

    public event Action OnReloadStarted = () => { };
    public event Action OnReloadCompleted = () => { };
    public event Action<WeaponAmmoData> OnAmmoChange = (weaponAmmoData) => { };

    public bool IsReloading { get; private set; }

    void Awake()
    {
        _remainingAmmoOutOfClip = _startingAmmo;
    }

    public bool CheckHasAmmoInClip()
    {
        return _remainingAmmoInClip > 0;
    }

    public void TakeAmmo()
    {
        _remainingAmmoInClip--;
        SendAmmoChanged();
    }

    private void SendAmmoChanged()
    {
        OnAmmoChange(new WeaponAmmoData(_remainingAmmoInClip, _remainingAmmoOutOfClip));
    }

    public void Reload()
    {
        if (IsReloading == false)
        {
            StartCoroutine(ReloadAsync());
        }
    }

    private IEnumerator ReloadAsync()
    {
        int desiredAmmoToMove = _clipSize - _remainingAmmoInClip;
        desiredAmmoToMove = Mathf.Max(desiredAmmoToMove, 0);
        int ammoToMove = Math.Min(desiredAmmoToMove, _remainingAmmoOutOfClip);
        if (ammoToMove > 0)
        {
            IsReloading = true;
            OnReloadStarted();
            yield return new WaitForSeconds(_reloadTime);
            _remainingAmmoInClip += ammoToMove;
            _remainingAmmoOutOfClip -= ammoToMove;
            IsReloading = false;
            OnReloadCompleted();
            SendAmmoChanged();
        }
    }
}