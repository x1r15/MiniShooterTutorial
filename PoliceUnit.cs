using TMPro;
using UnityEngine;

public class PoliceUnit : MonoBehaviour, IHittable
{
        [SerializeField] private string[] shouts;
        [SerializeField] private GameObject shoutPrefab;

        public void ReceiveHit(RaycastHit2D hit)
        {
                Shout();
        }
        
        private void Shout()
        {
                var shout = shouts[Random.Range(0, shouts.Length)];
                var shoutObj = Instantiate(shoutPrefab, transform.position, Quaternion.identity);
                shoutObj.GetComponentInChildren<TextMeshPro>().text = shout;
        }
}