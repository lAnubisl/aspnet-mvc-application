﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PresentationService.Resources {
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
    public class ValidationMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ValidationMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PresentationService.Resources.ValidationMessages", typeof(ValidationMessages).Assembly);
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
        ///   Looks up a localized string similar to Файл превышает допустимый размер..
        /// </summary>
        public static string FileExceedsTheSizeLimit {
            get {
                return ResourceManager.GetString("FileExceedsTheSizeLimit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Недопустимый формат файла..
        /// </summary>
        public static string FileFormatIsNotAllowed {
            get {
                return ResourceManager.GetString("FileFormatIsNotAllowed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Пожалуйста введите правильный {0}..
        /// </summary>
        public static string PleaseEnterValid_X {
            get {
                return ResourceManager.GetString("PleaseEnterValid_X", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Продукт {0} не существует в системе..
        /// </summary>
        public static string Product_X_DoesNotExistsInTheSystem {
            get {
                return ResourceManager.GetString("Product_X_DoesNotExistsInTheSystem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} уже существует в системе..
        /// </summary>
        public static string X_AlreadyExistsInTheSystem {
            get {
                return ResourceManager.GetString("X_AlreadyExistsInTheSystem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} не может быть больше {1} символов..
        /// </summary>
        public static string X_CanNotBeLongerThan_Y_Characters {
            get {
                return ResourceManager.GetString("X_CanNotBeLongerThan_Y_Characters", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} обязательно для ввода..
        /// </summary>
        public static string X_IsRequired {
            get {
                return ResourceManager.GetString("X_IsRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} должно быть положительным числом..
        /// </summary>
        public static string X_ShouldBeAPositiveNumber {
            get {
                return ResourceManager.GetString("X_ShouldBeAPositiveNumber", resourceCulture);
            }
        }
    }
}
