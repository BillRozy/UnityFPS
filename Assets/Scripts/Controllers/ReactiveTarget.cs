using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    // Start is called before the first frame update

    public virtual void ReactToHit(Vector3 hitDirection, float force) {
        WanderingAI behavior = GetComponent<WanderingAI>();
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        if (rigidBody) {
            rigidBody.AddForce(hitDirection * force);
        }
        if (behavior) {
            behavior.alive = false;
        }
        StartCoroutine(Die());
    }

    private IEnumerator Die(){
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
