using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattLamp.Models
{
    internal class ObjectHolder<T> : BaseNotifyModel
    {
        public ObjectHolder(string defaultString)
        {
            _DefaultString = defaultString;
        }

        private T _Object;
        public T Object
        {
            get
            {
                return _Object;
            }
            set
            {
                ChangeAndNotify(ref _Object, value, () => Object, ObjectChanged);
            }
        }

        private string _DefaultString;
        public string DefaultString
        {
            get => _DefaultString;
            set
            {
                ChangeAndNotify(ref _DefaultString, value, () => DefaultString, (oldv, newv) => ObjectChanged(_Object, _Object));
            }
        }

        public string ObjToString => _Object?.ToString() ?? DefaultString;

        private void ObjectChanged(T oldValue, T newValue)
        {
            Notify(() => ObjToString);
        }
    }
}
