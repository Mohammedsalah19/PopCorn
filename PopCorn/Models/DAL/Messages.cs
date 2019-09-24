using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PopCorn.Models.DAL
{
    public class Messages
    {
        [Key]
        public int MessageID { get; set; }
        public string Name { get; set; }
        public string Messaage { get; set; }
    }
}