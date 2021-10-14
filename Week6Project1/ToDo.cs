using System;
using System.ComponentModel;
using SQLite;

namespace Week6Project1
{
    public class toDoTask : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

       
        private string _task;// backing field

        [MaxLength(255)]
        public string task
        {
            get { return _task; }
            set
            {
                if (value == _task)
                    return;
                _task = value;

                if (PropertyChanged != null)
                {

                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(task)));
                }
            }
        }
        private bool _isUrgent;
        public bool isUrgent
        {
            set
            {
                if (value == _isUrgent)
                    return;
                _isUrgent = value;

                if (PropertyChanged != null)
                {

                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(isUrgent)));
                }
            }
            get { return _isUrgent; }
        }

        [Ignore]
        public string taskImage
        {
            get
            {
                if (isUrgent)
                    return "https://media.istockphoto.com/vectors/checklist-rejected-red-icon-clipboard-with-failed-task-symbol-vector-vector-id1022118518";
                else
                    return "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRCWz-5GGIH1OHiJ7jkOO7_ebsWStneN6fDxw&usqp=CAU";

            }


            set { }
        }

        public static explicit operator toDoTask(EventArgs v)
        {
            throw new NotImplementedException();
        }
    }

}
