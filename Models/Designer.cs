using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
public class Designer{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid designer_id {set; get;}
    public string? username {set; get;}
    public DateTime created_at {set; get;}
    public string? description {set; get;}
    public string? instagram_tag {set; get;}
    public string? twitter_tag {set; get;}
    public string? discord_id {set; get;} 
}