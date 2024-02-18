using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveV2._0
{
    class SaveList
    {
        private readonly List<Save> _saves;

        public SaveList()
        {
            _saves = new List<Save>();
        }

        public IEnumerable<Save> GetSave()
        {
            return _saves;
        }

        public void AddSave(Save save)
        {

            _saves.Add(save);
        }
    }
}
