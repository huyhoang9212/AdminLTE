using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LTE.Web.ViewModels.Customer
{
    public class ApplicationRoleViewModel : BaseViewModel
    {
        public ApplicationRoleViewModel()
        {
            StartDate = DateTime.Today;
            EndDate = DateTime.Today.AddDays(1);
        }
        //public string Id { get; set; }

        [Required(ErrorMessage = "Please provide a name")]
        public string Name { get; set; }

        public bool IsSytemRole { get; set; }

        [Required]
        public string Description { get; set; }

        [DisplayName("Start Date: ")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DisplayName("Estimated end date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DateGreaterThan("StartDate", "Estimated end date must be greater than the start date of the project")]
        public DateTime EndDate { get; set; }
    }
    /// <summary>
    /// Custom unobtrusive validation
    /// https://thewayofcode.wordpress.com/tag/custom-unobtrusive-validation/
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class DateGreaterThanAttribute : ValidationAttribute, IClientValidatable
    {
        readonly string otherPropertyName;

        public DateGreaterThanAttribute(string otherPropertyName, string errorMessage)
            :base(errorMessage)
        {
            this.otherPropertyName = otherPropertyName;
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult valiationResult = ValidationResult.Success;
            try
            {
                // Using reflection to get a reference to the other date property
                var otherPropertyInfo = validationContext.ObjectType.GetProperty(this.otherPropertyName);
                // Let's check that otherProperty is of type DateTime as we expect
                if(otherPropertyInfo.PropertyType.Equals(new DateTime().GetType()))
                {
                    DateTime toValidate = (DateTime)value;
                    DateTime referenceProperty = (DateTime)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

                    // if the end date is lower than start date
                    // the validationResult will be false
                    // and return a property formatted error message
                    if(toValidate.CompareTo(referenceProperty) < 1)
                    {
                        valiationResult = new ValidationResult(ErrorMessageString);
                    }
                }
                else
                {
                    valiationResult = new ValidationResult("An error occured while validating other property. other property is not DateTime type.");
                }
            }
            catch(Exception ex)
            {
                // Do stuff, i.e log exception
                valiationResult = new ValidationResult("Something went wrong.");
            }
            return valiationResult;
        }

        //public IEnumerable<ModelClientValidationRule> GetClientValidationRulesss(ModelMetadata metadata, ControllerContext context)
        //{
        //    string errorMessage = ErrorMessageString;

        //    // The value we set here are needed by the jQuery adapter
        //    ModelClientValidationRule dateGreaterThanRule = new ModelClientValidationRule();
        //    dateGreaterThanRule.ErrorMessage = errorMessage;
        //    dateGreaterThanRule.ValidationType = "dategreaterthan"; // This is the name the jQuery adapter will use
        //    //"otherpropertyname" is the name of the jQuery parameter for the adapter, must be LOWERCASE!
        //    dateGreaterThanRule.ValidationParameters.Add("otherpropertyname", otherPropertyName);

        //    yield return dateGreaterThanRule;
        //}

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            // The value we set here are needed by the jQuery adapter
            ModelClientValidationRule dateGreaterThanRule = new ModelClientValidationRule();
            dateGreaterThanRule.ErrorMessage = ErrorMessageString;
            dateGreaterThanRule.ValidationType = "dategreaterthan"; // This is the name the jQuery adapter will use
            //"otherpropertyname" is the name of the jQuery parameter for the adapter, must be LOWERCASE
            dateGreaterThanRule.ValidationParameters.Add("otherpropertyname", otherPropertyName);
            yield return dateGreaterThanRule;
        }
    }
}