using System;
using System.Text.RegularExpressions;
using System.Xml;
using Terradue.Portal;





//-----------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------
using System.Runtime.Serialization;





namespace Terradue.Cloud {

    

    //-------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------

    

    //! Represents a Globus computing resource that is accessed through an LGE interface.
	[Serializable]
	[DataContract]
    public class VirtualMachineTemplate : VirtualResource {

        //---------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the additional content to be add to the template during the instanciation
        /// </summary>
        /// <value>The additional content of the template.</value>
        public string AdditionalContent { get; set; }
        
        //---------------------------------------------------------------------------------------------------------------------
        
        public VirtualMachineTemplate(IfyContext context) : base(context) {}
        
        //---------------------------------------------------------------------------------------------------------------------

        /// <summary>Creates a new VirtualMachineTemplate instance.</summary>
        /// <param name="context">the execution environment context</param>
        /// <returns>the created VirtualMachineTemplate object</returns>
        public static new VirtualMachineTemplate GetInstance(IfyContext context) {
            return new VirtualMachineTemplate(context);
        }
        
        //---------------------------------------------------------------------------------------------------------------------
    }


}

