using UnityEngine;
using System.Collections;

public class TrainController : MonoBehaviour
{
	#region Attributes

		// Offset multiplier (between 0 and 1)
		[SerializeField]
		private float m_OffsetMultiplier = 0.5f;

		// Start offset
		[SerializeField]
		private Transform m_StartOffset = null;

		// End offset
		[SerializeField]
		private Transform m_EndOffset = null;

		// Lerp factor
		private float m_HorizontalOffsetLerpT = 0;

		// Movement speed
		[SerializeField]
		private float m_MovementSpeed = 1;

		// Instance
		private static TrainController s_Instance = null;

	#endregion

	#region MonoBehaviour

		// Called at creation
		void Awake()
		{
			if (s_Instance != null)
			{
				Debug.LogWarning("2 TrainController in scene, last removed");
				GameObject.Destroy(gameObject);
			}
			else
			{
				s_Instance = this;
			}
		}

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			// Update position
			UpdatePosition();
		}

	#endregion

	#region Private Manipulators

		/// <summary>
		/// Update position on horizontal offset
		/// </summary>
		private void UpdatePosition()
		{
			Vector3 position = transform.position;
			Vector3 horizontalOffset = m_EndOffset.position - m_StartOffset.position;

			m_HorizontalOffsetLerpT += Time.deltaTime;
			position.x = Mathf.Lerp(m_StartOffset.position.x, m_EndOffset.position.x, m_OffsetMultiplier);
			position.x = Mathf.Lerp(transform.position.x, position.x, m_HorizontalOffsetLerpT * m_MovementSpeed);

			transform.position = position;
		}

	#endregion

	#region Public Manipulators

		/// <summary>
		/// Decrease offset multiplier with specified value
		/// </summary>
		/// <param name="value">Decrease step</param>
		public void DecOffsetMultiplier(float value)
		{
			float offsetMultiplier = Mathf.Clamp(m_OffsetMultiplier - Mathf.Abs(value), 0, 1);
			m_OffsetMultiplier = offsetMultiplier;
			m_HorizontalOffsetLerpT = 0;
		}

		/// <summary>
		/// Increase offset multiplier with specified value
		/// </summary>
		/// <param name="value">Increase step</param>
		public void IncOffsetMultiplier(float value)
		{
			float offsetMultiplier = Mathf.Clamp(m_OffsetMultiplier + Mathf.Abs(value), 0, 1);
			m_OffsetMultiplier = offsetMultiplier;
			m_HorizontalOffsetLerpT = 0;
		}

	#endregion

	#region Static Manipulators
		
		/// <summary>
		/// Get instance
		/// </summary>
		/// <returns></returns>
		public static TrainController GetInstance()
		{
			return s_Instance;
		}

	#endregion
}
