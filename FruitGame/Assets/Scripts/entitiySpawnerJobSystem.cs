using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Transforms;
using Unity.Jobs;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Burst;


public class entitiySpawnerJobSystem: MonoBehaviour
{

}
//[AlwaysSynchronizeSystem]
//public class entitiySpawnerJobSystem : JobComponentSystem
//{
//    [BurstCompile]
//    private struct SpawnJob : IJobForEachWithEntity<prefabData>
//    {
//        public EntityCommandBuffer.Concurrent entityCommandBuffer;
//        public void Execute(Entity entity, int index, ref prefabData c0)
//        {
//            throw new System.NotImplementedException();
//        }
//    }
//    private int count = 0;
//    private EndSimulationEntityCommandBufferSystem e;
//    //JobHandle jobHandle;

//    protected override void OnCreate()
//    {
//        e = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
//        base.OnCreate();
//    }


//    protected override JobHandle OnUpdate(JobHandle inputDeps)
//    {
//        SpawnJob job = new SpawnJob
//        {
//            entityCommandBuffer = e.CreateCommandBuffer().ToConcurrent(),
//        };
//        if (count == 0)
//        {
//            Entities.WithoutBurst().ForEach((in prefabData pre) =>
//            {

//                Entity spawnedEntity = EntityManager.Instantiate(pre.prefabEntity);
//                Debug.Log("hey");

//                EntityCommandBuffer.SetComponentData(spawnedEntity, new Translation
//                {
//                    Value = new float3(0, 0, 0)
//                });

//            }).Run();
//        }

//        count++;
//        return default;
//    }
//}
