using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListGUI.ViewModels.ValitableField
{
    public class NonEmptyValidatableField : AbstractValidatableField<string>
    {
        public NonEmptyValidatableField(Brush validColor, Brush invalidColor) : base(validColor, invalidColor)
        {
        }

        public override bool Validate()
        {
            IsValid = !string.IsNullOrWhiteSpace(Value);
            return base.Validate();
        }
    }
}
