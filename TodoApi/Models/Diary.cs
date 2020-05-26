using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

public class Diary
{
    
    public long Id { get; set; }
    public string Date { get; set; }
    public bool Holiday { get; set; }
    public ICollection<Todoitem> Tasks { get; set; }
    public string Message { get; set; }
}

/*{
    "Id":1,
    "Date": "19.04.2020" ,
    "Holiday": true ,
    "Message":"Korona uydi",
    "Tasks" : {
    	 "Id":1,
    	"Name": "plevat v potolok" ,
		"IsComplete" : true 
    }
  }*/
