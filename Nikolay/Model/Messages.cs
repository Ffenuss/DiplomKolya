//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nikolay.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Messages
    {
        public int MessageId { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public Nullable<int> SenderId { get; set; }
        public Nullable<int> ReceiverId { get; set; }
        public string MessageText { get; set; }
        public System.DateTime Timestamp { get; set; }
    
        public virtual Projects Projects { get; set; }
        public virtual Users Users { get; set; }
        public virtual Users Users1 { get; set; }
    }
}