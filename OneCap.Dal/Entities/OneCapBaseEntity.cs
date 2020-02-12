using OneCap.Dal.Interfaces;
using System.ComponentModel.DataAnnotations;


namespace OneCap.Dal.Entities
{

    public abstract class OneCapBaseEntity <TPrimaryKey>
    {
        [Key]
        public TPrimaryKey Id { get; set; }
    }
}
