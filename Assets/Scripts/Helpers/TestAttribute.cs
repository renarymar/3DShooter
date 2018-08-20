﻿using System;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
	[RequireComponent(typeof(Test)), ExecuteInEditMode]
	public class TestAttribute : MonoBehaviour
	{
		[HideInInspector] public float TestPublic;

		private const int _min = 0;
		private const int _max = 100;
		[Header("Test variables")]
		[Range(_min, _max), ContextMenuItem("Randomize Number", "Randomize")]
		[SerializeField] private float _testPrivate;

		[Space(20)]
		[SerializeField, Multiline(5)] private string _testMultiline;
		[SerializeField, TextArea(5, 5), Tooltip("Tooltip text")] private string _testTextArea;
		
		private void Update()
		{
			//GetComponent<Renderer>().material.color = ColorList.ListColors[UnityEngine.Random.Range(0, ColorList.ListColors.Count - 1)];
		}

		private void Randomize()
		{
			_testPrivate = UnityEngine.Random.Range(_min, _max);
			
		}

		[Obsolete("Устарело. Используй что-то другое")]
		private void TestObsolete()
		{

		}
	}
}