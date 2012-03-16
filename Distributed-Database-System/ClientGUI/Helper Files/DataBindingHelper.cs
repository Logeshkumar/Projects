using System;
using System.ComponentModel;

namespace edu.syr.cse784.eskimodb.ClientGUI
{
  class DataBindingHelper : INotifyPropertyChanged
  {
    private string m_NoRowsPerPage;

    public string p_NoRowsPerPage
    {
      get
      {
        return m_NoRowsPerPage;
      }

      set
      {
        if (value != m_NoRowsPerPage)
        {
          m_NoRowsPerPage = value;
          NotifyPropertyChanged("RowsPerPage");
        }
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void NotifyPropertyChanged(String info)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(info));
      }
    }
  }
}
