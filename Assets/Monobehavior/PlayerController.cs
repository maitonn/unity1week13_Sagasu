using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class PlayerController : MonoBehaviour, IConvertGameObjectToEntity
{
	Entity m_entity;
	EntityManager m_entityManager;
	[SerializeField]
	float m_speed = 10.0f;
	public void Convert( Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem )
	{
		m_entity = entity;
		m_entityManager = dstManager;

		m_entityManager.AddComponent(m_entity,typeof(SphereCollisionComponent));

	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		// めっちゃ雑なプレイヤー移動(transform直移動)
		transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * Time.deltaTime * m_speed);

		// component dataを設置
		m_entityManager.SetComponentData(m_entity, new Translation() { Value = transform.position }) ;
    }
}
