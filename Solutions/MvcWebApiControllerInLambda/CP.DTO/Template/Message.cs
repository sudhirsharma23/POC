namespace CP.DTO.Template
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://CP.DTO.Template")]

    public class Message
    {
        public MessageType MessageType { get; set; }
        public string Body { get; set; }
    }

    public enum MessageType
    {
        Html=0,
        Text=1,
        Sms=2
    }
}
