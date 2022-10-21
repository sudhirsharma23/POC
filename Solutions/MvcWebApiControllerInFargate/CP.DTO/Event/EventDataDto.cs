using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Event
{
    public class EventDataDto
    {
        public EventDataItemsDto Details { get; set; }

        public void AddIdentity(string identity)
        {
            AddDataItem(EventDataItemKeys.IDENTITY, identity);
        }

        public string GetIdentity()
        {
            return GetValueForKey(EventDataItemKeys.IDENTITY);
        }
        public string GetIsNewUser()
        {
            return GetValueForKey(EventDataItemKeys.ISNEWUSER);
        }
        public string GetIsExistingIdaaSUser()
        {
            return GetValueForKey(EventDataItemKeys.ISEXISTINGIDAASUSER);
        }
        public void AddDataItem(string key, string value)
        {
            if (Details == null)
            {
                Details = new EventDataItemsDto();
            }

            EventDataItemDto item = GetDataItemForKey(key);
            if (item == null)
            {
                Details.Add(new EventDataItemDto { Key = key, Value = value });
            }
            else
            {
                item.Value = value;
            }
        }

        public void AddObjectXml(string objectXml)
        {
            AddDataItem(EventDataItemKeys.OBJECT_XML, objectXml);
        }

        public void AddObject(object obj)
        {
            using (var stream = new System.IO.MemoryStream())
            {
                var writer = new DataContractSerializer(obj.GetType());

                writer.WriteObject(stream, obj);

                string xml = Encoding.UTF8.GetString(stream.ToArray());

                AddObjectXml(xml);
            }
        }

        public string GetObjectXml()
        {
            return GetValueForKey(EventDataItemKeys.OBJECT_XML);
        }

        public string GetValueForKey(string key)
        {
            if (Details == null)
            {
                Details = new EventDataItemsDto();
            }
            EventDataItemDto item = Details.FirstOrDefault(x => x.Key == key);
            return item?.Value;
        }

        public EventDataItemDto GetDataItemForKey(string key)
        {
            if (Details == null)
            {
                Details = new EventDataItemsDto();
            }

            return Details.FirstOrDefault(x => x.Key == key);
        }

        public string ToXml()
        {
            using (var stream = new System.IO.MemoryStream())
            {
                var writer = new DataContractSerializer(this.GetType());

                writer.WriteObject(stream, this);

                string xml = Encoding.UTF8.GetString(stream.ToArray());
                return xml;
            }
        }
    }
}
