using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore;

namespace UMS.Entities
{
    public class Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private Guid _id;

        private DateTime _createdDate;

        private String _createdBy;

        private DateTime _modifiedDate;

        private String _modifiedBy;

        private bool _isActive;

        private int _recordStatus;


        public Guid ID { get => _id; set => _id = value; }

        public DateTime CreatedDate { get => _createdDate; set => _createdDate = value; }

        public String CreatedBy { get => _createdBy; set => _createdBy = value; }

        public DateTime ModifiedDate { get => _modifiedDate; set => _modifiedDate = value; }

        public String ModifiedBy { get => _modifiedBy; set => _modifiedBy = value; }

        public Boolean IsActive { get => _isActive; set => _isActive = value; }

        public int RecordStatus { get => _recordStatus; set => _recordStatus = value; }

    }
}

