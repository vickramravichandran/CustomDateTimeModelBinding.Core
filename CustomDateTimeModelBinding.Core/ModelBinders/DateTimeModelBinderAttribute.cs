using Microsoft.AspNetCore.Mvc;

namespace CustomDateTimeModelBinding.Core.ModelBinders
{
    public class DateTimeModelBinderAttribute : ModelBinderAttribute
    {
        public string DateFormat { get; set; }

        public DateTimeModelBinderAttribute()
            : base(typeof(DateTimeModelBinder))
        {
        }
    }
}
