using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

using EasySaveConsole.View;
using EasySaveConsole.Model;

namespace EasySaveConsole.ModelView
{
    class VMWorkshop
    {
        private ViewInterfaceConsole objUIConsole;
        public VMWorkshop()
        {
            this.objUIConsole = new ViewInterfaceConsole();
        }
        public void getInto()
        {
            this.objUIConsole.getIntro();
        }
        public void getInterface_HomeMenu()
        {
            this.objUIConsole.interface_HomeMenu();
        }
        public void setLang(bool input)
        {
            this.objUIConsole.setLang(input);
        }
        public bool getLang() 
        { 
            return this.objUIConsole.getLang(); 
        }
        public void getInfoLang()
        {
            this.objUIConsole.getInfoLang();
        }
        public void setDataSave(Save _save, int _id, string _Name, string _FilesSource, string _FilesTarget, string _Type)
        {
            _save.Id = _id;
            _save.Name = _Name;
            _save.FilesSource = _FilesSource;
            _save.FilesTarget = _FilesTarget;
            _save.Type = _Type;
        }
        public Save[] getAllSaveFromJSON()
        {
            Json objJson = new Json();
            return objJson.getJsonData(AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\Saves.json");
        }
        public void UpdateJsonData(Save _save, string _name, string _fileSource, string _fileTarget, string _type)
        {
            Json _json = new Json();
            if (_name != "") _json.UpdateJsonName(_save, _name);
            if (_fileSource != "") _json.UpdateJsonFileSource(_save, _fileSource);
            if (_fileTarget != "") _json.UpdateJsonFileTarget(_save, _fileTarget);
            if (_type != "") _json.UpdateJsonType(_save, _type);
        }
        public void DeleteJsonData(Save _save)
        {
            Json _json = new Json();
            _json.DeleteJsonSaveData(_save);
        }
    }
}
