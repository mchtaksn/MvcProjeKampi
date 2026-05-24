using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Conctete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }
        [StringLength(100)]
        public string WriterName { get; set; }
        [StringLength(100)]
        public string WriterSurName { get; set; }
        [StringLength(250)]
        public string? WriterImage { get; set; }
        [StringLength(500)]
        public string?  WriterAbout { get; set; }

        [StringLength(50)]
        public string WriterMail { get; set; }
        [StringLength(70)]
        public string WriterPasword { get; set; }
        [StringLength(50)]
        public string? WriterTitle { get; set; }

        public bool? WriterStatus { get; set; }

        [InverseProperty("Writer")]
        public virtual ICollection<Heading> Headings { get; set; }

        [InverseProperty("Writer")]
        public virtual ICollection<Content> Contents { get; set; }
    }
    }

