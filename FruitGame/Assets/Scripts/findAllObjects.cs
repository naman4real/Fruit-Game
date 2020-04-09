using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class findAllObjects : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
{
    public GameObject[] allObjects;
    public static GameObject[] allObjectsArray;
    public static Entity[] entityList;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        
        Entity[] entityList= new Entity[allObjects.Length];
        for (int i= 0;i < allObjects.Length;i++ )
        {
            entityList[i] = conversionSystem.GetPrimaryEntity(allObjects[i]);
        }
        findAllObjects.entityList = entityList;
    }

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {        
        foreach (GameObject go in allObjects)
        {
            referencedPrefabs.Add(go);
        }
    }

    void Awake()
    {
        entityList = new Entity[allObjects.Length];
        findAllObjects.allObjectsArray = allObjects;       
    }
}
