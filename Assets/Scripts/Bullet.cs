using System.Collections;
using UnityEngine;

namespace Assets.Scripts {
    public class Bullet : MonoBehaviour {
        public float speed = 70f;
        public GameObject effects;

        private Transform target;

        // this method will be invoked to seek the target.
        public void Seek(Transform _target) {
            target = _target;
        }

        // Update is called once per frame
        void Update() {
            if (target == null) {
                Destroy(gameObject);
                return;
            }

            // follow the target
            Vector3 direction = target.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;
            if (direction.magnitude <= distanceThisFrame) {
                HitTarget();
                return;
            }
            transform.Translate(direction.normalized * distanceThisFrame, Space.World);

            // rotates to follow the target
            Quaternion q = Quaternion.LookRotation(target.transform.position - transform.position);
            transform.rotation = Quaternion.Euler(q.eulerAngles.z, 90, 0);



        }

        void HitTarget() {
            var effectsGO = (GameObject)Instantiate(effects, transform.position, transform.rotation);
            Destroy(effectsGO, 3f);
            Destroy(gameObject);
        }
    }
}