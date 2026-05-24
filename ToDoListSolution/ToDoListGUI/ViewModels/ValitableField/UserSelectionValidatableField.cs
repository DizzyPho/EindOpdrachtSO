using System;
using System.Collections.Generic;
using System.Text;
using ToDoListGUI.ViewModels.TaskDetail;
using ToDoListGUI.ViewModels.UserList;

namespace ToDoListGUI.ViewModels.ValitableField
{
    public class NotNullValidatableField<T> : AbstractValidatableField<T>
        where T : class
    {
        public NotNullValidatableField(Brush validColor, Brush invalidColor) : base(validColor, invalidColor)
        {
        }

        public override bool Validate()
        {
            IsValid = Value != null;
            return base.Validate();
        }
    }
}
