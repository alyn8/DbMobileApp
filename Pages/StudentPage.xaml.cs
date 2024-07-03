using DbMyDemo.Models;

namespace DbMyDemo;

public partial class StudentPage : ContentPage
{
    private StudentClass _selectedStudent;

    public StudentClass SelectedStudent
    {
        get => _selectedStudent;
        set
        {
            if (_selectedStudent != value)
            {
                _selectedStudent = value;
                OnPropertyChanged();
                DeleteButton.IsVisible = _selectedStudent != null;

            }
        }
    }


    public StudentPage()
    {
        InitializeComponent();
        LoadStudents();
        this.BindingContext = this;
    }

    private void LoadStudents()
    {
        Stu_List_View.ItemsSource = App.DBTrans.GetStudents();
    }
    private void Btn_Stu_add_Clicked(object sender, EventArgs e)
    {
        var newStudent = new StudentClass
        {
            Name=stu_name.Text,
            Department=stu_dept.Text
        };
        App.DBTrans.AddStudent(newStudent);
        LoadStudents();

    }

    private void Button_Clicked(object sender, EventArgs e)
    {

        if (SelectedStudent == null)
        {
            DisplayAlert("Error", "No student selected.", "OK");
            return;
        }

        App.DBTrans.DeleteStudent(SelectedStudent.ID);
        LoadStudents();
        SelectedStudent = null;

    }


}