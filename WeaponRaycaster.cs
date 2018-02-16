using System.Linq;
using UnityEngine;
public class WeaponRaycaster : MonoBehaviour
{
    [SerializeField]
    private Transform _raycastStartPoint;
    [SerializeField]
    private float _fireDistance = 100f;

    void Start()
    {
        GetComponent<Weapon>().OnWeaponFired += HandleWeaponFired;
    }

    private void HandleWeaponFired()
    {
        Ray _ray = new Ray(_raycastStartPoint.position, _raycastStartPoint.forward);
        var hitInfos = Physics.RaycastAll(_ray, _fireDistance).OrderBy(t => t.distance); //this considers everything, but once it finds the closest it shoots, it breaks out of the loop so only one object is really hit
        foreach (var hit in hitInfos)
        {
            Shootable shootable = hit.collider.GetComponent<Shootable>();
            if (shootable != null)
            {
                shootable.TakeShot(hit);
                Debug.DrawRay(hit.point, hit.normal, Color.green, 10f);
                break;
            }
        }
    }
}