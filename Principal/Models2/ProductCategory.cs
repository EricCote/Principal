using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Principal.Models2
{
    /// <summary>
    /// High-level product categorization.
    /// </summary>
    [Table("ProductCategory", Schema = "SalesLT")]
    [Index("Name", Name = "AK_ProductCategory_Name", IsUnique = true)]
    [Index("Rowguid", Name = "AK_ProductCategory_rowguid", IsUnique = true)]
    public partial class Category
    {
        public Category()
        {
            ChildCategories = new HashSet<Category>();
            Products = new HashSet<Product>();
        }

        /// <summary>
        /// Primary key for ProductCategory records.
        /// </summary>
        [Key]
        [Column("ProductCategoryID")]
        public int ProductCategoryId { get; set; }
        /// <summary>
        /// Product category identification number of immediate ancestor category. Foreign key to ProductCategory.ProductCategoryID.
        /// </summary>
        [Column("ParentProductCategoryID")]
        public int? ParentCategoryId { get; set; }
        /// <summary>
        /// Category description.
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; } = null!;
        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// </summary>
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("ParentCategoryId")]
        [InverseProperty("ChildCategories")]
        public virtual Category? ParentCategory { get; set; }
        [InverseProperty("ParentCategory")]
        public virtual ICollection<Category> ChildCategories { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
