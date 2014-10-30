using System;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Xml;
using Terradue.Portal;
using Terradue.OpenNebula;




//-----------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------






namespace Terradue.Cloud {

    

    //-------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------

    

    //! Represents a Globus computing resource that is accessed through an LGE interface.
	[Serializable]
	[DataContract]
    public class OneVMTemplate : VirtualMachineTemplate {

        //---------------------------------------------------------------------------------------------------------------------
        
        public OneVMTemplate(IfyContext context) : base(context) {}

        //---------------------------------------------------------------------------------------------------------------------

        public OneVMTemplate (IfyContext context, string name) : base (context)
        {
            this.Name = name;
        }
        
        //---------------------------------------------------------------------------------------------------------------------

        /// <summary>Creates a new XmlRpcVMTemplate instance.</summary>
        /// <param name="context">the execution environment context</param>
        /// <returns>the created XmlRpcVMTemplate object</returns>
        public static new OneVMTemplate GetInstance(IfyContext context) {
            return new OneVMTemplate(context);
        }

        //---------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="Terradue.Cloud.XmlRpcVMTemplate"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        /// <param name="template">Template.</param>
        public OneVMTemplate (IfyContext context, VMTEMPLATE template, CloudProvider provider) : base (context)
        {
            this.RemoteId = template.ID;
            this.Name = template.NAME;
            this.Provider = provider;
        }

    }


}

