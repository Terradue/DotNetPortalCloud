using System;
using Terradue.Portal;

namespace Terradue.Cloud {
    [EntityTable("usr_cloud", EntityTableConfiguration.Custom, IsRequired = false)]
    public class CloudUser : User {

        [EntityDataField("id_provider")]
        public int ProviderId { get; set; }

        [EntityDataField("username")]
        public string CloudUsername { get; protected set; }

        //---------------------------------------------------------------------------------------------------------------------

        public CloudUser(IfyContext context) : base(context) {}

        //---------------------------------------------------------------------------------------------------------------------

        public static CloudUser FromIdAndProvider(IfyContext context, int usrId, int providerId){
            CloudUser result = new CloudUser(context);
            result.Id = usrId;
            result.ProviderId = providerId;
            result.Load();
            return result;
        }

        //---------------------------------------------------------------------------------------------------------------------

    }
}

