using MidtermProject.Data;
using MidtermProject.ViewModel;

namespace MidtermProject;


[QueryProperty("NoteToDisplay", "note")]
public partial class AddNotes : ContentPage
{   
    AddNotesViewModels viewModel = new AddNotesViewModels();
	public AddNotes()
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
    Note _NoteToDisplay;
    public Note NoteToDisplay
    {
        get => _NoteToDisplay;
        set
        {
            /*	if (_NoteToDisplay == value)
                    return;*/

            _NoteToDisplay = value; 
            viewModel.Title = _NoteToDisplay.Title;
            viewModel.Content = _NoteToDisplay.Content;
            
            viewModel.Date = _NoteToDisplay.createAt;

            viewModel.NoteId = _NoteToDisplay.ID;
            viewModel.UserId = _NoteToDisplay.AccountID;

        }
    }
}