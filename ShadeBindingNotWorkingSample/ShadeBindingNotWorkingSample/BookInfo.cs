using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadeBindingNotWorkingSample
{
    public class BookInfo : INotifyPropertyChanged
    {
        private string bookName;
        private string bookDescription;

        public BookInfo()
        {
        }

        public string BookName
        {
            get { return bookName; }
            set
            {
                bookName = value;
                OnPropertyChanged("BookName");
            }
        }


        public string BookDescription
        {
            get { return bookDescription; }
            set
            {
                bookDescription = value;
                OnPropertyChanged("BookDescription");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
