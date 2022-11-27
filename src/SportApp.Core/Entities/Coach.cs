//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SportApp.Core.Entities
//{
//    public class Coach
//    {
//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        public long Id { get; set; }

//        [ForeignKey(nameof(User))]
//        public string UserId { get; set; }
//        User User { get; set; }

//    }
//}