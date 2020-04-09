using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
[GenerateAuthoringComponent]
public struct prefabData : IComponentData
{
    public Entity prefabEntity;
    //public Entity ground;
}
