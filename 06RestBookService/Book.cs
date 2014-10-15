using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Runtime.Serialization;

namespace RestBookService
{
    /// <summary>
    /// Book class : This class is retrieved through service
    /// </summary>
    [DataContract]
    public class Book
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string BookName { get; set; }
    }
}