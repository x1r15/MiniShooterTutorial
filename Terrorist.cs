using UnityEngine;

public class Terrorist : MonoBehaviour, IHittable
{
    [SerializeField] private GameObject _blood;
    [SerializeField] private Transform _player;
    [SerializeField] private int hitPoints;

    public void GetDamaged(RaycastHit2D hitInfo)
    {
        Instantiate(_blood, hitInfo.point, Quaternion.Euler(hitInfo.normal));
        transform.up = _player.position - transform.position;
        hitPoints -= 1;
        if (hitPoints <= 0)
        {
            Destroy();
        }
    }

    public void ReceiveHit(RaycastHit2D hit)
    {
        GetDamaged(hit);
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
