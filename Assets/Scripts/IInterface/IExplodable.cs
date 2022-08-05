using UnityEngine;

namespace Assets.Scripts
{
    public interface IExplodable
    {
        public void Explosion(Vector3 position, float distance, float powerOfExplotion, GameObject gameObject, float damage);
    }
}