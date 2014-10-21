using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Xml;
using Terradue.Portal;




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
    [EntityTable("cloudprov", EntityTableConfiguration.Custom, HasExtensions = true, NameField = "caption")]
    public abstract class CloudProvider : Entity {
        
        //---------------------------------------------------------------------------------------------------------------------
        
        [Obsolete("Obsolete, please use Name instead.")]
        public string Caption { 
            get { return Name; }
            set { Name = value; }
        }
        
        //---------------------------------------------------------------------------------------------------------------------
        
        [EntityDataField("address")]
        public string AccessPoint { get; set; }
        
        //---------------------------------------------------------------------------------------------------------------------
        
        [EntityDataField("web_admin_url")]
        public string WebAdminUrl { get; set; }
        
        //---------------------------------------------------------------------------------------------------------------------
        
        public CloudProvider(IfyContext context) : base(context) {}

        //---------------------------------------------------------------------------------------------------------------------

        public CloudProvider(IfyContext context, string accessPoint) : base(context) {
            this.AccessPoint = accessPoint;
        }
        
        //---------------------------------------------------------------------------------------------------------------------

        /// <summary>Creates a new CloudProvider instance.</summary>
        /// <param name="context">the execution environment context</param>
        /// <returns>the created CloudProvider object</returns>
        public static new CloudProvider GetInstance(IfyContext context) {
            return new GenericCloudProvider(context);
        }
        
        //---------------------------------------------------------------------------------------------------------------------

        /// <summary>Returns an instance of a CloudProvider subclass representing the cloud provider with the specified ID.</summary>
        /// <param name="context">the execution environment context</param>
        /// <param name="id">the cloud provider ID</param>
        /// <returns>the created CloudProvider subclass instance</returns>
        public static CloudProvider FromId(IfyContext context, int id) {
            EntityType entityType = EntityType.GetEntityType(typeof(CloudProvider));
            CloudProvider result = (CloudProvider)entityType.GetEntityInstanceFromId(context, id); 
            result.Id = id;
            result.Load();
            return result;
        }
        
        //---------------------------------------------------------------------------------------------------------------------

        /// <summary>In a derived class, queries the cloud provider to get a list of the virtual machine templates defined on it.</summary>
        public abstract VirtualMachineTemplate[] FindVirtualMachineTemplates(bool detailed);
        
        //---------------------------------------------------------------------------------------------------------------------
        
        /// <summary>In a derived class, queries the cloud provider to get a list of the virtual disks defined on it.</summary>
        public abstract VirtualDisk[] FindVirtualDisks(bool detailed);

        //---------------------------------------------------------------------------------------------------------------------

        /// <summary>In a derived class, queries the cloud provider to get a list of the virtual networks defined on it.</summary>
        public abstract VirtualNetwork[] FindVirtualNetworks(bool detailed);

        //---------------------------------------------------------------------------------------------------------------------
        
        /// <summary>In a derived class, queries the cloud provider to get a list of the cloud appliances created on it.</summary>
        public abstract CloudAppliance[] FindAppliances(bool detailed);

        //---------------------------------------------------------------------------------------------------------------------

        public abstract VirtualNetwork GetNetwork(string remoteId);

        //---------------------------------------------------------------------------------------------------------------------
        
        public abstract CloudAppliance CreateInstance(string caption, string templateName, string[] diskNames, string networkName);

        //---------------------------------------------------------------------------------------------------------------------

        public abstract CloudAppliance CreateInstance (string name, string templateName, string networkName);

        //---------------------------------------------------------------------------------------------------------------------
        
        public abstract CloudAppliance CreateInstance(string caption, VirtualMachineTemplate template, VirtualDisk[] disks, VirtualNetwork network);
        
        //---------------------------------------------------------------------------------------------------------------------
        
        public abstract bool DeleteInstance(CloudAppliance appliance);
        
        //---------------------------------------------------------------------------------------------------------------------
        
        public virtual FixedValueSet GetValueSetFromList(VirtualResource[] list) {
            return GetValueSetFromList(list, null);
        }

        //---------------------------------------------------------------------------------------------------------------------
        
        public virtual FixedValueSet GetValueSetFromList(VirtualResource[] list, string className) {
            int count = 0;
            for (int i = 0; i < list.Length; i++) {
                if (list[i] == null) continue; 
                if (className != null && list[i].Class != className) list[i] = null;
                if (list[i] != null) count++;
            }
            string[] values = new string[count];
            string[] captions = new string[count];
            count = 0;
            foreach (VirtualResource item in list) {
                if (item == null) continue;
                values[count] = item.RemoteId;
                captions[count] = item.Name;
                count++;
            }
            return new FixedValueSet(values, captions);
        }

        //---------------------------------------------------------------------------------------------------------------------
        
    }



    /// <summary>Empty implementation of CloudProvider.</summary>
    /// <remarks>
    ///  <p>This class is only used when a generic instance derived from the abstract CloudProvider class is needed in order to combine different types of cloud providers (e.g. for producing an item list).</p>
    ///  <p>It provides only the functionality inherited from the superclasses of CloudProvider (e.g. Entity) but no functionality of a real cloud provider.</p>
    /// </remarks>
    public class GenericCloudProvider : CloudProvider {
        
        //---------------------------------------------------------------------------------------------------------------------

        /// <summary>Creates a new GenericComputingResource instance.</summary>
        /// <param name="context">the execution environment context</param>
        public GenericCloudProvider(IfyContext context) : base(context) {}
        
        //---------------------------------------------------------------------------------------------------------------------
        
        public override VirtualMachineTemplate[] FindVirtualMachineTemplates(bool detailed) {
            return null;
        }
        
        //---------------------------------------------------------------------------------------------------------------------
        
        public override VirtualDisk[] FindVirtualDisks(bool detailed) {
            return null;
        }

        //---------------------------------------------------------------------------------------------------------------------

        public override VirtualNetwork[] FindVirtualNetworks(bool detailed) {
            return null;
        }

        //---------------------------------------------------------------------------------------------------------------------
        
        public override CloudAppliance[] FindAppliances(bool detailed) {
            return null;
        }

        //---------------------------------------------------------------------------------------------------------------------
        
        public override VirtualNetwork GetNetwork(string remoteId) {
            return null;
        }

        //---------------------------------------------------------------------------------------------------------------------

        public override CloudAppliance CreateInstance(string caption, string templateName, string[] diskNames, string networkName) {
            return null;
        }

        //---------------------------------------------------------------------------------------------------------------------
        
        public override CloudAppliance CreateInstance(string caption, string templateName, string networkName) {
            return null;
        }

        //---------------------------------------------------------------------------------------------------------------------
        
        public override CloudAppliance CreateInstance(string caption, VirtualMachineTemplate template, VirtualDisk[] disks, VirtualNetwork network) {
            return null;
        }
        
        //---------------------------------------------------------------------------------------------------------------------
        
        public override bool DeleteInstance(CloudAppliance appliance) {
            return false;
        }
        
        //---------------------------------------------------------------------------------------------------------------------
        
    }


}

