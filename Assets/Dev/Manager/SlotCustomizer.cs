using UnityEngine;
using System.Collections;

public class SlotCustomizer : MonoBehaviour
{
	#region Attributes

		// Current slot content
		private SlotContent m_CurrentSlotContent = null;

		// Old slot content position
		private Vector3 m_OldSlotContentPosition = Vector3.zero;

		// Slots ID
		public static AudioButton.EButtonID SlotAID = AudioButton.EButtonID.ButtonA;
		public static AudioButton.EButtonID SlotBID = AudioButton.EButtonID.ButtonB;
		public static AudioButton.EButtonID SlotCID = AudioButton.EButtonID.ButtonC;
		public static AudioButton.EButtonID SlotDID = AudioButton.EButtonID.ButtonD;

		// Slots ref
		[SerializeField]
		public Slot m_SlotA;
		[SerializeField]
		public Slot m_SlotB;
		[SerializeField]
		public Slot m_SlotC;
		[SerializeField]
		public Slot m_SlotD;

	#endregion

	#region MonoBehaviour

		// Use this for initialization
		void Start()
		{
		}

		// Update is called once per frame
		void Update()
		{
			// Slot swapping
			ManageSlotSwapping();

			SlotAID = m_SlotA.GetButtonID();
			SlotBID = m_SlotB.GetButtonID();
			SlotCID = m_SlotC.GetButtonID();
			SlotDID = m_SlotD.GetButtonID();

			if (Input.GetKeyDown(KeyCode.Space))
			{
				Application.LoadLevel(Application.loadedLevel + 1);
			}
		}

		// On destroy
		void OnDestroy()
		{
			SlotAID = m_SlotA.GetButtonID();
			SlotBID = m_SlotB.GetButtonID();
			SlotCID = m_SlotC.GetButtonID();
			SlotDID = m_SlotD.GetButtonID();
		}

	#endregion

	#region Private Manipulators

		private void ManageSlotSwapping()
		{
			if (Input.touchCount > 0)
			{
				foreach (Touch touch in Input.touches)
				{
					switch (touch.phase)
					{
						case TouchPhase.Began:

							// Get slot for touch position
							m_CurrentSlotContent = SlotContent.GetSlotContentAtTouchPosition(touch.position, null);

							if (m_CurrentSlotContent != null)
								m_OldSlotContentPosition = m_CurrentSlotContent.transform.position;

							break;

						case TouchPhase.Moved:

							// Move slot content
							if (m_CurrentSlotContent != null)
							{
								m_CurrentSlotContent.transform.position = touch.position;
							}

							break;

						case TouchPhase.Ended:

							SlotContent otherSlot = SlotContent.GetSlotContentAtTouchPosition(touch.position, m_CurrentSlotContent);

							if (m_CurrentSlotContent != null)
							{
								if (otherSlot != null)
								{
									Transform temp = otherSlot.transform.parent;
									otherSlot.transform.SetParent(m_CurrentSlotContent.transform.parent);
									m_CurrentSlotContent.transform.SetParent(temp);

									otherSlot.transform.localPosition = Vector3.zero;
									m_CurrentSlotContent.transform.localPosition = Vector3.zero;

									m_CurrentSlotContent = null;
								}
								else
								{
									m_CurrentSlotContent.transform.position = m_OldSlotContentPosition;
								}
							}

							break;
					}
				}
			}
		}

	#endregion
}
