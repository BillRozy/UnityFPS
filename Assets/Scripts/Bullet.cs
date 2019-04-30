using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    public float hitForce = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Bullet trigger");
        ReactiveTarget target = other.gameObject.GetComponent<ReactiveTarget>();
        if (other.gameObject.GetComponent<PlayerCharacter>() != null) {
            return;
        }
        if (explosionPrefab) {
            GameObject explosion = Instantiate(explosionPrefab);
            explosion.transform.position = this.transform.position;
        }
        if (target != null) {
            target.ReactToHit(this.transform.forward, hitForce);
        }
        Destroy(this.gameObject);
    }
}
