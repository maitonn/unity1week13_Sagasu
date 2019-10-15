using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	EntityManager m_entityManager = null;
	[SerializeField]
	Material m_material;
	[SerializeField]
	Mesh m_mesh;
	// Start is called before the first frame update
	void Start()
	{
		m_entityManager = World.Active.EntityManager;
		// entityの型作り
		Entity entity = m_entityManager.CreateEntity(
			typeof(SphereCollisionComponent),
			typeof(Translation),
			typeof(LocalToWorld)
		);
		m_entityManager.AddSharedComponentData(entity, new RenderMesh
		{
			castShadows = UnityEngine.Rendering.ShadowCastingMode.On, receiveShadows = true,
			material = m_material, mesh = m_mesh
		});
		// インスタンス化
		const int createFieldSize = 5;
		for (int x = 0; x < createFieldSize; ++x)
		{
			for (int y = 0; y < createFieldSize; ++y)
			{
				for (int z = 0; z < createFieldSize; ++z) {
					m_entityManager.SetComponentData(entity, new Translation() { Value = new Vector3(x, y, z) });
					m_entityManager.Instantiate(entity);
				}
			}
		}
	}
}
