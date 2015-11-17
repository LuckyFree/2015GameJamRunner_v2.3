using UnityEngine;
using System.Collections;

public class Slot : MonoBehaviour
{
	#region Attributes

		// Slot content
		private SlotContent m_SlotContent = null;

	#endregion

	#region MonoBehaviour

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			// Get slot content
			m_SlotContent = GetComponentInChildren<SlotContent>();
		}

	#endregion

	#region Public Manipulators

		public AudioButton.EButtonID GetButtonID()
		{
			return m_SlotContent.GetButtonID();
		}

	#endregion
}
