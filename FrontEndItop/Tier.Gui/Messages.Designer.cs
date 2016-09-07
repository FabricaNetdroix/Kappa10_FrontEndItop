﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tier.Gui {
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
    internal class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Tier.Gui.Messages", typeof(Messages).Assembly);
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
        ///   Looks up a localized string similar to No se ha superado la validación de seguridad Captcha..
        /// </summary>
        internal static string CaptchaValidationFailure {
            get {
                return ResourceManager.GetString("CaptchaValidationFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Los datos solicitados no están correctamente diligenciados..
        /// </summary>
        internal static string InvalidForm {
            get {
                return ResourceManager.GetString("InvalidForm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to La solicitud no puedo ser procesada correctamente..
        /// </summary>
        internal static string NotificationTextFailure {
            get {
                return ResourceManager.GetString("NotificationTextFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Solicitud procesada correctamente..
        /// </summary>
        internal static string NotificationTextSuccess {
            get {
                return ResourceManager.GetString("NotificationTextSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hay advertencias para la solicitud..
        /// </summary>
        internal static string NotificationTextWarning {
            get {
                return ResourceManager.GetString("NotificationTextWarning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Fallido.
        /// </summary>
        internal static string NotificationTitleError {
            get {
                return ResourceManager.GetString("NotificationTitleError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Exitoso.
        /// </summary>
        internal static string NotificationTitleSuccess {
            get {
                return ResourceManager.GetString("NotificationTitleSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Advertencia.
        /// </summary>
        internal static string NotificationTitleWarning {
            get {
                return ResourceManager.GetString("NotificationTitleWarning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Administrador.
        /// </summary>
        internal static string RoleDisplayTextAdministrator {
            get {
                return ResourceManager.GetString("RoleDisplayTextAdministrator", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cliente.
        /// </summary>
        internal static string RoleDisplayTextCostumer {
            get {
                return ResourceManager.GetString("RoleDisplayTextCostumer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Comercial.
        /// </summary>
        internal static string RoleDisplayTextVendor {
            get {
                return ResourceManager.GetString("RoleDisplayTextVendor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El contrato seleccionado ya tiene una bolsa de horas creada. No es posible continuar..
        /// </summary>
        internal static string UniqueContractConstraint {
            get {
                return ResourceManager.GetString("UniqueContractConstraint", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Perfil de usuario desconocido.
        /// </summary>
        internal static string UnknownProfile {
            get {
                return ResourceManager.GetString("UnknownProfile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usuario o clave inválida..
        /// </summary>
        internal static string UserAutenticationFailure {
            get {
                return ResourceManager.GetString("UserAutenticationFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Activo.
        /// </summary>
        internal static string UserStatusDisplayTextActive {
            get {
                return ResourceManager.GetString("UserStatusDisplayTextActive", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Inactivo.
        /// </summary>
        internal static string UserStatusDisplayTextInactive {
            get {
                return ResourceManager.GetString("UserStatusDisplayTextInactive", resourceCulture);
            }
        }
    }
}
