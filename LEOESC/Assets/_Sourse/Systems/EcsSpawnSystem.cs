using Leopotam.EcsLite;
using UnityEngine;

namespace Client
{
    sealed class EcsSpawnSystem : IEcsInitSystem
    {
        private EcsFilter _filter;
        private EcsPool<EcsSpawnerComponent> _escPool;
        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<EcsSpawnerComponent>().End();
            _escPool = world.GetPool<EcsSpawnerComponent>();

            foreach (int entity in _filter)
            {
                ref EcsSpawnerComponent testComponent = ref _escPool.Get(entity);
                ref var prefab = ref testComponent.Prefab;
                ref var amount = ref testComponent.Amount;

                for (int i = 0; i < amount; i++)
                {
                    GameObject prefabInstance = GameObject.Instantiate(prefab);
                    prefabInstance.transform.position = new Vector3(Random.Range(-100, 100), 0f, Random.Range(-100, 100));
                }
            }
        }
    }
}