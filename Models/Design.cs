using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Design{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int id {set; get;}
    public DateTime created_at {set; get;}
    public Guid created_by {set; get;}
    public string? path_name {set; get;}
    public string? imageSourceURL {set; get;}
    public string[]? viewNumbers {set; get;}
    public string? affiliateURL {set; get;}
    public string? model_name {set; get;}
    public string? title {set; get;}
    public string? description {set; get;}
    public bool is_pinned {set; get;}

}