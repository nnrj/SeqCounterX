using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SeqCounterX.Model
{
    public class InputOptionsEntity : INotifyPropertyChanged
    {
        public string seqPath {
            get
            {
                return _seqPath;
            }
            set{
                _seqPath = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("seqPath"));
                }
            }
        }
        private string _seqPath = "./seqs/";

        public string seqExtensionName 
        {
            get
            {
                return _seqExtensionName;
            }
            set
            {
                _seqExtensionName = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("seqExtensionName"));
                }
            }
        } 
        private string _seqExtensionName = ".txt";

        public string encoding 
        {
            get
            {
               return _encoding;
            }
            set
            {
                _encoding = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("encoding"));
                }
            } 
        } 
        private string _encoding = "utf-8";

        public string[] symbols 
        {
            get
            {
                return _symbols;
            }
            set
            {
                _symbols = value;
                _symbolsStr = "";
                bool firstFlag = true;
                foreach (string str in symbols)
                {
                    if (firstFlag)
                    {
                        _symbolsStr += str;
                        firstFlag = false;
                        continue;
                    }
                    _symbolsStr += ("," + str);
                }
            }
        } 
        private string[] _symbols = { ">", ">>" };

        [Newtonsoft.Json.JsonIgnore]
        public string symbolsStr
        {
            get
            {
                return _symbolsStr;
            }
            set
            {
                _symbolsStr = value;
                _symbols = value.Split(",");
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("symbolsStr"));
                }
            }
        }
        private string _symbolsStr = ">,>>";

        /// <summary>
        /// 属性改变后需要调用的方法，触发PropertyChanged事件。
        /// </summary>
        /// <param name="propertyName">属性名</param>
        private void SendChangeInfo(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// 实现的接口。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
