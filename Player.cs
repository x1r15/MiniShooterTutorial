using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _gunPoint;
    [SerializeField] private GameObject _bulletTrail;
    [SerializeField] private float _weaponRange = 10f;
    [SerializeField] private Animator _muzzleFlashAnimator;

    private List<string> _inventory = new List<string>();

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        LookAtMouse();
        Move();
        Shoot();
    }

    public void AddItemToInventory(string item)
    {
        _inventory.Add(item);
        Debug.Log($"Added new item: {item}");
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _muzzleFlashAnimator.SetTrigger("Shoot");

            var hit = Physics2D.Raycast(
                _gunPoint.position,
                transform.up,
                _weaponRange
                );

            var trail = Instantiate(
                _bulletTrail,
                _gunPoint.position,
                transform.rotation
                );

            var trailScript = trail.GetComponent<BulletTrail>();

            if (hit.collider != null)
            {
                trailScript.SetTargetPosition(hit.point);
                var hittable = hit.collider.GetComponent<IHittable>();
                if (hittable != null)
                {
                    hittable.ReceiveHit(hit);
                }
            }
            else
            {
                var endPosition = _gunPoint.position + transform.up * _weaponRange;
                trailScript.SetTargetPosition(endPosition);
            }
        }
    }

    private void LookAtMouse()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = mousePos - new Vector2(transform.position.x, transform.position.y);
    }

    private void Move()
    {
        var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _rigidbody.velocity = input.normalized * _speed;
    }
}
