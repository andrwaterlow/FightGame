using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public sealed class Mine : MonoBehaviour
    {
        private float _timeOfExplotion;
        private float _powerOfExplotion;
        private float _radiousOfExplosion;
        private float _jump;
        private float _damage;

        private AudioSource _audioSource;
        private IExplodable _explodable;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void InitializeMine(float damage, float powerOfExplotion, float radiousOfExplosion, IExplodable explodable, float timeOfExplotion, float jump)
        {
            _damage = damage;
            _powerOfExplotion = powerOfExplotion;
            _radiousOfExplosion = radiousOfExplosion;
            _explodable = explodable;
            _timeOfExplotion = timeOfExplotion;
            _jump = jump;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<Rigidbody>(out var rigidbody))
            {
                JumpFrog();
                StartCoroutine(StartTimerOfExplode());
            }
        }

        private IEnumerator StartTimerOfExplode()
        {
            yield return new WaitForSeconds(_timeOfExplotion);
            _explodable.Explosion(gameObject.transform.position, _radiousOfExplosion, _powerOfExplotion, gameObject, _damage);
            Destroy(gameObject);
        }

        private void JumpFrog()
        {
            var frog = gameObject.transform.GetChild(0).GetComponent<Rigidbody>();

            frog.AddForce(Vector3.up * _jump, ForceMode.Impulse);
            frog.AddTorque(Random.insideUnitSphere * _jump * 10);
        }
    }
}

