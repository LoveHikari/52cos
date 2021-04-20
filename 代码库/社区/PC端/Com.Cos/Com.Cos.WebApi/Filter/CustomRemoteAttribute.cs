using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Com.Cos.WebApi.Filter
{
    /// <summary>
    /// Remote Attribute for Client an Server validation.
    /// https://stackoverflow.com/questions/5393020/remoteattribute-validator-does-not-fire-server-side
    /// </summary>
    public class CustomRemoteAttribute : RemoteAttribute
    {
        /// <summary>
        /// List of all Controllers on MVC Application
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<Type> GetControllerList()
        {
            return Assembly.GetCallingAssembly().GetTypes().Where(type => type.IsSubclassOf(typeof(Controller))).ToList();
        }

        /// <summary>
        /// Constructor of base class.
        /// </summary>
        protected CustomRemoteAttribute() { }

        /// <summary>
        /// Constructor of base class.
        /// </summary>
        public CustomRemoteAttribute(string routeName) : base(routeName) { }

        /// <summary>
        /// Constructor of base class.
        /// </summary>
        public CustomRemoteAttribute(string action, string controller) : base(action, controller) { }

        /// <summary>
        /// Constructor of base class.
        /// </summary>
        public CustomRemoteAttribute(string action, string controller, string areaName) : base(action, controller, areaName) { }

        /// <summary>
        /// Overridden IsValid function
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string connection = OtherConfig.CosSSMSConnString;
            DbContextOptions<CosDbContext> dbContextOption = new DbContextOptions<CosDbContext>();
            DbContextOptionsBuilder<CosDbContext> dbContextOptionBuilder = new DbContextOptionsBuilder<CosDbContext>(dbContextOption);
            CosDbContext dbContext = new CosDbContext(dbContextOptionBuilder.UseSqlServer(connection).Options);

            // Find the controller passed in constructor
            var controller = GetControllerList().FirstOrDefault(x => x.Name == string.Format("{0}Controller", this.RouteData["controller"]));
            if (controller == null)
            {
                // Default behavior of IsValid when no controller is found.
                return ValidationResult.Success;
            }
            List<Type> proTypeList = new List<Type>() { value.GetType() };
            List<object> proList = new List<object>() { value };
            if (!string.IsNullOrWhiteSpace(AdditionalFields))
            {
                var fields = AdditionalFields.Split(',', StringSplitOptions.RemoveEmptyEntries);
                proTypeList.AddRange(validationContext.ObjectType.GetProperties().Where(info => fields.Any(s => info.Name.Contains(s))).Select(info => info.PropertyType));

                proList.AddRange(validationContext.ObjectType.GetProperties().Where(info => fields.Any(s => info.Name.Contains(s))).Select(info => info.GetValue(validationContext.ObjectInstance)));
            }

            // Find the Method passed in constructor
            var mi = controller.GetMethod(this.RouteData["action"].ToString(), BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, proTypeList.ToArray(), null);

            if (mi == null)
            {
                // Default behavior of IsValid when action not found
                return ValidationResult.Success;
            }

            // Create instance of the controller to be able to call non static validation method
            var instance = Activator.CreateInstance(controller, dbContext);

            // invoke the method on the controller with value and "AdditionalFields"
            JsonResult result = mi.Invoke(instance, proList.ToArray()) is Task<object> task ? (JsonResult)task.Result : (JsonResult)mi.Invoke(instance, proList.ToArray());

            // Return success or the error message string from CustomRemoteAttribute
            if (!(result.Value is string errorMessaqe))
            {
                bool isValid;
                try
                {
                    isValid = (bool)result.Value;
                }
                catch (Exception)
                {
                    isValid = false;
                }
                return isValid ? ValidationResult.Success : new ValidationResult(base.ErrorMessageString);
            }
            else
                return new ValidationResult(errorMessaqe);
        }
    }
}