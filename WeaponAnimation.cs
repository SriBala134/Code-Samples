using UnityEngine;
public class WeaponAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    
    void Start()
    {
        GetComponent<Weapon>().OnWeaponFired += () => _animator.SetTrigger("Fire");
        GetComponent<WeaponAmmo>().OnReloadStarted += () => _animator.SetTrigger("Reload");
    }

    
}