using System.Collections.Generic;
using System.Xml.Serialization;
using CP.DTO.Template;

namespace CP.DTO
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://CP.DTO")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://CP.DTO", IsNullable = false)]
    public partial class SimplePublishDto
    {

        private TemplateDataItem[] templateDataField;

        private string subjectField;

        private string senderField;

        private string endpointField;

        private string messageField;

        private string ccEmailAddressField;

        private int templateIdField;

        private SimplePublishDtoProtocol protocolField;

        [System.Xml.Serialization.XmlElementAttribute("TemplateData", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public TemplateDataItem[] TemplateData
        {
            get
            {
                return this.templateDataField;
            }
            set
            {
                this.templateDataField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Subject
        {
            get
            {
                return this.subjectField;
            }
            set
            {
                this.subjectField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Sender
        {
            get
            {
                return this.senderField;
            }
            set
            {
                this.senderField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Endpoint
        {
            get
            {
                return this.endpointField;
            }
            set
            {
                this.endpointField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CcEmailAddress
        {
            get
            {
                return this.ccEmailAddressField;
            }
            set
            {
                this.ccEmailAddressField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int TemplateId
        {
            get
            {
                return this.templateIdField;
            }
            set
            {
                this.templateIdField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SimplePublishDtoProtocol Protocol
        {
            get
            {
                return this.protocolField;
            }
            set
            {
                this.protocolField = value;
            }
        }
        [XmlIgnore]
        public IEnumerable<Message> Messages { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://CP.DTO")]
    public partial class TemplateDataItem
    {

        private string nameField;

        private string valueField;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://CP.DTO")]
    public enum SimplePublishDtoProtocol
    {
        SMTP,
        TEXT,
        SMS
    }
}
