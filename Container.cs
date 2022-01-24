using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Container : MonoBehaviour, IInteractable
{
    [SerializeField] private List<string> _itemsStored;
    [SerializeField] private GameObject _messagePrefab;


    public void Interact()
    {
        var item = _itemsStored[0];
        _itemsStored.RemoveAt(0);
        var msgObject = Instantiate(_messagePrefab, transform.position, Quaternion.identity);
        msgObject.GetComponentInChildren<TMP_Text>().SetText(item);
        var player = Object.FindObjectOfType<Player>();
        player.AddItemToInventory(item);
    }

    public bool CanInteract()
    {
        return _itemsStored != null && _itemsStored.Count > 0;
    }
}
