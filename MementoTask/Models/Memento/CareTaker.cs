using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MementoTask.Models.Memento
{
    public class CareTaker
    {
        private List<IMemento> _mementoList = new List<IMemento>();

        private Originator _originator = null;

        public CareTaker(Originator originator)
        {
            this._originator = originator;
        }
        public int Index { get; set; } = -1;
        public void Backup()
        {
            this._mementoList.Add(_originator.Save());
            Index++;
        }

        public ImageSource Undo()
        {
            if (Index == 0)
            {
                return null;
            }
            Index--;
            var memento = this._mementoList[Index];

            try
            {
                this._originator.Restore(memento);
            }
            catch (Exception)
            {
                this.Undo();
            }
            return memento.GetImageSource();
        }

        public ImageSource Redo()
        {
            if (Index + 1 != this._mementoList.Count)
            {
                Index++;
                var memento = this._mementoList[Index];
                return memento.GetImageSource();
            }
            return null;
        }

    }

}

