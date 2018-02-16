using UnityEngine;
using Valve.VR;
public class WeaponTrigger : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    private uint controllerIndex;

    void Start()
    {
        controllerIndex = GetComponentInParent<SteamVR_TrackedController>().controllerIndex;
    }

    void Update()
    {
        var system = OpenVR.System;
        VRControllerState_t controllerState = default(VRControllerState_t);
        if (system != null && system.GetControllerState(controllerIndex, ref controllerState, (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(VRControllerState_t))))
        {
            float triggerPullPct = controllerState.rAxis1.x;
            _animator.Play("Trigger Pull", 1, triggerPullPct);
        }
    }
}