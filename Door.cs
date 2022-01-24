using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private Animator _animator;
    private bool _isOpen;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        _isOpen = true;
        _animator.SetTrigger("Open");
    }

    public bool CanInteract()
    {
        return !_isOpen;
    }
}
