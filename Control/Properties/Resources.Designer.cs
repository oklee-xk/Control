﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Control.Properties {
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
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Control.Properties.Resources", typeof(Resources).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        public static System.Drawing.Bitmap arrow {
            get {
                object obj = ResourceManager.GetObject("arrow", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        public static System.Drawing.Bitmap arrow_down {
            get {
                object obj = ResourceManager.GetObject("arrow_down", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        public static System.Drawing.Bitmap arrow1 {
            get {
                object obj = ResourceManager.GetObject("arrow1", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///   &quot;type&quot;:&quot;register&quot;,
        ///   &quot;id&quot;:&quot;register&quot;,
        ///   &quot;payload&quot;:{
        ///      &quot;forcePairing&quot;:false,
        ///      &quot;pairingType&quot;:&quot;PROMPT&quot;,
        ///      &quot;manifest&quot;:{
        ///         &quot;manifestVersion&quot;:1,
        ///         &quot;appVersion&quot;:&quot;1.1&quot;,
        ///         &quot;signed&quot;:{
        ///            &quot;created&quot;:&quot;20140509&quot;,
        ///            &quot;appId&quot;:&quot;com.lge.test&quot;,
        ///            &quot;vendorId&quot;:&quot;com.lge&quot;,
        ///            &quot;localizedAppNames&quot;:{
        ///               &quot;&quot;:&quot;LG Remote App&quot;,
        ///               &quot;ko-KR&quot;:&quot;리모컨 앱&quot;,
        ///               &quot;zxx-XX&quot;:&quot;ЛГ Rэмotэ AПП&quot;
        ///            },
        ///            &quot;locali [rest of string was truncated]&quot;;.
        /// </summary>
        public static string HAND_SHAKE {
            get {
                return ResourceManager.GetString("HAND_SHAKE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;turn_off&quot; : {
        ///    &quot;type&quot;: &quot;request&quot;,
        ///    &quot;uri&quot;:&quot;ssap://system/turnOff&quot;
        ///  },
        ///
        ///  &quot;volume_down&quot; : {
        ///	&quot;type&quot;: &quot;request&quot;,
        ///	&quot;uri&quot;:&quot;ssap://audio/volumeDown&quot;
        ///  },
        ///
        ///  &quot;volume_up&quot; : {
        ///	&quot;type&quot;: &quot;request&quot;,
        ///	&quot;uri&quot;:&quot;ssap://audio/volumeUp&quot;
        ///  },
        ///
        ///  &quot;channel_up&quot; : {
        ///	&quot;type&quot;: &quot;request&quot;,
        ///	&quot;uri&quot;:&quot;ssap://tv/channelUp&quot;
        ///  },
        ///
        ///  &quot;channel_down&quot; : {
        ///	&quot;type&quot;: &quot;request&quot;,
        ///	&quot;uri&quot;:&quot;ssap://tv/channelDown&quot;
        ///  },
        ///}
        ///.
        /// </summary>
        public static string MESSAGES {
            get {
                return ResourceManager.GetString("MESSAGES", resourceCulture);
            }
        }
    }
}
