using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private int Angle;
    [SerializeField] private float Force;
    private void OnCollisionEnter(Collision collision)
    {
      collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Angle, 90, 0) * Force, ForceMode.Force);
    }
}
