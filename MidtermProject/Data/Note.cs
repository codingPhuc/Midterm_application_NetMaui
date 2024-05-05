
using System.ComponentModel;

namespace MidtermProject.Data;


[Serializable]
public class Note : INotifyPropertyChanged
{
    private int _noteId;
    private int _userId;
    private string _title;
    private string _content;
    private DateTime _date;

    public event PropertyChangedEventHandler PropertyChanged;
    public int noteId
    {
        get => _noteId;
        set
        {
            _noteId = value;
            OnPropertyChanged(nameof(noteId));
        }
    }

    public int userId
    {
        get => _userId;
        set
        {
            _userId = value;
            OnPropertyChanged(nameof(userId));
        }
    }

    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            OnPropertyChanged(nameof(Title));
        }
    }

    public string Content
    {
        get => _content;
        set
        {
            _content = value;
            OnPropertyChanged(nameof(Content));
        }
    }

    public DateTime Date
    {
        get => _date;
        set
        {
            _date = value;
            OnPropertyChanged(nameof(Date));
        }
    }
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
