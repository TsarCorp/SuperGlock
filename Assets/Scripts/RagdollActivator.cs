using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RagdollActivator : MonoBehaviour
{
    public List<Rigidbody> Rigidbodies;

    void Start()
    {
        SetRagdollState(false);
    }

    public void SetRagdollState(bool active)
    {
        for (var rb = 0; rb < Rigidbodies.Count; rb++)
        {
            Rigidbodies[rb].isKinematic = !active;
        }
    }
}