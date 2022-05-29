using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SeqCounterX.Model
{
    internal class ScqxSettingEntity : INotifyPropertyChanged
    {
        public string version 
        {
            get
            {
                return _version;
            }
            set
            {
                _version = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("version"));
                }
            }
        } 
        private string _version = "1.0.0";

        public string seqCOunterCore
        {
            get
            {
                return _seqCOunterCore;
            }
            set
            {
                _seqCOunterCore = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("seqCOunterCore"));
                }
            }
        }
        private string _seqCOunterCore = "./seqCounter.exe";

        public string coreSetting
        {
            get
            {
                return _coreSetting;
            }
            set
            {
                _coreSetting = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("coreSetting"));
                }
            }
        }
        private string _coreSetting = "./ini/setting.json";

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
