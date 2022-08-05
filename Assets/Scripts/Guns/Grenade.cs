using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Grenade : MonoBehaviour
    {
        private float _damage;
        private float _powerOfExplotion;
        private float _radiousOfExplosion;
        private float _timeOfExplotion;

        private AudioSource _audioSource;
        private IExplodable _explodable;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void InitializeGrenade(float damage, float powerOfExplotion, float radiousOfExplosion, IExplodable explodable, float timeOfExplotion)
        {
            _damage = damage;
            _powerOfExplotion = powerOfExplotion;
            _radiousOfExplosion = radiousOfExplosion;
            _explodable = explodable;
            _timeOfExplotion = timeOfExplotion;
            StartCoroutine(StartTimerOfExplode());
        }

        private IEnumerator StartTimerOfExplode()
        {
            yield return new WaitForSeconds(_timeOfExplotion);
            _explodable.Explosion(gameObject.transform.position, _radiousOfExplosion, _powerOfExplotion, gameObject, _damage);
            Destroy(gameObject);
        }
    }
}
