using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Weapon))]
public class WeaponHaptics : MonoBehaviour
{
    [SerializeField]
    [Range(500, 3999)] //outside this range wont work
     private ushort _hapticIntensity = 1000; //vibration strength

    [SerializeField]
    [Range(0.1f, 1f)]
    private float _hapticDuration = 0.1f;

    private Weapon _weapon;

    void Start()
    {
      
        _weapon = GetComponent<Weapon>();
        _weapon.OnWeaponFired += HandleWeaponFired;
  
        
    }

    private void HandleWeaponFired()
    {
        StartCoroutine(StartHapticFeedback());
    }
    private IEnumerator StartHapticFeedback()
    {
        var timeMultiplier = 1f / _hapticDuration;
        var device = SteamVR_Controller.Input((int)_weapon.ControllerIndex);

        print((int)_weapon.ControllerIndex);

        float count = 0;
        while (count < 1)
        {
            count += Time.deltaTime * timeMultiplier;
            yield return null;
        }
    }
}