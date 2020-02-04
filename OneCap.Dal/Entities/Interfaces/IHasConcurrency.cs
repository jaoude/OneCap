using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OneCap.Dal.Entities
{
    public interface IHasConcurrency
    {
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
