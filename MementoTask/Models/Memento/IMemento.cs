using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MementoTask.Models.Memento
{
    public interface IMemento
    {
        ImageSource GetImageSource();
   
    }
}
