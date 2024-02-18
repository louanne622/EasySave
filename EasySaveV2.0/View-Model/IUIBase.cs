using System.Globalization;
using System.Resources;
using System.Threading;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;
using System.Windows.Input;

namespace EasySaveV2._0.ViewModel
{
    public class IUIBase : INotifyPropertyChanged
    {
        private ResourceManager _resManager;

        public string CreateButtonText { get; private set; }
        public string EditButtonText { get; private set; }
        public string DeleteButtonText { get; private set; }
        public string ExecuteButtonText { get; private set; }
        public string OpenFileButtonText { get; private set; }
        public string HeaderGridViewName { get; private set; }
        public string HeaderGridViewSource { get; private set; }
        public string HeaderGridViewTarget { get; private set; }
        public string HeaderGridViewType { get; private set; }
        public string WindowTitle { get; private set; }
        public string HeaderItemSave { get; private set; }
        public string HeaderItemLog { get; private set; }
        public string HeaderItemParam { get; private set; }
        public string LabelChangeLang { get; private set; }
        public string LabelLogPath { get; private set; }
        public string LabelCryptExten { get; private set; }

        public IUIBase()
        {
            UpdateLocalizedProperties("EN");
        }

        public void UpdateLocalizedProperties(string cultureCode)
        {
            CultureInfo culture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentUICulture = culture;
            _resManager = new ResourceManager("EasySaveV2._0.Resources.Lang."+cultureCode, typeof(IUIBase).Assembly);

            CreateButtonText = _resManager.GetString("CreateButton", culture);
            EditButtonText = _resManager.GetString("EditButton", culture);
            DeleteButtonText = _resManager.GetString("DeleteButton", culture);
            ExecuteButtonText = _resManager.GetString("ExecuteButton", culture);
            OpenFileButtonText = _resManager.GetString("OpenButton", culture);
            HeaderGridViewName = _resManager.GetString("HeaderGridViewName", culture);
            HeaderGridViewSource = _resManager.GetString("HeaderGridViewSource", culture);
            HeaderGridViewTarget = _resManager.GetString("HeaderGridViewTarget", culture);
            HeaderGridViewType = _resManager.GetString("HeaderGridViewType", culture);
            WindowTitle = _resManager.GetString("WindowTitle", culture);
            HeaderItemSave = _resManager.GetString("HeaderItemSave", culture);
            HeaderItemLog = _resManager.GetString("HeaderItemLog", culture);
            HeaderItemParam = _resManager.GetString("HeaderItemParam", culture);
            LabelChangeLang = _resManager.GetString("LabelChangeLang", culture);
            LabelLogPath = _resManager.GetString("LabelLogPath", culture);
            LabelCryptExten = _resManager.GetString("LabelCryptExten", culture);


            OnPropertyChanged(string.Empty); // Une chaîne vide notifie tous les abonnés.
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}