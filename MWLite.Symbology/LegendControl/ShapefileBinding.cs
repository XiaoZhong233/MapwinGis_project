using System.Collections.Generic;

namespace MWLite.Symbology.LegendControl
{
    /// <summary>
    /// 绑定sf
    /// </summary>
    public class ShapefileBinding
    {
        public List<string> KeyFields;  
        public string DatabaseName = string.Empty;
        public string Guid = string.Empty;             
        public ShapefileBinding()
        {
            KeyFields = new List<string>();
        }


        public string CsvKeys
        {
            get
            {
                return string.Join(";", KeyFields.ToArray());
            }
            set
            {
                KeyFields.Clear();
                if (!string.IsNullOrWhiteSpace(value))
                    KeyFields.AddRange(value.Split(new[] {';'}));
            }
        }



        public bool Imported { get; set; }

    

        public class ParadoxDatabase
        {
            public int Index;
            public string Path;
            public string RelativePath;
        }

        public ParadoxDatabase SourceBinding;
    }
}
