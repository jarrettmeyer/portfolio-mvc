using System;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;
using NHibernate;

namespace Portfolio.Lib.Data
{
    /// <summary>
    /// Unique index violations will have a SQLException like the following:
    ///    Cannot insert duplicate key row in object 'dbo.Tags' with unique index 'IX_Tags_Description'. The duplicate key value is (Meetings).
    /// </summary>
    public class UniqueRecordViolationException : ApplicationException
    {
        private readonly string duplicateKeyValue;
        private readonly string table;
        private readonly string uniqueIndex;

        public UniqueRecordViolationException(Exception innerException)
            : base(innerException.Message, innerException)
        {
            Contract.Requires<ArgumentNullException>(innerException != null);
            var regex = new Regex(@"Cannot insert duplicate key row in object '(.+)' with unique index '(.+)'\. The duplicate key value is \((.+)\)\.");
            bool isMatch = regex.IsMatch(innerException.Message);
            if (!isMatch)
            {
                throw new ApplicationException("Unable to create new instance of UniqueRecordViolationException. Unable to parse inner exception message.", innerException);
            }
            MatchCollection matches = regex.Matches(innerException.Message);
            if (matches.Count == 1)            
            {
                
                table = matches[0].Groups[1].Value;
                uniqueIndex = matches[0].Groups[2].Value;
                duplicateKeyValue = matches[0].Groups[3].Value;
            }
        }

        public UniqueRecordViolationException(NonUniqueObjectException innerException)
            : base(innerException.Message, innerException)
        {
            Contract.Requires<ArgumentNullException>(innerException != null);
            duplicateKeyValue = innerException.Identifier.ToString();
            table = innerException.EntityName;
            uniqueIndex = "primary_key";
        }

        public string Table
        {
            get { return table; }
        }

        public string UniqueIndex
        {
            get { return uniqueIndex; }
        }

        public string DuplicateKeyValue
        {
            get { return duplicateKeyValue; }
        }        
    }
}