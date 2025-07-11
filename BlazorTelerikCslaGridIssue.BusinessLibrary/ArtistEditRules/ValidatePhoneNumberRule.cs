using System;
using Csla.Rules;
using Csla.Core;
using System.Text.RegularExpressions;

namespace BusinessLibrary.ArtistEditRules
{
    public class ValidatePhoneNumberRule : BusinessRule
    {
        public ValidatePhoneNumberRule(Csla.Core.IPropertyInfo primaryProperty)
            : base(primaryProperty)
        {
            //InputProperties = new List<IPropertyInfo> { primaryProperty };
        }

        protected override void Execute(IRuleContext context)
        {
            var phone = (string)context.InputPropertyValues[PrimaryProperty];
            if (string.IsNullOrWhiteSpace(phone)) return;

            // Remove formatting characters
            var digits = Regex.Replace(phone, "[^0-9]", "");

            if (digits.Length != 10)
            {
                context.AddErrorResult("Phone number must be exactly 10 digits long.");
                return;
            }

            var last7 = digits.Substring(3, 7);
            if (last7 == "8675309")
            {
                context.AddErrorResult("Phone number cannot be 867-5309 (Jenny's number).");
            }
        }
    }
}
