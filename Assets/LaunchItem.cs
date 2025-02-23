using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchItem : MonoBehaviour
{
    [SerializeField] GameObject item;         // The item you want to launch
    [SerializeField] Transform targetObject;  // The object you are launching toward
    [SerializeField] float launchForce = 10f; // The force with which to launch the item
    [SerializeField] float waitTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LaunchAtRandomIntervals());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LaunchAtRandomIntervals()
    {
        while (true)
        {
            // Wait for a random amount of time between 1 and 3 seconds
            float waitTimer = Random.Range(1f, waitTime);
            yield return new WaitForSeconds(waitTimer);

            // Launch the item
            Launch();
        }
    }

    void Launch()
    {
        //Vector3 spawnPosition = targetObject.position + targetObject.forw

        var newObject = Instantiate(item, transform.position, Quaternion.identity);

        // Calculate direction from cube to target object
        Vector3 direction = (targetObject.position - transform.position).normalized;

        // Get the Rigidbody of the item
        Rigidbody itemRigidbody = newObject.GetComponent<Rigidbody>();

        if (itemRigidbody != null)
        {
            // Apply force to the item in the calculated direction
            itemRigidbody.AddForce(direction * launchForce, ForceMode.Impulse);
        }
    }
}
