using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FYP_MS.HelperClasses
{
    internal class ViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            try
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, e);
            }
            catch { }
        }
        private Stream docStream;
        public Stream DocumentStream
        {
            get { return docStream; }
            set 
            {
                try
                {
                    docStream = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("DocumentStream"));
                }
                catch { }
            }
        }
        public ViewModel()
        {
            try
            {
                docStream = new FileStream("this.pdf", FileMode.Open);
            }
            catch 
            {
                MessageBox.Show("Create a Pdf file to view it.");
            }
        }
    }
}
