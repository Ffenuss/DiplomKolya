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
    
    public partial class Expenses
    {
        public int ExpenseId { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public string ExpenseName { get; set; }
        public decimal Amount { get; set; }
    
        public virtual Projects Projects { get; set; }
    }
}