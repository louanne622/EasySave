using System.Globalization;
using System.Resources;
using System.Threading;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;
using System.Windows.Input;
using EasySaveV3._0.Resources;

namespace EasySaveV3._0.ViewModels
{
    public class IUIBase : INotifyPropertyChanged
    {
        private ResourceManager _resManager;
        public string CreateButtonText { get; private set; }
        public string EditButtonText { get; private set; }
        public string DeleteButtonText { get; private set; }
        public string ExecuteButtonText { get; private set; }
        public string OpenFileButtonText { get; private set; }
        public string CreateSaveButtonText { get; private set; }
        public string EditSaveButtonText { get; private set; }
        public string CancelButtonText { get; private set; }
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
        public string LabelFileFormat { get; private set; }
        public string TextBoxEditSave { get; private set; }
        public string TextBoxCreateSave { get; private set; }
        public string LabelNameSave { get; private set; }
        public string LabelSourceSave { get; private set; }
        public string LabelSaveTarget { get; private set; }
        public string LabelType { get; private set; }
        public string LabelFileSizeMax { get; private set; }
        public string LabelFilesPriority { get; private set; }

        public IUIBase()
        {
            UpdateLocalizedProperties("FR");
        }

        public void UpdateLocalizedProperties(string cultureCode)
        {
            CultureInfo culture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentUICulture = culture;
            _resManager = new ResourceManager("EasySaveV3._0.Resources.Lang." + cultureCode, typeof(IUIBase).Assembly);

            CreateButtonText = _resManager.GetString("CreateButton", culture);
            EditButtonText = _resManager.GetString("EditButton", culture);
            DeleteButtonText = _resManager.GetString("DeleteButton", culture);
            ExecuteButtonText = _resManager.GetString("ExecuteButton", culture);
            OpenFileButtonText = _resManager.GetString("OpenButton", culture);
            CreateSaveButtonText = _resManager.GetString("CreateSaveButton", culture);
            EditSaveButtonText = _resManager.GetString("EditSaveButton", culture);
            CancelButtonText = _resManager.GetString("CancelButton", culture);
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
            LabelFileFormat = _resManager.GetString("LabelTypeExt", culture);
            LabelNameSave = _resManager.GetString("LabelNameSave", culture);
            LabelSourceSave = _resManager.GetString("LabelSource", culture);
            LabelSaveTarget = _resManager.GetString("LabelTarget", culture);
            LabelType = _resManager.GetString("LabelSaveType", culture);
            TextBoxCreateSave = _resManager.GetString("TextBoxCreateSave", culture);
            TextBoxEditSave = _resManager.GetString("TextBoxEditSave", culture);
            LabelFileSizeMax = _resManager.GetString("LabelMaxFileSize", culture);
            LabelFilesPriority = _resManager.GetString("LabelFilePriority", culture);

            OnPropertyChanged(string.Empty);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}