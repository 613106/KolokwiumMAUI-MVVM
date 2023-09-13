using System;
using System.ComponentModel;
using System.Windows.Input;

namespace KolokwiumMAUI.ModelWidoku
{
    using KolokwiumMAUI.Model;

    public class GlownyModelWidoku : INotifyPropertyChanged
    {
        private Model model;

        public Model Model
        {
            get { return model; }
            set
            {
                if (model != value)
                {
                    model = value;
                    OnPropertyChanged(nameof(Model));
                }
            }
        }

        private double? wartoscSuwaka;

        public double? WartoscSuwaka
        {
            get { return wartoscSuwaka; }
            set
            {
                if (wartoscSuwaka != value)
                {
                    wartoscSuwaka = value;
                    OnPropertyChanged(nameof(WartoscSuwaka));

                    if (Model == null)
                    {
                        Model = new Model
                        {
                            WartoscSuwaka = 0,
                            WartoscLabel = "0",
                            KolorLabel = Color.FromRgb(255, 0, 0)
                        };
                    }

                    if (value == null)
                    {
                        Model.WartoscLabel = "0";
                    }
                    else
                    {
                        int intValue = (int)value;
                        Model.WartoscLabel = intValue.ToString();
                    }

                    Model.KolorLabel = value < 128 ? Color.FromRgb(255, 0, 0) : Color.FromRgb(0, 0, 128);
                    OnPropertyChanged(nameof(Model));
                }
            }
        }

        public void ZerujSuwak(object parameter)
        {
            WartoscSuwaka = 0;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string nazwaWartosci)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nazwaWartosci));
        }
        #endregion

        #region Polecenie

        private ICommand wyzeruj;

        public ICommand Wyzeruj
        {
            get
            {
                if (wyzeruj == null)
                    wyzeruj = new Polecenie(ZerujSuwak);
                return wyzeruj;
            }
        }
        #endregion
    }
}
