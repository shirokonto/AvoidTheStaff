using System;
using DataStructures.Variables;
using UnityEngine;

public class GemBehaviour : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private Vector3 rotationAngle;
    [SerializeField] private float rotationSpeed;

    private void Start()
    {
        //collectedGems.Set(0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationAngle * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            var gemCollector = player.GetComponent<GemCollector>();
            gemCollector.AddGem();
            Destroy(gameObject);
        }
    }
}
