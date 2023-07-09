using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MVVM_Color_Scroller
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private byte _alpha;
        private byte _red;
        private byte _green;
        private byte _blue;
        private SolidColorBrush _buttonBrush;

        public byte Alpha
        {
            get { return _alpha; }
            set
            {
                if (_alpha != value)
                {
                    _alpha = value;
                    OnPropertyChanged();
                    UpdateButtonBrush();
                }
            }
        }

        public byte Red
        {
            get { return _red; }
            set
            {
                if (_red != value)
                {
                    _red = value;
                    OnPropertyChanged();
                    UpdateButtonBrush();
                }
            }
        }

        public byte Green
        {
            get { return _green; }
            set
            {
                if (_green != value)
                {
                    _green = value;
                    OnPropertyChanged();
                    UpdateButtonBrush();
                }
            }
        }

        public byte Blue
        {
            get { return _blue; }
            set
            {
                if (_blue != value)
                {
                    _blue = value;
                    OnPropertyChanged();
                    UpdateButtonBrush();
                }
            }
        }

        public SolidColorBrush ButtonBrush
        {
            get { return _buttonBrush; }
            set
            {
                if (_buttonBrush != value)
                {
                    _buttonBrush = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ChangeColorCommand { get; }

        public MainViewModel()
        {
            ChangeColorCommand = new RelayCommand(ChangeColor);
            UpdateButtonBrush();
        }

        private void ChangeColor()
        {
            MessageBox.Show("По приколу сделал обработчик)))");
        }

        private void UpdateButtonBrush()
        {
            ButtonBrush = new SolidColorBrush(Color.FromArgb(Alpha, Red, Green, Blue));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}