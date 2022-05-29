using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SeqCounterX.Model
{
    public class ConstraintOptionsEntity : INotifyPropertyChanged
    {
        public string seqTypeList
        {
            get
            {
                return _seqTypeList;
            }
            set
            {
                _seqTypeList = value;
                _seqTypeStr = UtilX.ReadFileToStr(value);
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("seqTypeList"));
                }
            }
        }
        private string _seqTypeList = "./ini/virusinfo.ini";

        [Newtonsoft.Json.JsonIgnore]
        public string seqTypeStr
        {
            get
            {
                return _seqTypeStr;
            }
            set
            {
                _seqTypeStr = value;
                UtilX.SaveStrToFile(value, _seqTypeList);
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("seqTypeStr"));
                }
            }
        }
        private string _seqTypeStr = "";

        public bool seqTypeCheck 
        {
            get
            {
                return _seqTypeCheck;
            }
            set
            {
                _seqTypeCheck = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("seqTypeCheck"));
                }
            }
        } 
        private bool _seqTypeCheck = true;

        public string[] removeSymbols { get; set; } = { " ", "\n", "\t" };

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
