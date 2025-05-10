using UnityEngine;
using System.Collections;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField]
    public CreatureType CurrentCreatureType = CreatureType.None;
    
    [SerializeField] 
    protected GameObject AmmoRef = null;
    
    [SerializeField] 
    protected Transform ShootPoint;
    
    [SerializeField] 
    protected float ShootInterval = 0.5f;

    private bool ReadyToShoot = true;

    public abstract void Attack(GameObject User);

    public IEnumerator Shoot(GameObject User)
    {
        ReadyToShoot = false;
        yield return new WaitForSeconds(ShootInterval);
        Instantiate(AmmoRef, User.transform.position, Quaternion.identity);
        Attack(User);
        ReadyToShoot = true;
    }

    public bool IsReady()
    {
        return ReadyToShoot;
    }
}