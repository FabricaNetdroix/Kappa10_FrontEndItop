﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tier.Data {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class StaticQueries {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StaticQueries() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Tier.Data.StaticQueries", typeof(StaticQueries).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///    `_itopview_contract`.`id`,
        ///    `_itopview_contract`.`name`,
        ///    `_itopview_contract`.`org_id`,
        ///    `_itopview_contract`.`organization_name`,
        ///    `_itopview_contract`.`description`,
        ///    `_itopview_contract`.`start_date`,
        ///    `_itopview_contract`.`end_date`,
        ///    `_itopview_contract`.`provider_id`,
        ///    `_itopview_contract`.`provider_name`
        ///FROM
        ///    `{0}`.`_itopview_contract`
        ///WHERE
        ///    `{0}`.`_itopview_contract`.`status` = &apos;production&apos;
        ///        AND `{0}`.`_itopview_contract`.`contracttype_id` = 39
        ///    [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string itop_platform_get_contracts {
            get {
                return ResourceManager.GetString("itop_platform_get_contracts", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///    `_itopview_contract`.`id`,
        ///    `_itopview_contract`.`name`,
        ///    `_itopview_contract`.`org_id`,
        ///    `_itopview_contract`.`organization_name`,
        ///    `_itopview_contract`.`description`,
        ///    `_itopview_contract`.`start_date`,
        ///    `_itopview_contract`.`end_date`,
        ///    `_itopview_contract`.`provider_id`,
        ///    `_itopview_contract`.`provider_name`
        ///FROM
        ///    `{0}`.`_itoppriv_user`
        ///        INNER JOIN
        ///    `{0}`.`_itoplnkcontacttocontract` ON `_itoppriv_user`.`contactid` = `_itoplnkcontacttocontract`.`contact_id [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string itop_platform_get_userbylogin {
            get {
                return ResourceManager.GetString("itop_platform_get_userbylogin", resourceCulture);
            }
        }
    }
}
