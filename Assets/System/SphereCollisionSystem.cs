using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using Unity.Transforms;

public class SphereCollisionSystem : ComponentSystem
{
	protected override void OnUpdate()
	{

	}

	struct CollisionJob : IJobChunk
	{
		public Translation playerPos;

		public void Execute( ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex )
		{

		}
	}
}
