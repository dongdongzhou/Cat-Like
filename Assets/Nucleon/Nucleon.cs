using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Nucleon : MonoBehaviour
{
    private Rigidbody rBody;
    public float attractionForce;

    private void Awake()
    {
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rBody.AddForce(transform.localPosition * -attractionForce);
    }
}