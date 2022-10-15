using MementoTask.Commands;
using MementoTask.Models;
using MementoTask.Models.Memento;
using MementoTask.Models.ScreenshoteService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MementoTask.ViewModels
{
    public class AppViewModel : BaseViewModel
    {
        private ImageSource imageSource;

        public ImageSource ImageSource
        {
            get { return imageSource; }
            set { imageSource = value; OnPropertyChanged(); }
        }


        public RelayCommand NextCommand { get; set; }
        public RelayCommand PrevCommand { get; set; }
        public RelayCommand ScreenShotCommand { get; set; }


        public AppViewModel()
        {

            Originator originator = new Originator(ImageSource);
            CareTaker careTaker = new CareTaker(originator);
            ScreenShotCommand = new RelayCommand(c =>
            {
                var result = ScreenCapture.CaptureActiveWindow();
                var imageSource = BitmapConverter.ImageSourceFromBitmap(result);
                ImageSource = imageSource;
                originator.TakeScreenShot(ImageSource);
                careTaker.Backup();
            });

            PrevCommand = new RelayCommand(c =>
            {
                var imageSource = careTaker.Undo();
                if (imageSource != null)
                    ImageSource = imageSource;
            });


            NextCommand = new RelayCommand(c =>
            {
                var imageSource = careTaker.Redo();
                if (imageSource != null)
                    ImageSource = imageSource;
            });
        }
    }
}
