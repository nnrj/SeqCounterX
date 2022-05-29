using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SeqCounterX.Model
{
    public class SeqCounterEntity : INotifyPropertyChanged
    {
        public string encoding { get; set; } = "utf-8";

        public InputOptionsEntity inputOptions { get; set; } = new InputOptionsEntity();

        public OutputOptionsEntity outputOptions { get; set; } = new OutputOptionsEntity();

        public ConstraintOptionsEntity constraintOptions { get; set; } = new ConstraintOptionsEntity();

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
