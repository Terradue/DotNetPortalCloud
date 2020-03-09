/*!

\namespace Terradue.Cloud
@{
    Terradue Cloud module deals with the layer communicating with Cloud Providers interfaces. It provides with an abstract layer to cloud functionalities such as virtual machine provisioning, network infrastructure configuration, disks volumes mountage...

    \xrefitem sw_version "Versions" "Software Package Version" 1.3.3

    \xrefitem sw_link "Links" "Software Package List" [Terradue.Cloud](https://git.terradue.com/sugar/terradue-cloud)

    \xrefitem sw_license "License" "Software License" [AGPL](https://git.terradue.com/sugar/terradue-cloud/LICENSE)

    \xrefitem sw_req "Require" "Software Dependencies" \ref Terradue.Portal
    
    \xrefitem sw_req "Require" "Software Dependencies" \ref Terradue.OpenNebula

    \xrefitem sw_req "Require" "Software Dependencies" \ref Terradue.Hadoop

    \ingroup Cloud
@}

*/

using System.Reflection;
using System.Runtime.CompilerServices;
using NuGet4Mono.Extensions;

[assembly: AssemblyTitle ("Terradue.Cloud")]
[assembly: AssemblyDescription ("Terradue.Cloud is a library targeting .NET 4.0 and above that provides core interfaces and classes of Terradue Cloud")]
[assembly: AssemblyConfiguration ("")]
[assembly: AssemblyCompany ("Terradue")]
[assembly: AssemblyProduct ("Terradue.Cloud")]
[assembly: AssemblyCopyright ("Terradue")]
[assembly: AssemblyAuthors ("Enguerran Boissier")]
[assembly: AssemblyProjectUrl ("https://git.terradue.com/sugar/terradue-cloud")]
[assembly: AssemblyLicenseUrl ("")]
[assembly: AssemblyTrademark ("")]
[assembly: AssemblyCulture ("")]
[assembly: AssemblyVersion ("1.3.3")]
[assembly: AssemblyInformationalVersion ("1.3.3")]

[assembly: log4net.Config.XmlConfigurator (ConfigFile = "log4net.config", Watch = true)]