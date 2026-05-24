using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListGUI.ViewModels.ValitableField
{
    public abstract class AbstractValidatableField<T> : BaseViewModel
    {
        public T Value
        {
            get => Get<T>();
            set => Set(value);
        }
        public bool IsValid
        {
            get => Get<bool>();
            set => Set(value);
        }

        private Brush _validColor;
        private Brush _invalidColor;

        protected AbstractValidatableField(Brush validColor, Brush invalidColor)
        {
            _validColor = validColor;
            _invalidColor = invalidColor;
            CurrentColor = default;
        }

        public Brush CurrentColor
        {
            get => Get<Brush>();
            set => Set(value);
        }
        public virtual bool Validate() 
        {
            CurrentColor = IsValid ? _validColor : _invalidColor;
            return IsValid;
        }
    }
}
