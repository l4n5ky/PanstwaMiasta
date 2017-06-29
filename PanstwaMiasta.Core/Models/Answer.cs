using System;

namespace PanstwaMiasta.Core.Models
{
    // 2
    public class Answer
    {
        public string Category { get; protected set; }
        public string Value { get; protected set; }

        public Answer(string category, string value)
        {
            SetCategory(category);
            SetValue(value);
        }

        private void SetCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                throw new Exception("Category can not be empty.");
            }
            if (Category == category)
            {
                return;
            }

            Category = category;
        }

        private void SetValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Value = null;
            }
            if (Value == value)
            {
                return;
            }

            Value = value;
        }
    }
}
