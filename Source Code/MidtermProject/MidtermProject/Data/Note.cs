using System.ComponentModel;
namespace MidtermProject.Data
{
    public class Note : INotifyPropertyChanged
    {
        private int _ID;
        private string _AccountID;
        private string _Title;
        private string _Content;
        private string _createAt;

        public event PropertyChangedEventHandler PropertyChanged;

        public int ID
        {
            get => _ID;
            set
            {
                _ID = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public string AccountID
        {
            get => _AccountID;
            set
            {
                _AccountID = value;
                OnPropertyChanged(nameof(AccountID));
            }
        }

        public string Title
        {
            get => _Title;
            set
            {
                _Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Content
        {
            get => _Content;
            set
            {
                _Content = value;
                OnPropertyChanged(nameof(Content));
            }
        }

        public string createAt
        {
            get => _createAt;
            set
            {
                _createAt = value;
                OnPropertyChanged(nameof(createAt));
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}