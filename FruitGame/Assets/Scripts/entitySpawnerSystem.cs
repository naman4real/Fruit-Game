using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class entitySpawnerSystem : ComponentSystem
{
    private int count = 0;
    private Transform env;
    protected override void OnStartRunning()
    {

    }
    protected override void OnUpdate()
    {
        if (count == 0)
        {
            Entities.ForEach((ref prefabData pre) =>
            {

                Entity spawnedEntity = EntityManager.Instantiate(pre.prefabEntity);
                Debug.Log("hey");
                EntityManager.SetComponentData(spawnedEntity, new Translation
                {
                    Value = new float3(0, 0, 0)
                });

            });
        }


        count++;

    }
}

//public class entitySpawnerSystem: MonoBehaviour
//{

//}
