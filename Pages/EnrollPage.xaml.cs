using DbMyDemo.Models;

namespace DbMyDemo;

public partial class EnrollPage : ContentPage
{
    private EnrollClass _selectedEnrollment;

    public EnrollClass SelectedEnrollment
    {
        get => _selectedEnrollment;
        set
        {
            if(_selectedEnrollment != value)
            {
                _selectedEnrollment = value;
                OnPropertyChanged();
                DeleteButton.IsVisible=_selectedEnrollment!=null;
            }
        }
    }
	public EnrollPage()
	{
		InitializeComponent();
        LoadStudents();
        LoadCourses();
        LoadEnrollments();
        this.BindingContext = this;
    }

    private void LoadStudents()
    {
        var students = App.DBTrans.GetStudents();
        StudentPicker.ItemsSource = students;
        StudentPicker.ItemDisplayBinding = new Binding("Name");
    }

    private void LoadCourses()
    {
        var courses = App.DBTrans.GetAllCourses();
        CoursePicker.ItemsSource = courses;
        CoursePicker.ItemDisplayBinding = new Binding("Name");
    }

    private void LoadEnrollments()
    {
        var enrollments = App.DBTrans.GetAllEnrollments();
        Enroll_List_View.ItemsSource = enrollments;
    }


    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (SelectedEnrollment == null)
        {
            await DisplayAlert("Error", "No enrollment selected.", "OK");
            return;
        }

        try
        {
            App.DBTrans.DeleteEnrollment(SelectedEnrollment.EnrollID);
            await DisplayAlert("Success", "Enrollment deleted.", "OK");
            LoadEnrollments(); // Update the list
            SelectedEnrollment = null; // Reset selection
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to delete enrollment: {ex.Message}", "OK");
        }
    }

    private async void Btn_Enroll_Add_Clicked(object sender, EventArgs e)
    {
        if (StudentPicker.SelectedItem == null || CoursePicker.SelectedItem == null)
        {
            await DisplayAlert("Error", "You must select both a student and a course.", "OK");
            return;
        }

        var selectedStudent = (StudentClass)StudentPicker.SelectedItem;
        var selectedCourse = (CourseClass)CoursePicker.SelectedItem;

        EnrollClass enrollment = new EnrollClass
        {
            StudentID = selectedStudent.ID,
            CourseID = selectedCourse.CourseID
        };

        try
        {
            App.DBTrans.AddEnrollment(enrollment);
            await DisplayAlert("Success", "Enrollment successful.", "OK");
            LoadEnrollments(); // Update the list
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to enroll: {ex.Message}", "OK");
        }
    }
}