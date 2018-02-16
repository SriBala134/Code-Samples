using UnityEngine;
using TMPro;
public class WeaponAmmoDisplay : MonoBehaviour
{
    TextMeshProUGUI ammoText;


    private void Awake()
    {
        GetComponentInParent<WeaponAmmo>().OnAmmoChange += HandleAmmoChanged;
    }

    void Start()
    {
        ammoText = GetComponent<TextMeshProUGUI>();
    }
    private void HandleAmmoChanged(WeaponAmmoData weaponAmmoData)
    {
        ammoText.text = string.Format("{0} / {1}", weaponAmmoData.RemainingInClip, weaponAmmoData.RemainingOutOfClip);
    }
}