using MementoTask.Models.ScreenshoteService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MementoTask.Models.Memento
{
    public class Originator
    {
        private ImageSource _state;

        public Originator(ImageSource state)
        {
            _state = state;
        }

        public void TakeScreenShot(ImageSource imageSource)
        {
            _state = imageSource;
        }

        public IMemento Save()
        {
            return new ConcreteMemento(this._state);
        }

        public void Restore(IMemento memento)
        {
            if (!(memento is ConcreteMemento))
            {
                return;
            }

            this._state = memento.GetImageSource();
        }
    }
}
