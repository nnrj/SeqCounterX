using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SeqCounterX.Model
{
    public class OutputOptionsEntity : INotifyPropertyChanged
    {
        public string resultPath 
        {
            get
            {
                return _resultPath;
            }
            set{
                _resultPath = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("resultPath"));
                }
            }
        } 
        private string _resultPath = "./results/";

        public string resultExtensionName
        {
            get
            {
                return _resultExtensionName;
            }
            set
            {
                _resultExtensionName = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("resultExtensionName"));
                }
            }
        }
        private string _resultExtensionName = ".log";

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

        public bool compare 
        {
            get
            {
                return _compare;
            }
            set
            {
                _compare = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("compare"));
                }
            } 
        } 
        private bool _compare = true;

        public bool combineCompare 
        {
            get
            {
                return _combineCompare;
            }
            set
            {
                _combineCompare = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("combineCompare"));
                }
            }
        } 
        private bool _combineCompare = false;

        public bool extractSeq 
        {
            get
            {
                return _extractSeq;
            }
            set
            {
                _extractSeq = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("extractSeq"));
                }
            }
        } 
        private bool _extractSeq = true;

        public bool singleExtract 
        {
            get
            {
                return _singleExtract;
            }
            set
            {
                _singleExtract = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("singleExtract"));
                }
            }
        } 
        private bool _singleExtract = false;

        public string extractExtensionName
        {
            get
            {
                return _extractExtensionName;
            }
            set
            {
                _extractExtensionName = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("extractExtensionName"));
                }
            }
        }
        private string _extractExtensionName = ".fasta";

        public string[] removeSymbols
        {
            get
            {
                return _removeSymbols;
            }
            set
            {
                _removeSymbols = value;
                string myRemoveSymbols = "";
                bool firstFlag = true;
                foreach (string str in removeSymbols)
                {
                    if (firstFlag)
                    {
                        myRemoveSymbols += str;
                        firstFlag = false;
                        continue;
                    }
                    myRemoveSymbols += ("," + str);
                }
                _removeSymbolsStr = UtilX.EncodeEscapeStr(myRemoveSymbols);
            }
        }
        private string[] _removeSymbols = { " ", "\n", "\t", "@num", " " };

        [Newtonsoft.Json.JsonIgnore]
        public string removeSymbolsStr
        {
            get
            {
                return _removeSymbolsStr;
            }
            set
            {
                _removeSymbolsStr = value;
                string decodeValue = UtilX.DecodeEscapeStr(value);
                _removeSymbols = decodeValue.Split(",");
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("removeSymbolsStr"));
                }
            }
        }
        private string _removeSymbolsStr = " ,\\n,\\t,@num,&emsp";

        public bool ignoreEmptySeq
        {
            get
            {
                return _ignoreEmptySeq;
            }
            set
            {
                _ignoreEmptySeq = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ignoreEmptySeq"));
                }
            }
        }
        private bool _ignoreEmptySeq = true;

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
