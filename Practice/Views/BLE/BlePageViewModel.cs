using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.EventArgs;
using Practice.Interfaces;

namespace Practice.Views;

public partial class BlePageViewModel : BaseViewModel
{
    private readonly IDialogService _dialogService;
    private readonly IAdapter _bluetoothAdapter;
    private readonly IBluetoothLE _bluetoothLE;

    public ObservableCollection<BluetoothDevice> Devices { get; } = [];

    public BlePageViewModel(IDialogService dialogService)
    {
        _dialogService = dialogService;
        _bluetoothLE = CrossBluetoothLE.Current;
        _bluetoothAdapter = CrossBluetoothLE.Current.Adapter;
        _bluetoothAdapter.DeviceDiscovered += OnDeviceDiscovered;
    }

    [RelayCommand]
    private async Task ScanAsync()
    {
        try
        {
            Devices.Clear();
            if (_bluetoothLE.State == BluetoothState.On)
            {
                await _bluetoothAdapter.StartScanningForDevicesAsync();
            }
            else
            {
                await _dialogService.ShowAlertAsync(title: "", message: "Bluetooth is off. Please enable it");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error while scanning: {ex.Message}");
        }
    }

    #region handlers

    private void OnDeviceDiscovered(object sender, DeviceEventArgs deviceArgs)
    {
        if (!string.IsNullOrEmpty(deviceArgs.Device.Name))
        {
            Devices.Add(new BluetoothDevice
            {
                Name = deviceArgs.Device.Name,
                Id = deviceArgs.Device.Id.ToString()
            });
        }
    }

    #endregion
}