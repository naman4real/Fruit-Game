using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

//public class spawnerSystem : ComponentSystem
//{
//    private int count = 0;
//    protected override void OnUpdate()
//    {
//        if (count == 0)
//        {
//            for (int i = 0; i < findAllObjects.entityList.Length; i++)
//            {
//                Entity spawnedEntity = EntityManager.Instantiate(findAllObjects.entityList[i]);
//                PostU

//                EntityManager.SetComponentData(spawnedEntity, new Translation
//                {
//                    Value = findAllObjects.allObjectsArray[i].transform.position
//                });
//            }
//        }

//        count++;
//    }
//}

public class spawnerSystem : MonoBehaviour
{

}
