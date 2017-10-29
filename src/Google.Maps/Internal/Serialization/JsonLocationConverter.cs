using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

namespace Google.Maps.Internal.Serialization
{
	public class JsonLatLngConverter : JsonCreationConverter<Location>
	{
		protected override Location Create(Type objectType, JObject jsonObject)
		{
			return new LatLng(jsonObject.Value<double>("lat"), jsonObject.Value<double>("lng"));
		}
	}

}
