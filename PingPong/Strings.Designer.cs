﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PingPong {
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
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PingPong.Strings", typeof(Strings).Assembly);
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
        ///   Looks up a localized string similar to Число запущеных экземпляров приложения: .
        /// </summary>
        internal static string CountOfInstances {
            get {
                return ResourceManager.GetString("CountOfInstances", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Размер данных превышает размер UDP пакета.
        /// </summary>
        internal static string DataLengthGreaterThenUDPDatagram {
            get {
                return ResourceManager.GetString("DataLengthGreaterThenUDPDatagram", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to  (Определён автоматически).
        /// </summary>
        internal static string DeterminedAutomatically {
            get {
                return ResourceManager.GetString("DeterminedAutomatically", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Введите номер порта:
        ///Для выбора случайного порта нажмите Enter.
        /// </summary>
        internal static string EnterNumberOfPort {
            get {
                return ResourceManager.GetString("EnterNumberOfPort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Локальный IP адрес не определен.
        /// </summary>
        internal static string LocalIPNotFound {
            get {
                return ResourceManager.GetString("LocalIPNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Параметр {0} не может быть неопределен.
        /// </summary>
        internal static string ParameterCantBeNull {
            get {
                return ResourceManager.GetString("ParameterCantBeNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Номер порта должен находится в пределах 1024 - 65535.
        /// </summary>
        internal static string PortMustBeWithin {
            get {
                return ResourceManager.GetString("PortMustBeWithin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Номер порта .
        /// </summary>
        internal static string PortNumber {
            get {
                return ResourceManager.GetString("PortNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Произошла ошибка работы UDP сокета.
        /// </summary>
        internal static string UdpSocketException {
            get {
                return ResourceManager.GetString("UdpSocketException", resourceCulture);
            }
        }
    }
}
