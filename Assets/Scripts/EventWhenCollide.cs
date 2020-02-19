using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class EventWhenCollide : MonoBehaviour
{
    [FormerlySerializedAs("CollideWithTag")] [SerializeField]
    private string collideWithTag;

    [FormerlySerializedAs("CallWhenCollide")] [SerializeField]
    private UnityEvent callWhenCollide;

    [FormerlySerializedAs("KillOnCollide")] [SerializeField]
    private bool killOnCollide;

    private void OnCollisionEnter(Collision other)
    {
        TreatCollideOrTriggerEvent(other.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        TreatCollideOrTriggerEvent(other.gameObject);
    }

    private void TreatCollideOrTriggerEvent(GameObject otherGameObject)
    {
        if (otherGameObject.CompareTag(collideWithTag))
        {
            callWhenCollide.Invoke();
            if (killOnCollide)
            {
                Destroy(gameObject);
            }
        }
    }
}
