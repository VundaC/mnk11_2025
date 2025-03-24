using System.ComponentModel;
using System.Runtime.CompilerServices;
using PropertyChangingEventHandler = System.ComponentModel.PropertyChangingEventHandler;
using PropertyChangingEventArgs = System.ComponentModel.PropertyChangingEventArgs;

namespace Practice.Views;

public class BaseViewModel : IQueryAttributable, INotifyPropertyChanging, INotifyPropertyChanged
{
    #region variables

    public event PropertyChangedEventHandler PropertyChanged;
    public event PropertyChangingEventHandler PropertyChanging;

    private bool _isBusy;
    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value);
    }

    #endregion

    #region methods

    protected virtual void OnPropertyChanging([CallerMemberName] string propertyName = null)
    {
        PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
        {
            return false;
        }

        OnPropertyChanging(propertyName);
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    #endregion

    public virtual void ApplyQueryAttributes(IDictionary<string, object> query)
    {
    }
}