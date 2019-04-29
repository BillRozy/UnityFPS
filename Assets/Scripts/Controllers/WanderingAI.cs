using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab;

    public float speed = 1f;
    public float obstacleRange = 3f;

    public float fireRate = 1f; // seconds
    public float lastFireball = 0;

    private bool _alive = true;
    public bool alive {
        private get {
            return _alive;
        }
        set {
            _alive = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lastFireball = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive) {
            transform.Translate(0, 0, speed * Time.deltaTime);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit)) {
                GameObject hitObject = hit.transform.gameObject;
                if (Time.time - lastFireball > fireRate)
                {
                    GameObject fireball = Instantiate(fireballPrefab) as GameObject;
                    fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    fireball.transform.rotation = transform.rotation;
                    lastFireball = Time.time;
                }
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    Debug.Log("See player");
                }
                else if (hit.distance < obstacleRange) {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }
}
