using UnityEngine;

public class Crate : MonoBehaviour, IHittable
{
    private Coroutine _activeCoroutine;
    private float _transitionProgress;

    public void ReceiveHit(RaycastHit2D hit)
    {
        Destroy();
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
