﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
	public class FlashLightUi : MonoBehaviour
	{
		private Text _textB;

		private void Start()
		{
			_textB = GetComponent<Text>();
		}
		public float TextB
		{
			set
			{
				_textB.text = String.Format("{0:0}%", value);
			}
		}

		public void SetActive(bool isActive)
		{
			_textB.gameObject.SetActive(isActive);
		}
	}
}