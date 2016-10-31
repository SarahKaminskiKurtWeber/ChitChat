using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChitChatter.Models
{
    public class ChitChat
    {
        //ChitChat Conroller
        [Key]
        public int ChitChatID { get; set; }
        public string ChitChatText { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}