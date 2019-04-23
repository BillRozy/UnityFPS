using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    // Start is called before the first frame update

    public virtual void ReactToHit() {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior) {
            behavior.alive = false;
        }
        StartCoroutine(Die());
    }

    private IEnumerator Die(){
        transform.Rotate(-90, transform.rotation.y, transform.rotation.z);
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
