using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    public float weaponImpulse = 1000f; 
    private Camera _cam;
    // Start is called before the first frame update
    void Start()
    {
        _cam = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnGUI() {
        int size = 12;
        float posX = _cam.pixelWidth / 2 - size / 4;
        float posY = _cam.pixelHeight / 2 - size / 4;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 point = new Vector3(_cam.pixelWidth / 2, _cam.pixelHeight / 2, 0);
            Ray ray = _cam.ScreenPointToRay(point);
            if (bulletPrefab) {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = _cam.transform.position;
                bullet.transform.rotation = _cam.transform.rotation;
                Rigidbody bulletBody = bullet.GetComponent<Rigidbody>();
                bulletBody.AddForce(ray.direction * weaponImpulse, ForceMode.Acceleration);
            }
            // if (Physics.Raycast(ray, out hit)) {
            //     GameObject hitObj = hit.transform.gameObject;
            //     ReactiveTarget target = hitObj.GetComponent<ReactiveTarget>();
            //     if (target != null) {
            //         target.ReactToHit();
            //     } else {
            //         StartCoroutine(SphereIndicator(hit.point));
            //     }
            // }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos) {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }
}
