using System;
using System.Data;
using System.Xml;
using Terradue.Portal;
using System.Runtime.Serialization;
using System.Net;
using System.Collections.Generic;

namespace Terradue.Cloud {

    

    //-------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------------------------------------

    
	[Serializable]
	[DataContract]
    [EntityTable("cloud", EntityTableConfiguration.Custom, HasOwnerReference = true, HasExtensions = true, NameField = "caption")]
    public abstract class CloudAppliance : Entity {
        
		private string hostname;
        private CloudProvider provider;
        
        //---------------------------------------------------------------------------------------------------------------------
        
		[IgnoreDataMember]
		[EntityDataField("id_cloudprov", IsForeignKey = true)]
        public int ProviderId { get; protected set; }

        //---------------------------------------------------------------------------------------------------------------------
        
        /// <summary>Gets (or sets) the provider to which the appliance belongs.</summary>
		[IgnoreDataMember]
        public CloudProvider Provider {
            get {
                if (provider == null && ProviderId != 0) provider = CloudProvider.FromId(context, ProviderId);
                return provider;
            }
            protected set {
                provider = value;
                ProviderId = (value == null ? 0 : value.Id);
            }
        }

        //---------------------------------------------------------------------------------------------------------------------
        
		[DataMember]
		[EntityDataField("remote_id")]
        public string RemoteId { get; protected set; }
        
        //---------------------------------------------------------------------------------------------------------------------

		[DataMember]
        [Obsolete("Obsolete, please use Name instead.")]
        public string Caption {
            get { return Name; }
            set { Name = value; }
        }

        //---------------------------------------------------------------------------------------------------------------------

		[IgnoreDataMember]
		[EntityDataField("description")]
        public string Description { get; protected set; }

        //---------------------------------------------------------------------------------------------------------------------

		[DataMember]
		[EntityDataField("hostname")]
        public virtual string Hostname { 
			get {
				try{
					string fqdn = this.VirtualNetwork.FQDN;
					if (fqdn == null) {
						if (hostname == null) return "localhost";
						else return hostname;
					}
					return fqdn;
				}catch(Exception e){
					return "localhost";
				}
			}
			set { hostname = value; }
		}

        //---------------------------------------------------------------------------------------------------------------------

		[DataMember]
        public string Username { get; set; }

		[DataMember]
		public string Owner { get; set; }

        //---------------------------------------------------------------------------------------------------------------------

        [DataMember]
        public string StatusText { get; protected set; }

		[DataMember]
		public string Message {
			get;
			set;
		}

        //---------------------------------------------------------------------------------------------------------------------
        
		[DataMember]
        public abstract VirtualMachineTemplate VirtualMachineTemplate { get; }
        
        //---------------------------------------------------------------------------------------------------------------------
        
		[DataMember]
        public abstract VirtualDisk[] VirtualDisks { get; }
        
        //---------------------------------------------------------------------------------------------------------------------
        
		[DataMember]
        public abstract VirtualNetwork VirtualNetwork { get; }
        
        //---------------------------------------------------------------------------------------------------------------------

        /// <summary>Gets the Architecture of the instance.</summary>
        public ProcessorArchitecture Architecture { get; protected set; }
        
        //---------------------------------------------------------------------------------------------------------------------
        
        /// <summary>Gets the number of CPU cores assigned to the instance.</summary>
        public int Cores { get; protected set; }
        
        //---------------------------------------------------------------------------------------------------------------------
        
        /// <summary>Gets the CPU clock frequency (speed) in GHz.</summary>
		public float Speed { get; protected set; }
        
        //---------------------------------------------------------------------------------------------------------------------
        
        /// <summary>Gets the maximum RAM allocated to the instance in gigabytes.</summary>
		public float Memory { get; protected set; }
        
        //---------------------------------------------------------------------------------------------------------------------
        
        public virtual MachineState State { get; protected set; }


		//---------------------------------------------------------------------------------------------------------------------
        
        public CloudAppliance(IfyContext context) : base(context) {}
        
        //---------------------------------------------------------------------------------------------------------------------

        /// <summary>Returns an instance of a CloudAppliance subclass representing the cloud appliance with the specified ID.</summary>
        /// <param name="context">the execution environment context</param>
        /// <param name="id">the cloud appliance ID</param>
        /// <returns>the created CloudAppliance subclass instance</returns>
        public static CloudAppliance FromId(IfyContext context, int id) {
            EntityType entityType = EntityType.GetEntityType(typeof(CloudAppliance));
            CloudAppliance result = (CloudAppliance)entityType.GetEntityInstanceFromId(context, id); 
            result.Id = id;
            result.Load();
            return result;
        }
        
        //---------------------------------------------------------------------------------------------------------------------

        public abstract bool Create();
        
        //---------------------------------------------------------------------------------------------------------------------
        
        public abstract bool Start();
        
        //---------------------------------------------------------------------------------------------------------------------
        
        public abstract bool Stop(MachineStopMethod method);
        
        //---------------------------------------------------------------------------------------------------------------------
        
        public abstract bool Suspend(MachineSuspendMethod method);
        
        //---------------------------------------------------------------------------------------------------------------------
        
        public abstract bool Resume(MachineRestartMethod method);
        
        //---------------------------------------------------------------------------------------------------------------------

        public abstract bool Shutdown(MachineStopMethod method);

        //---------------------------------------------------------------------------------------------------------------------
        
        public abstract void GetStatus(XmlDocument xmlDocument);
        
        //---------------------------------------------------------------------------------------------------------------------
        
        public abstract bool SaveDiskAs(int id, string caption); 
        
        //---------------------------------------------------------------------------------------------------------------------


    }


    /// <summary>Empty implementation of CloudProvider.</summary>
    /// <remarks>
    ///  <p>This class is only used when a generic instance derived from the abstract CloudProvider class is needed in order to combine different types of cloud providers (e.g. for producing an item list).</p>
    ///  <p>It provides only the functionality inherited from the superclasses of CloudProvider (e.g. Entity) but no functionality of a real cloud provider.</p>
    /// </remarks>
    public class GenericCloudAppliance : CloudAppliance {
        //---------------------------------------------------------------------------------------------------------------------
        
        public override VirtualMachineTemplate VirtualMachineTemplate {
            get { return null; }
        }
        
        //---------------------------------------------------------------------------------------------------------------------
        
        public override VirtualDisk[] VirtualDisks {
            get { return null; }
        }
        
        //---------------------------------------------------------------------------------------------------------------------
        
        public override VirtualNetwork VirtualNetwork {
            get { return null; }
        }
        
        //---------------------------------------------------------------------------------------------------------------------
        
        public GenericCloudAppliance(IfyContext context) : base(context) {}

        //---------------------------------------------------------------------------------------------------------------------
        
        public override bool Create() {
            return false;
        }
        
        //---------------------------------------------------------------------------------------------------------------------
        
        public override bool Start() {
            return false;
        }
        
        //---------------------------------------------------------------------------------------------------------------------
        
        public override bool Stop(MachineStopMethod method) {
            return false;
        }
        
        //---------------------------------------------------------------------------------------------------------------------
        
        public override bool Suspend(MachineSuspendMethod method) {
            return false;
        }
        
        //---------------------------------------------------------------------------------------------------------------------
        
        public override bool Resume(MachineRestartMethod method) {
            return false;
        }
        
        //---------------------------------------------------------------------------------------------------------------------

        public override bool Shutdown(MachineStopMethod method) {
            return false;
        }

        //---------------------------------------------------------------------------------------------------------------------
        
        public override void GetStatus(XmlDocument xmlDocument) {}
        
        //---------------------------------------------------------------------------------------------------------------------
        
        public override bool SaveDiskAs(int id, string caption) { 
            return false;
        }
        
    }
        

}

