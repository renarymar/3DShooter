﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
	public static partial class Extensions
	{
		public static Bounds GrowBounds(this Bounds a, Bounds b)
		{
			var max = Vector3.Max(a.max, b.max);
			var min = Vector3.Min(a.min, b.min);

			a = new Bounds((max + min) * 0.5f, max - min);
			return a;
		}
		public static bool TryBool(this string self)
		{
			bool res;
			return Boolean.TryParse(self, out res) && res;
		}

		public static string PathCombine(this string self, string path)
		{
			return Path.Combine(self, path);
		}

		public static T GetOrAddComponent<T>(this Component child) where T : Component
		{
			T result = child.GetComponent<T>() ?? child.gameObject.AddComponent<T>();
			return result;
		}

		public static string Format(this string self, params object[] args)
		{
			return String.Format(self, args);
		}
		public static T DeepCopy<T>(this T self)
		{
			if (!typeof(T).IsSerializable)
			{
				throw new ArgumentException("Type must be iserializable");
			}
			if (ReferenceEquals(self, null))
			{
				return default(T);
			}

			var formatter = new BinaryFormatter();
			using (var stream = new MemoryStream())
			{
				formatter.Serialize(stream, self);
				stream.Seek(0, SeekOrigin.Begin);
				return (T)formatter.Deserialize(stream);
			}
		}
	}
}