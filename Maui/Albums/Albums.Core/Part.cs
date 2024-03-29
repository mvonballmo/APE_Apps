﻿using System.ComponentModel;

namespace Albums.Core
{
  [Serializable]
  public class Part : INotifyPropertyChanged
  {
    string _partId;

    public string PartID
    {
      get => _partId;
      set
      {
        if (_partId == value)
          return;

        _partId = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PartID)));
      }
    }

    string _partName;

    public string PartName
    {
      get => _partName;
      set
      {
        if (_partName == value)
          return;

        _partName = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PartName)));
      }
    }

    string _theSuppliers;

    public string TheSuppliers
    {
      get => _theSuppliers;
      set
      {
        if (_theSuppliers == value)
          return;

        _theSuppliers = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TheSuppliers)));
      }
    }

    string _partType;

    public string PartType
    {
      get => _partType;
      set
      {
        if (_partType == value)
          return;

        _partType = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PartType)));
      }
    }

    public List<string> Suppliers { get; set; }

    public DateTime PartAvailableDate { get; set; }

    public string SupplierString
    {
      get
      {
        var result = String.Empty;
        foreach (var supplier in Suppliers)
        {
          result += $"{supplier}, ";
        }
        result = result.Trim(',', ' ');
        return result;
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }
}