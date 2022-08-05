using System;
using UnityEngine;

namespace Assets.Scripts
{
    public sealed class Explodable : IExplodable 
    {
        public bool Exploded = false;

        public void Explosion(Vector3 position, float distance, float powerOfExplotion, 
            GameObject gameObject, float damage)
        {
            var collisions = Physics.OverlapSphere(position, distance);
            float upWards = 1f;

            foreach (var collider in collisions)
            {
                if (collider.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
                {
                    ApplyDamage(collider, position, rigidbody.position, damage, distance);

                    rigidbody.AddExplosionForce(powerOfExplotion, position, distance, upWards, ForceMode.Impulse);
                    rigidbody.AddTorque(UnityEngine.Random.insideUnitSphere * powerOfExplotion);
                }
            }
            Exploded = true;
        }

        private void ApplyDamage(Collider collider, Vector3 centerOfExplosion, 
            Vector3 positionOfObject, float damage, float radiusOfExplosion)
        {
            if (collider.TryGetComponent<IDamagable>(out IDamagable damagable))
            {
                damagable.MakeDamage(DistanceDamage(centerOfExplosion,
                    positionOfObject, damage, radiusOfExplosion));
            }
        }

        private float DistanceDamage(Vector3 centerOfExplosion, Vector3 positionOfObject,
            float damage, float radiusOfExplosion ) 
        {
            var vector = centerOfExplosion - positionOfObject;
            var distanceOfObject = vector.sqrMagnitude;

            float countOfPart = 3;
            var highDamageDistance = radiusOfExplosion / countOfPart;

            if (distanceOfObject < highDamageDistance * highDamageDistance)
            {
                return damage;
            }
            else 
            {
                var ratio = 1f - (distanceOfObject / (radiusOfExplosion * radiusOfExplosion));
                return damage * ratio;
            }
        }
    }
}
