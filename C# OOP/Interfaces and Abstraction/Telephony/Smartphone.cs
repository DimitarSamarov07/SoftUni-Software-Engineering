using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone:ICallable,IBrowseable
    {
        private List<string> numberList;
        private List<string> urlList;

        public Smartphone(List<string> numberList,List<string> urlList)
        {
            this.NumberList = numberList;
            this.UrlList = urlList;
        }
        public string Call()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var number in NumberList)
            {
                if (number.All(char.IsDigit))
                {
                    sb.Append($"Calling... {number}");
                    sb.Append(Environment.NewLine);
                }
                else
                {
                    sb.Append("Invalid number!");
                    sb.Append(Environment.NewLine);
                }
            }

            return sb.ToString().TrimEnd();
        }

        public List<string> NumberList
        {
            get => numberList;
            set => numberList = value;
        }

        public string Browse()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var url in UrlList)
            {
                if (!url.Any(char.IsDigit))
                {
                    sb.Append($"Browsing: {url}!");
                    sb.Append(Environment.NewLine);
                }

                else
                {
                    sb.Append("Invalid URL!");
                    sb.Append(Environment.NewLine);
                }
            }

            return sb.ToString().TrimEnd();
        }

        public List<string> UrlList
        {
            get => urlList;
            set => urlList = value;
        }
    }
}
