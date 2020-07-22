using System;
using System.Collections.Generic;
using System.Text;

namespace DB4_Movies
{
    class Movie : IComparable
    {
        private string _category;
        private string _title;

        public string Title
        {
            get { return _title; }
            set
            { 
                if (value == null || value == "")
                {
                    _title = "Unknown";
                }
                else
                {
                    _title = value;
                }
            }
        }

        public string Category
        {
            get { return _category; }
            set
            {
                if (value == null || value == "")
                {
                    _category = "Unknown";
                }
                else
                {
                    _category = value;
                }
            }
        }

        public Movie(string title, string category)
        {
            Title = title;
            Category = category;
        }

        public override string ToString()
        {
            return Title;
        }

        public int CompareTo(object obj)
        {
            return Title.CompareTo(obj.ToString());
        }
    }
}
