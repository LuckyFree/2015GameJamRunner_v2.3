using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlotContent : MonoBehaviour
{
	#region Attributes

		// Button ID
		[SerializeField]
		private AudioButton.EButtonID m_ButtonID;

		// Slot content list
		private static List<SlotContent> s_SlotContentList = new List<SlotContent>();

		// Rect transform
		private RectTransform m_RectTransform = null;

		// Original position
		private Vector3 m_OriginalPosition;

	#endregion

	#region MonoBehaviour

		// Called at creation
		void Awake()
		{
			s_SlotContentList.Add(this);
		}

		// Use this for initialization
		void Start()
		{
			// Get rect transform
			m_RectTransform = GetComponent<RectTransform>();

			// Original position
			m_OriginalPosition = transform.position;
		}

	#endregion

	#region Getters & Setters
		
		/// <summary>
		/// Get button ID
		/// </summary>
		/// <returns></returns>
		public AudioButton.EButtonID GetButtonID()
		{
			return m_ButtonID;
		}

		/// <summary>
		/// Set original position
		/// </summary>
		/// <param name="position"></param>
		public void SetOriginalPosition(Vector3 position)
		{
			m_OriginalPosition = position;
		}

		/// <summary>
		/// Get original position
		/// </summary>
		/// <returns></returns>
		public Vector3 GetOriginalPosition()
		{
			return m_OriginalPosition;
		}

	#endregion

	#region Static Manipulators

		/// <summary>
		/// Get slot content at touch position
		/// </summary>
		/// <param name="touchPosition"></param>
		/// <returns></returns>
		public static SlotContent GetSlotContentAtTouchPosition(Vector2 touchPosition, SlotContent slotContentToIgnore)
		{
			for (int i = 0; i < s_SlotContentList.Count; i++)
			{
				if (s_SlotContentList[i] != null && s_SlotContentList[i] != slotContentToIgnore)
				{
					if (RectTransformUtility.RectangleContainsScreenPoint(s_SlotContentList[i].m_RectTransform, touchPosition))
					{
						return s_SlotContentList[i];
					}
				}
			}

			return null;
		}

	#endregion
}
