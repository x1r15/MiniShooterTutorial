using TMPro;
using UnityEngine;

public class Computer : MonoBehaviour, IInteractable
{
    [SerializeField] private string[] _messages;
    [SerializeField] private GameObject _messagePrefab;
    public void Interact()
    {
        var randomIndex = Random.Range(0, _messages.Length);
        var message = _messages[randomIndex];
        var msgObject = Instantiate(_messagePrefab, transform.position, Quaternion.identity);
        msgObject.GetComponentInChildren<TMP_Text>().SetText(message);
    }

    public bool CanInteract()
    {
        return _messages != null && _messages.Length > 0;
    }
}
