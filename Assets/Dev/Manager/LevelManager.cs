﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
	#region Attributes

		// Renderer list
		private List<Renderer> m_RendererList = new List<Renderer>();

		// Instance
		private static LevelManager s_Instance = null;

	#endregion

	#region MonoBehaviour

		// Called at creation
		void Awake()
		{
			if (s_Instance != null)
			{
				Debug.LogWarning("2 level manager in scene, last removed");
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
			// Get all renderers in scene
			Renderer[] rendererArray= GameObject.FindObjectsOfType<Renderer>();

			for (int i = 0; i < rendererArray.Length; i++)
			{
				m_RendererList.Add(rendererArray[i]);
			}
		}

		// Update is called once per frame
		/*
		void Update()
		{

		}*/

		// Called at fixed time
		void FixedUpdate()
		{
			// Destroy already seen objects
			DestroyAlreadySeenObjects();
		}

	#endregion

	#region Getters & Setters

		/// <summary>
		/// Get renderer list
		/// </summary>
		/// <returns></returns>
		public List<Renderer> GetRendererList()
		{
			return m_RendererList;
		}

	#endregion

	#region Private Manipulators

		private void DestroyAlreadySeenObjects()
		{
			for (int i = 0; i < m_RendererList.Count; i++)
			{
				Renderer renderer = m_RendererList[i];

				if (renderer != null)
				{
					if (renderer.transform.position.x < CameraController.GetInstance().transform.position.x)
					{
						if (!renderer.isVisible)
						{
							if (renderer.tag != "Player")
							{
								m_RendererList.RemoveAt(i);
								GameObject.Destroy(renderer.gameObject);
							}
						}
					}
				}
			}
		}

	#endregion

	#region Static Manipulators

		/// <summary>
		/// Get instance
		/// </summary>
		/// <returns></returns>
		public static LevelManager GetInstance()
		{
			return s_Instance;
		}

	#endregion
}
