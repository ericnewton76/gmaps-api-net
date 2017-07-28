using System;
using System.Reflection;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Google.Maps
{
	public abstract class JsonCreationConverter<T> : JsonConverter
	{
		protected abstract T Create(Type objectType, JObject jsonObject);

		public override bool CanConvert(Type objectType)
		{
			return typeof(T).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
		}

		public override object ReadJson(JsonReader reader, Type objectType,
			object existingValue, JsonSerializer serializer)
		{
			var jsonObject = JObject.Load(reader);
			var target = Create(objectType, jsonObject);
			serializer.Populate(jsonObject.CreateReader(), target);
			return target;
		}

		public override void WriteJson(JsonWriter writer, object value,
			JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}

	public class JsonLocationConverter : JsonCreationConverter<Location>
	{
		protected override Location Create(Type objectType, JObject jsonObject)
		{
			return new LatLng(jsonObject.Value<double>("lat"), jsonObject.Value<double>("lng"));
		}
	}
}
