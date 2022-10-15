using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MementoTask.Models.Memento
{
    public class ConcreteMemento : IMemento
    {

        public ConcreteMemento(ImageSource state)
        {
            _state = state;
        }
        private ImageSource _state;
        public ImageSource GetImageSource()
        {
          return this._state;
        }
    }
}
