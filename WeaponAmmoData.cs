public struct WeaponAmmoData
{
    public readonly int RemainingInClip;
    public readonly int RemainingOutOfClip;
    public WeaponAmmoData(int remainingInClip, int remainingOutOfClip)
    {
        RemainingInClip = remainingInClip;
        RemainingOutOfClip = remainingOutOfClip;
    }
}