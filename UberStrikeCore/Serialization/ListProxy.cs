using System.Collections.Generic;
using System.IO;

namespace UberStrike.Core.Serialization {
	public static class ListProxy<T> {
		public delegate void Serializer<U>(Stream stream, U instance);

		public delegate U Deserializer<U>(Stream stream);

		public static void Serialize(Stream bytes, ICollection<T> instance, ListProxy<T>.Serializer<T> serialization) {
			UShortProxy.Serialize(bytes, (ushort)instance.Count);
			foreach (T current in instance) {
				serialization(bytes, current);
			}
		}

		public static List<T> Deserialize(Stream bytes, ListProxy<T>.Deserializer<T> serialization) {
			ushort num = UShortProxy.Deserialize(bytes);
			List<T> list = new List<T>((int)num);
			for (int i = 0; i < (int)num; i++) {
				list.Add(serialization(bytes));
			}
			return list;
		}
	}
}
