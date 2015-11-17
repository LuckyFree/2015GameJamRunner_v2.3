using UnityEngine;
using System.Collections;

public class AudioButtonsInitializer : MonoBehaviour
{
	#region Attributes

		// Audio buttons
		[SerializeField]
		private AudioButton m_AudioButtonA = null;
		[SerializeField]
		private AudioButton m_AudioButtonB = null;
		[SerializeField]
		private AudioButton m_AudioButtonC = null;
		[SerializeField]
		private AudioButton m_AudioButtonD = null;

	#endregion

	#region MonoBehaviour

		// Use this for initialization
		void Start()
		{
			Vector3 positionA = m_AudioButtonA.transform.position;
			Vector3 positionB = m_AudioButtonB.transform.position;
			Vector3 positionC = m_AudioButtonC.transform.position;
			Vector3 positionD = m_AudioButtonD.transform.position;

			switch (SlotCustomizer.SlotAID)
			{
				case AudioButton.EButtonID.ButtonA:
					m_AudioButtonA.transform.position = positionA;
					break;

				case AudioButton.EButtonID.ButtonB:
					m_AudioButtonA.transform.position = positionB;
					break;

				case AudioButton.EButtonID.ButtonC:
					m_AudioButtonA.transform.position = positionC;
					break;

				case AudioButton.EButtonID.ButtonD:
					m_AudioButtonA.transform.position = positionD;
					break;
			}

			switch (SlotCustomizer.SlotBID)
			{
				case AudioButton.EButtonID.ButtonA:
					m_AudioButtonB.transform.position = positionA;
					break;

				case AudioButton.EButtonID.ButtonB:
					m_AudioButtonB.transform.position = positionB;
					break;

				case AudioButton.EButtonID.ButtonC:
					m_AudioButtonB.transform.position = positionC;
					break;

				case AudioButton.EButtonID.ButtonD:
					m_AudioButtonB.transform.position = positionD;
					break;
			}

			switch (SlotCustomizer.SlotCID)
			{
				case AudioButton.EButtonID.ButtonA:
					m_AudioButtonC.transform.position = positionA;
					break;

				case AudioButton.EButtonID.ButtonB:
					m_AudioButtonC.transform.position = positionB;
					break;

				case AudioButton.EButtonID.ButtonC:
					m_AudioButtonC.transform.position = positionC;
					break;

				case AudioButton.EButtonID.ButtonD:
					m_AudioButtonC.transform.position = positionD;
					break;
			}

			switch (SlotCustomizer.SlotDID)
			{
				case AudioButton.EButtonID.ButtonA:
					m_AudioButtonD.transform.position = positionA;
					break;

				case AudioButton.EButtonID.ButtonB:
					m_AudioButtonD.transform.position = positionB;
					break;

				case AudioButton.EButtonID.ButtonC:
					m_AudioButtonD.transform.position = positionC;
					break;

				case AudioButton.EButtonID.ButtonD:
					m_AudioButtonD.transform.position = positionD;
					break;
			}
		}

	#endregion
}
