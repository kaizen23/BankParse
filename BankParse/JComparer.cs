using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceCodeComparer
{
    class JComparer
    {
        public void Compare()
        {
            string sourceJsonString = "{\"name\":\"John Doe\",\"age\":\"25\",\"hitcount\":\"30\"}";
            string targetJsonString = "{\"name\":\"John Doe\",\"age\":\"25\",\"hitcount\":\"30\"}";

            JObject sourceJObject = JsonConvert.DeserializeObject<JObject>(sourceJsonString);
            JObject targetJObject = JsonConvert.DeserializeObject<JObject>(targetJsonString);

            if (!JToken.DeepEquals(sourceJObject, targetJObject))
            {
                foreach (KeyValuePair<string, JToken> sourceProperty in sourceJObject)
                {
                    JProperty targetProp = targetJObject.Property(sourceProperty.Key);

                    if (!JToken.DeepEquals(sourceProperty.Value, targetProp.Value))
                    {
                        Console.WriteLine("{0} property value is changed", sourceProperty.Key);
                    }
                    else
                    {
                        Console.WriteLine("{0} property value didn't change", sourceProperty.Key);
                    }
                }
            }
            else
            {
                Console.WriteLine("Objects are same");
            }
        }
    }
}
